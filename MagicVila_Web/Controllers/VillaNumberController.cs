using AutoMapper;
using MagicVila_Web.APIResponses;
using MagicVila_Web.Models.Dto;
using MagicVila_Web.Services.IServices;
using MagicVila_Web.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Montview_Web.Services;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MagicVila_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVilaNumberService _vilaNumberService;
        private readonly IVilaService _vilaService;
        private readonly IMapper _mapper;

        public VillaNumberController(IVilaNumberService vilaNumberService, IMapper mapper, IVilaService vilaService)
        {
            _vilaNumberService = vilaNumberService;
            _vilaService = vilaService;
            _mapper = mapper;
        }
        #region GetAll
        public async Task<IActionResult> IndexVilla()
        {
            List<VailaNumberDto> list = new();
            var response = await _vilaNumberService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VailaNumberDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        #endregion

        #region Create
        public async Task<IActionResult> VillaNumberCreate()
        {
            VillaNumberCreateVM listvm = new();
            var response = await _vilaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                listvm.Vailalist = JsonConvert.DeserializeObject<List<VailaDto>>
                 (Convert.ToString(response.Result)).Select(i => new SelectListItem
                 {
                     Text = i.Name,
                     Value = i.Id.ToString()
                 });
            }
            return View(listvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VillaNumberCreate(VillaNumberCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _vilaNumberService.CreateAsync<APIResponse>(model.VailaNumber);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }
                else
                {
                    if((response.ErrorMessage.Count > 0))
                    {
                        ModelState.AddModelError("ErrorMessage",response.ErrorMessage.FirstOrDefault());
                    }
                    
                }

                var res = await _vilaService.GetAllAsync<APIResponse>();
                if (res != null && res.IsSuccess)
                {
                    model.Vailalist = JsonConvert.DeserializeObject<List<VailaDto>>
                     (Convert.ToString(res.Result)).Select(i => new SelectListItem
                     {
                         Text = i.Name,
                         Value = i.Id.ToString()
                     });
                }
            }
            return View(model);
        }
        #endregion

        //#region Update
        //public async Task<IActionResult> VillaUpdate(int villaId)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _vilaService.GetAsync<APIResponse>(villaId);
        //        if (response != null && response.IsSuccess)
        //        {
        //            //VailaDto[] models = JsonConvert.DeserializeObject<VailaDto[]>(Convert.ToString(response.Result));
        //            VailaDto model = JsonConvert.DeserializeObject<VailaDto>(Convert.ToString(response.Result));
        //            return View(_mapper.Map<VailaUpdteDto>(model));
        //        }
        //    }
        //    return NotFound();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> VillaUpdate(VailaUpdteDto model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _vilaService.UpdateAsync<APIResponse>(model);
        //        if (response != null && response.IsSuccess)
        //        {
        //            return RedirectToAction(nameof(IndexVilla));
        //        }
        //    }
        //    return View(model);
        //}
        //#endregion

        //#region Delete
        //public async Task<IActionResult> VillaDelete(int villaId)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _vilaService.GetAsync<APIResponse>(villaId);
        //        if (response != null && response.IsSuccess)
        //        {
        //            VailaDto model = JsonConvert.DeserializeObject<VailaDto>(Convert.ToString(response.Result));
        //            return View(model);
        //        }
        //    }
        //    return NotFound();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> VillaDelete(VailaDto model)
        //{

        //    var response = await _vilaService.DeleteAsync<APIResponse>(model.Id);
        //    if (response != null && response.IsSuccess)
        //    {
        //        return RedirectToAction(nameof(IndexVilla));
        //    }
        //    return View(model);
        //}
        //#endregion
    }
}
