namespace MVC_CRUD.Services
{
    public interface IGameServices
    {
        public IEnumerable<Game> GetAll();
        public Game? GetGameByID(int id);
        public Task CreateGame(CreateGameFormVM VM);
       
    }
}
