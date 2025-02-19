using MVC_CRUD.Attributes;

namespace MVC_CRUD.ViewModels
{
    public class EditGameFormVM:GameFormBaseVM
    {
        public int id {  get; set; } 
        public string? CurrentCover {  get; set; }
        [AllowedExtensions(FileSettings.AllowedExtensions), ImageMaxSize(FileSettings.MaxFileSizeByte)]
        public IFormFile? Cover { get; set; } = default!;
    }
}
