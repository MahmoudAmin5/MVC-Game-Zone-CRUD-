


namespace MVC_CRUD.Services
{
    public class GameServices : IGameServices
    {
        private readonly AppDbcontext _dbcontext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly String ImagePath;
        public GameServices(AppDbcontext dbcontext, IWebHostEnvironment webHostEnvironment)
        {
            _dbcontext = dbcontext;
            _webHostEnvironment = webHostEnvironment;
            ImagePath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagePath}";
        }
        public async Task CreateGame(CreateGameFormVM VM)
        {
            // Saving The Cover Into Server 
            var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(VM.Cover.FileName)}";
            var CoverPath = Path.Combine(ImagePath, CoverName);
            using var Stream=File.Create(CoverPath);
            await VM.Cover.CopyToAsync(Stream);
            //Mapping the Model to Save in DataBase
            Game game = new Game()
            {
                Name = VM.Name,
                Description = VM.Description,
                CategoryID = VM.CategoryID,
                Cover = CoverName,
                Devices = VM.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList()
            };
            _dbcontext.Add(game);
            _dbcontext.SaveChanges();

        }
    }
}
