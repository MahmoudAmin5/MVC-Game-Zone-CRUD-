namespace MVC_CRUD.Services
{
    public interface IGameServices
    {
        public IEnumerable<Game> GetAll();
        public Task CreateGame(CreateGameFormVM VM);
       
    }
}
