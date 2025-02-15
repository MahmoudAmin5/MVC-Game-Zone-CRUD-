
using Microsoft.EntityFrameworkCore;

namespace MVC_CRUD.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly AppDbcontext _dbcontext;
        public CategoryServices(AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public IEnumerable<SelectListItem> GetListItems()
        {
            return _dbcontext.Categories.
             Select(c => new SelectListItem() { Value = c.ID.ToString(), Text = c.Name }).
             OrderBy(c => c.Text)
             .AsNoTracking()
             .ToList();
        }
    }
}
