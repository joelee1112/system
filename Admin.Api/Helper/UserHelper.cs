using Admin.Dist.Configs;
using Admin.Helper.Extensions;
using Data.Rbac;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Dist.Helper
{
    public class UserHelper: BaseHelper
    {
        private readonly IHttpContextAccessor httpContextAccessor;
       // private readonly SignInHelper SignInHelper;
        //private readonly UserManager<Users> userManager;

        public UserHelper(IHttpContextAccessor httpContextAccessor, BaseDbContext db,  HelperWrapper helper) : base(db, helper)
        {
            this.httpContextAccessor = httpContextAccessor;
        
        }

        public Guid? UserId => httpContextAccessor.HttpContext.User.Claims.Find(TokenConfig.UserId).ToGuid();
        //public string UserName => httpContextAccessor.HttpContext.User.Claims.Find(ClaimTypes.Name);
        //public string NickName => httpContextAccessor.HttpContext.User.Claims.Find(TokenConfig.NickName);
        //public bool? AgreementStatus => httpContextAccessor.HttpContext.User.Claims.Find(TokenConfig.AgreementStatus).ToBool();
        //public bool? ReadOnly => httpContextAccessor.HttpContext.User.Claims.Find(TokenConfig.ReadOnly).ToBool();

      
        public async Task<List<Guid>> GetRoleIds()
        {
            var user = await db.Users.Include("UsersRoles").FirstAsync(a => a.Id == UserId);
            return user.UsersRoles.Select(a => a.RoleId).ToList();
        }
        public async Task<List<Roles>> GetRoles()
        {
            var user = await db.Users.Include("UsersRoles").FirstAsync(a => a.Id == UserId);
            var roleids = user.UsersRoles.Select(a => a.RoleId).ToList();
            return await db.Roles.Where(a => roleids.Contains(a.Id)).ToListAsync();
        }
        
    }
}
