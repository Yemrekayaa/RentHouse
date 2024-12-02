using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto;

namespace RentHouse.WebUI.Areas.Admin.ViewComponents.Shared
{
    [ViewComponent]
    public class _PaginationViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PaginationDtoBase model)
        {
            return View(model);
        }
    }
}
