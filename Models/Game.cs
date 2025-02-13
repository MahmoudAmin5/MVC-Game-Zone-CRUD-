

namespace MVC_CRUD.Models
{
    public class Game:BaseEntity
    {
        [MaxLength(2050)]
        public string Description { get; set; }=string.Empty;
        [MaxLength(250)]
        public string Cover { get; set; }=string.Empty;
        public int CategoryID {  get; set; }

        public Category Category { get; set; } = default!;
        public ICollection<GameDevice> Devices { get; set; }= new List<GameDevice>();

    }
}
