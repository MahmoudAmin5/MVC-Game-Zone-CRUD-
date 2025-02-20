
namespace MVC_CRUD.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IDevicesServices _devicesServices;
        private readonly IGameServices _gameServices;

        public GamesController(ICategoryServices categoryServices,IDevicesServices devicesServices, IGameServices gameServices)
        {
            _categoryServices = categoryServices;
            _devicesServices = devicesServices;
            _gameServices = gameServices;
        }

        public IActionResult Index()
        {
            var Games = _gameServices.GetAll();
            return View(Games);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormVM VM = new CreateGameFormVM()
            {
                Categories = _categoryServices.GetListItems(),
                Devices = _devicesServices.GetListItems()
            };
            return View(VM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormVM VM)
        {
            if (!ModelState.IsValid)
            {
                VM.Categories = _categoryServices.GetListItems();
                VM.Devices = _devicesServices.GetListItems();   
                return View(VM);
            }
            //save game into database 
            // save cover into the server 
           await _gameServices.CreateGame(VM);
             return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            var game=_gameServices.GetGameByID(id);
            if (game is null)
                return NotFound(); 
            return View(game);   
        }
        public IActionResult Edit(int id) { 
            var game= _gameServices.GetGameByID(id);
            if (game is null)
                return NotFound();
            EditGameFormVM VM = new() { 
              id = id,
              Categories = _categoryServices.GetListItems(),
              Devices = _devicesServices.GetListItems(),
               CategoryID = game.CategoryID,
               Description = game.Description,
                Name = game.Name,
                SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
                 CurrentCover = game.Cover
            };
            return View("Edit",VM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameFormVM VM)
        {
            if (!ModelState.IsValid)
            {
                VM.Categories = _categoryServices.GetListItems();
                VM.Devices = _devicesServices.GetListItems();
                return View(VM);
            }
            //save game into database 
            // save cover into the server 
           var game=await _gameServices.EditGame(VM);
            if (game is null)
                return BadRequest();
            return RedirectToAction(nameof(Index));
        }
         [HttpDelete]
        public IActionResult Delete(int id) {

            var IsDeleted=_gameServices.DeleteGame(id);
            
            return IsDeleted ? Ok() : BadRequest();
        }
    }
}
