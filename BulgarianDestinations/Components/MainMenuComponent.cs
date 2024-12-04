using Microsoft.AspNetCore.Mvc;

namespace BulgarianDestinations.Components
{
    public class MainMenuComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
