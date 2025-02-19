using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_CRUD.Attributes;

namespace MVC_CRUD.ViewModels
{
    public class CreateGameFormVM:GameFormBaseVM
    {
      
        [AllowedExtensions(FileSettings.AllowedExtensions), ImageMaxSize(FileSettings.MaxFileSizeByte)]
        public IFormFile Cover {  get; set; }= default!;

    }
}
