
using Microsoft.EntityFrameworkCore;

namespace MVC_CRUD.Services
{
    public class DevicesServices : IDevicesServices
    {
        private readonly AppDbcontext _dbcontext;
        public DevicesServices(AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IEnumerable<SelectListItem> GetListItems()
        {
            return _dbcontext.Devices.
                Select(c => new SelectListItem() { Value = c.ID.ToString(), Text = c.Name }).
                OrderBy(c => c.Text)
                .AsNoTracking()
                .ToList();
        }
    }
}
