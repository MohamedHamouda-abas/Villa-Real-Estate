using MagicVila_Web.Models;
using MagicVila_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace MagicVila_Web.VM
{
    public class VillaNumberCreateVM
    {
        public VillaNumberCreateVM()
        {
            VailaNumber = new VailaNumberCreateDto();
        }
        public VailaNumberCreateDto VailaNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Vailalist { get; set; }
    }
}
