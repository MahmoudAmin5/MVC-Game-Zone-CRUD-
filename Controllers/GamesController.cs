
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

    }
}
