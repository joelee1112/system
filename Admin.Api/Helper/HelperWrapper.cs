using AutoMapper;
using Data.Rbac;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Dist.Helper
{
    public class HelperWrapper
    {
        private readonly BaseDbContext db;
     
        private UserHelper _user;

 

        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly CacheHelper cacheHelper;
        public HelperWrapper(BaseDbContext db, IMapper mapper, IHttpContextAccessor httpContextAccessor, CacheHelper cacheHelper)
        {
            this.db = db;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.cacheHelper = cacheHelper;
        }
        public HelperWrapper(BaseDbContext db)
        {
            this.db = db;
        }
   
        public UserHelper User => _user = _user ?? new UserHelper(httpContextAccessor, db, this);



    }

}
