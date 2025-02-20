



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
            var CoverName = await SaveCover(VM.Cover);
           
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

        public bool DeleteGame(int id)
        {
            var IsDeleted = false;
            var game=_dbcontext.Games.Find(id);
            if(game is null)
                return IsDeleted;
            _dbcontext.Remove(game);
            var EffectedRows = _dbcontext.SaveChanges();
            if (EffectedRows > 0)
            {
                IsDeleted = true;
                var cover=Path.Combine(ImagePath,game.Cover);
                File.Delete(cover);
            }
            return IsDeleted;
        }

        public async Task<Game?> EditGame(EditGameFormVM VM)
        {
            var game = _dbcontext.Games.Include(d => d.Devices)
                 .SingleOrDefault(d => d.ID==VM.id);
            var OldCover = game.Cover;
            if(game is null)
                return null;
            //Mapping 
            game.Name = VM.Name;
            game.Description = VM.Description;
            game.CategoryID = VM.CategoryID;
            game.Devices=VM.SelectedDevices.Select(d => new GameDevice { DeviceId=d}).ToList();
            if(VM.Cover is not null)
            {
                game.Cover= await SaveCover(VM.Cover);
            }
            var EffectedRowes = _dbcontext.SaveChanges();
            if (EffectedRowes>0)
            {
                if (VM.Cover is not null) {
                    var cover = Path.Combine(ImagePath, OldCover);
                    File.Delete(cover);
                }
                return game;
            }
            else
            {
                var cover = Path.Combine(ImagePath,game.Cover);
                File.Delete(cover);
                return null;

            }

           
        }

        public IEnumerable<Game> GetAll()
        {
           return _dbcontext.Games.Include(g=>g.Category).Include(g=>g.Devices).ThenInclude(d=>d.Device).AsNoTracking().ToList();
        }

        public Game? GetGameByID(int id)
        {
            return _dbcontext.Games.Include(g => g.Category).Include(g => g.Devices).ThenInclude(d => d.Device).AsNoTracking().SingleOrDefault(g=>g.ID==id);
        
    }
        private async Task<String> SaveCover(IFormFile cover)
        {
            var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            var CoverPath = Path.Combine(ImagePath, CoverName);
            using var Stream = File.Create(CoverPath);
            await cover.CopyToAsync(Stream);
            return CoverName;
        }
    }
}
