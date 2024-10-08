using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using VailaPlace.APIResponses;
using VailaPlace.Data;
using VailaPlace.Models;
using VailaPlace.Models.Dto;
using VailaPlace.Repository.IRepository;

namespace VailaPlace.Controllers
{
    [Route("api/VailaAPI")]
    [ApiController]
    public class VailaAPIController : ControllerBase
    {
        private readonly ILogger<VailaAPIController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public VailaAPIController(ILogger<VailaAPIController> logger, ApplicationDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            this._response = new();
        }

        #region GetAll
        #region StatusCode
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        #endregion
        public ActionResult<APIResponse> GetAllVails()
        {
            try
            {
                IEnumerable<Vaila> vilaList = _unitOfWork.VailaRepository.GetAll();
                _response.Result = _mapper.Map<List<VailaDto>>(vilaList);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;
        }
        #endregion

        #region GetById
        #region StatusCode
        [HttpGet("id", Name = "Getvila")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        public ActionResult<APIResponse> GetVailaById(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError($"We dont have an id with + {id}");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var vaila = _unitOfWork.VailaRepository.Get(u => u.Id == id);
                if (vaila == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<List<VailaDto>>(vaila);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;
        }
        #endregion

        #region CreateVaila
        #region StatusCode
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        public ActionResult<APIResponse> CreateVaila([FromBody] VailaCraeteDto CreateVailaDto)
        {
            try
            {
                if (_unitOfWork.VailaRepository.Get(u => u.Name.ToLower() == CreateVailaDto.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("name", "This vaila is already exsist");
                    return BadRequest(ModelState);
                }

                if (CreateVailaDto == null)
                {
                    return BadRequest(CreateVailaDto);
                }
                Vaila model = _mapper.Map<Vaila>(CreateVailaDto);
                _response.Result = _mapper.Map<Vaila>(CreateVailaDto);
                _unitOfWork.VailaRepository.Add(model);
                _response.StatusCode = HttpStatusCode.Created;
                _unitOfWork.Save();
                _response.IsSuccess = true;
                return CreatedAtRoute("Getvila", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;
        }
        #endregion


        #region UpdatelVails
        [Authorize]
        #region StatusCode
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        #endregion
        public ActionResult<APIResponse> UpdatelVails(int id, [FromBody] VailaUpdteDto VailaUpdteDto)
        {
            #region Mapping Manule

            //Vaila model = new()
            //{
            //    //If YOU DON'T PASS The ID YOU WILL CREATE A NEW RECORD RATHER THAN UPDATE IT
            //    Id = id,
            //    Amenity = obj.Amenity,
            //    Area = obj.Area,
            //    Occupancy = obj.Occupancy,
            //    sqft = obj.sqft,
            //    ImageUrl = obj.ImageUrl,
            //    Rate = obj.Rate,
            //    Details = obj.Details,
            //    Name = obj.Name
            //}; 
            #endregion
            try
            {
                if (_unitOfWork.VailaRepository.Get(u => u.Name.ToLower() == VailaUpdteDto.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("name", "This vaila is already exsist");
                    return BadRequest(ModelState);
                }
                if (VailaUpdteDto == null || id != VailaUpdteDto.Id)
                {
                    return BadRequest();
                }
                Vaila model = _mapper.Map<Vaila>(VailaUpdteDto);
                _response.Result = _mapper.Map<Vaila>(VailaUpdteDto);
                _unitOfWork.VailaRepository.Update(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;
        }
        #endregion
      
        #region StatusCode
        [HttpDelete("id", Name = "DeleteVaila")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        public ActionResult<APIResponse> DeleteVaila(int id)
        {
            try
            {
            if (id == 0)
            {
                return BadRequest();
            }
            var vaila = _unitOfWork.VailaRepository.Get(u => u.Id == id);
            if (vaila == null)
            {
                return NotFound();
            }
            _unitOfWork.VailaRepository.Remove(vaila);
            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;
        }

        #region PatchUpdateVaila
        #region StatuseCode
        [HttpPatch("id", Name = "PatchUpdateVaila")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        #endregion
        public async Task<IActionResult> PatchUpdateVaila(int id, JsonPatchDocument<VailaUpdteDto> patch)
        {
            if (patch == null || id == 0)
            {
                return BadRequest();
            }
            var vaila = _unitOfWork.VailaRepository.Get(u => u.Id == id);
            VailaUpdteDto vailaDTO = _mapper.Map<VailaUpdteDto>(vaila);
            #region Manule Mapping
            //VailaUpdteDto vailaDTO = new()
            //{
            //    Id = vaila.Id,
            //    Amenity = vaila.Amenity,
            //    Area = vaila.Area,
            //    Occupancy = vaila.Occupancy,
            //    sqft = vaila.sqft,
            //    ImageUrl = vaila.ImageUrl,
            //    Rate = vaila.Rate,
            //    Details = vaila.Details,
            //    Name = vaila.Name
            //}; 
            #endregion
            if (vaila == null)
            {
                return BadRequest();
            }
            patch.ApplyTo(vailaDTO, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
            Vaila model = _mapper.Map<Vaila>(vailaDTO);
            #region Manule Mapping
            //Vaila model = new Vaila()
            //{
            //    Id = vailaDTO.Id,
            //    Amenity = vailaDTO.Amenity,
            //    Area = vailaDTO.Area,
            //    Occupancy = vailaDTO.Occupancy,
            //    sqft = vailaDTO.sqft,
            //    ImageUrl = vailaDTO.ImageUrl,
            //    Rate = vailaDTO.Rate,
            //    Details = vailaDTO.Details,
            //    Name = vailaDTO.Name
            //}; 
            #endregion
            _unitOfWork.VailaRepository.Update(model);
            _unitOfWork.Save();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
        #endregion
    }
}
