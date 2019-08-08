using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Rbac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Dist.Controllers
{
    public class BaseController : global::Admin.Api.Controllers.BaseController
    {
        //protected readonly CacheHelper cacheHelper;

        public BaseController(BaseDbContext db) : base(db)
        {
        }

        //public BaseController(BaseDbContext db, CacheHelper cacheHelper) : base(db)
        //{
        //    this.cacheHelper = cacheHelper;
        //}
    }
}