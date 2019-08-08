using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Rbac
{
    public class BaseDbInitializer
    {
        private readonly BaseDbContext db;

        public BaseDbInitializer(BaseDbContext db)
        {
            this.db = db;
        }

        public void Create()
        {
            db.Database.EnsureCreated();
        }

        public void Delete()
        {
            db.Database.EnsureDeleted();
        }

        public void Migrate()
        {
            db.Database.Migrate();
        }
    }
}