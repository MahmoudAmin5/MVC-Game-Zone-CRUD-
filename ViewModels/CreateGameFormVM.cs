namespace MVC_CRUD.ViewModels
{
    public class CreateGameFormVM
    {
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }= string.Empty;
        public int CategoryID { get; set; }
        public List<int> SelectedDevices { get; set; }= new List<int>();
        public IFormFile Cover {  get; set; }= default!;

    }
}
