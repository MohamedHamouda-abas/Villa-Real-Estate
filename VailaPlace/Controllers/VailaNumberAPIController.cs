using AutoMapper;
using Azure;
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
    [Route("api/[controller]")]
    [ApiController]
    public class VailaNumberAPIController : ControllerBase
    {
        private readonly ILogger<VailaAPIController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public VailaNumberAPIController(ILogger<VailaAPIController> logger, ApplicationDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
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
                IEnumerable<VailaNumber> model = _unitOfWork.VailaNumberRepository.GetAll(includeProperties: "Vaila");
                _response.Result = _mapper.Map<List<VailaNumber>>(model);
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
        [HttpGet("id", Name = "GetVailaNumberById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        public ActionResult<APIResponse> GetVailaNumberById(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError($"We dont have an id with + {id}");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var vaila = _unitOfWork.VailaNumberRepository.Get(u => u.VailaNo == id);
                if (vaila == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<List<VailaNumberDto>>(vaila);
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

        #region CreateVailaNumber
        #region StatusCode
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        public ActionResult<APIResponse> CreateVaila([FromBody] VailaNumberCreateDto CreateVailaDto)
        {
            try
            {
                if (_unitOfWork.VailaNumberRepository.Get(u => u.SpecialDetails.ToLower() == CreateVailaDto.SpecialDetails.ToLower()) != null)
                {
                    ModelState.AddModelError("name", "This SpecialDetails is already exsist");
                    return BadRequest(ModelState);
                }

                if (CreateVailaDto == null)
                {
                    return BadRequest(CreateVailaDto);
                }
                VailaNumber model = _mapper.Map<VailaNumber>(CreateVailaDto);
                _response.Result = _mapper.Map<VailaNumber>(CreateVailaDto);
                _unitOfWork.VailaNumberRepository.Add(model);
                _response.StatusCode = HttpStatusCode.Created;
                _unitOfWork.Save();
                _response.IsSuccess = true;
                return CreatedAtRoute("GetVailaNumberById", new { id = model.VailaNo }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;
        }
        #endregion

        #region Update

        #region StatusCode
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        #endregion
        public ActionResult<APIResponse> UpdatelVailsNumber(int id, [FromBody] VailaNumberUpdateDto VailaUpdteDto)
        {
            try
            {
                if (_unitOfWork.VailaNumberRepository.Get(u => u.SpecialDetails.ToLower() == VailaUpdteDto.SpecialDetails.ToLower()) != null)
                {
                    ModelState.AddModelError("name", "This SpecialDetails is already exsist");
                    return BadRequest(ModelState);
                }
                if (VailaUpdteDto == null || id != VailaUpdteDto.VailaNo)
                {
                    return BadRequest();
                }
                VailaNumber model = _mapper.Map<VailaNumber>(VailaUpdteDto);
                _response.Result = _mapper.Map<VailaNumber>(VailaUpdteDto);
                _unitOfWork.VailaNumberRepository.Update(model);
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

        #region Patch

        #region StatuseCode
        [HttpPatch("id", Name = "PatchUpdateVailaNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        #endregion
        public async Task<IActionResult> PatchUpdateVailaNumber(int id, JsonPatchDocument<VailaNumberUpdateDto> patch)
        {
            if (patch == null || id == 0)
            {
                return BadRequest();
            }
            var vaila = _unitOfWork.VailaRepository.Get(u => u.Id == id);
            VailaNumberUpdateDto vailaDTO = _mapper.Map<VailaNumberUpdateDto>(vaila);
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
            VailaNumber model = _mapper.Map<VailaNumber>(vailaDTO);
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
            _unitOfWork.VailaNumberRepository.Update(model);
            _unitOfWork.Save();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
        #endregion

        #region Delete
        #region StatusCode
        [HttpDelete("id", Name = "DeleteVailaNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        public ActionResult<APIResponse> DeleteVailaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var vaila = _unitOfWork.VailaNumberRepository.Get(u => u.VailaNo == id);
                if (vaila == null)
                {
                    return NotFound();
                }
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                _unitOfWork.VailaNumberRepository.Remove(vaila);
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
    }
}
