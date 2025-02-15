using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_CRUD.ViewModels
{
    public class CreateGameFormVM
    {
        public string Name { get; set; }=string.Empty;
        [Display(Name="Category")]
        public int CategoryID { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } =  Enumerable.Empty<SelectListItem>();
        [Display(Name = "Supported Devices")]
        public List<int> SelectedDevices { get; set; }= default!;
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
        public string Description { get; set; } = string.Empty;
        public IFormFile Cover {  get; set; }= default!;

    }
}
