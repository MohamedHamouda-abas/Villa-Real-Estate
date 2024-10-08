using AutoMapper;
using MagicVila_Web.Models.Dto;
using MagicVila_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using MagicVila_Web.APIResponses;
using Newtonsoft.Json;
using Montview_Web.Services;
using System.Collections.Generic;
using System.Reflection;

namespace MagicVila_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVilaService _vilaService;
        private readonly IMapper _mapper;

        public VillaController(IVilaService vilaService, IMapper mapper)
        {
            _vilaService = vilaService;
            _mapper = mapper;
        }

        #region GetAll
        public async Task<IActionResult> IndexVilla()
        {
            List<VailaDto> list = new();
            var response = await _vilaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VailaDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        #endregion

        #region Create
        public async Task<IActionResult> VillaCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VillaCreate(VailaCraeteDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _vilaService.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            return View(model);
        }
        #endregion

        #region Update
        public async Task<IActionResult> VillaUpdate(int villaId)
        {
            if (ModelState.IsValid)
            {
                var response = await _vilaService.GetAsync<APIResponse>(villaId);
                if (response != null && response.IsSuccess)
                {
                    //VailaDto[] models = JsonConvert.DeserializeObject<VailaDto[]>(Convert.ToString(response.Result));
                    VailaDto model = JsonConvert.DeserializeObject<VailaDto>(Convert.ToString(response.Result));
                    return View(_mapper.Map<VailaUpdteDto>(model));
                }
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VillaUpdate(VailaUpdteDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _vilaService.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            return View(model);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> VillaDelete(int villaId)
        {
            if (ModelState.IsValid)
            {
                var response = await _vilaService.GetAsync<APIResponse>(villaId);
                if (response != null && response.IsSuccess)
                {
                    VailaDto model = JsonConvert.DeserializeObject<VailaDto>(Convert.ToString(response.Result));
                    return View(model);
                }
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VillaDelete(VailaDto model)
        {

            var response = await _vilaService.DeleteAsync<APIResponse>(model.Id);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(IndexVilla));
            }
            return View(model);
        } 
        #endregion
    }
}
