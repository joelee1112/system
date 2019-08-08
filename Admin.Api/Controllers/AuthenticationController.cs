using Admin.Helper;
using Data.Rbac;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Admin.Dist.Controllers
{
    public class AuthenticationController : Api.Controllers.AuthenticationController
    {
        public AuthenticationController(BaseDbContext db, SignInManager<Users> SignInManager, UserManager<Users> UserManager, IConfiguration config, AppSettings appSettings, UserHelper userHelper, RoleHelper roleHelper, MailHelper mailHelper) : base(db, SignInManager, UserManager, config, appSettings, userHelper, roleHelper, mailHelper)
        {
        }
    }
}