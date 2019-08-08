using Admin.Helper;
using Data.Rbac;
using Microsoft.AspNetCore.Hosting;

namespace Admin.Dist.Controllers
{
    public class ContentsController : Api.Controllers.ContentsController
    {
        public ContentsController(BaseDbContext db, IHostingEnvironment hostingEnvironment, AppSettings appSettings) : base(db, hostingEnvironment, appSettings)
        {
        }
    }
}