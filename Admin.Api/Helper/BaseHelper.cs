using AutoMapper;
using Data.Rbac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Dist.Helper
{
    public abstract class BaseHelper
    {
        protected readonly BaseDbContext db;
        protected readonly IMapper mapper;
        protected readonly HelperWrapper helper;
        protected readonly CacheHelper cacheHelper;
        //protected readonly App settings;

        public BaseHelper(BaseDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public BaseHelper(BaseDbContext db, IMapper mapper, HelperWrapper helper)
        {
            this.db = db;
            this.mapper = mapper;
            this.helper = helper;
        }

        //public BaseHelper(BaseDbContext db, IMapper mapper, HelperWrapper helper, App settings)
        //{
        //    this.db = db;
        //    this.mapper = mapper;
        //    this.helper = helper;
        //    this.settings = settings;
        //}

        public BaseHelper(BaseDbContext db, IMapper mapper, HelperWrapper helper, CacheHelper cacheHelper)
        {
            this.db = db;
            this.mapper = mapper;
            this.helper = helper;
            this.cacheHelper = cacheHelper;
        }

        public BaseHelper(BaseDbContext db, HelperWrapper helper)
        {
            this.db = db;
            this.helper = helper;
        }

        public BaseHelper(BaseDbContext db, HelperWrapper helper, CacheHelper cacheHelper)
        {
            this.db = db;
            this.helper = helper;
            this.cacheHelper = cacheHelper;
        }

        public BaseHelper(BaseDbContext db)
        {
            this.db = db;
        }
        //public async Task<List<BaseAuthority>> GetBaseAuthority()
        //{
        //    return db.BaseAuthority.ToList();
        //}
        //public async Task<List<Operator>> GetOperator()
        //{
        //    return db.Operator.ToList();
        //}
        //public async Task<List<BaseCarParkType>> GetBaseCarParkType()
        //{
        //    return db.BaseCarParkType.ToList();
        //}
        //public async Task<List<BaseParkingGuideType>> GetBaseParkingGuideType()
        //{
        //    return db.BaseParkingGuideType.ToList();
        //}
        //public async Task<List<BaseOperationType>> GetBaseOperationType()
        //{
        //    return db.BaseOperationType.ToList();
        //}
        //public async Task<List<BaseSupervisionType>> GetBaseSupervisionType()
        //{
        //    return db.BaseSupervisionType.ToList();
        //}
        //public async Task<List<BaseCity>> GetBaseCity()
        //{
        //    return db.BaseCity.ToList();
        //}
        //public async Task<List<BaseTown>> GetBaseTown()
        //{
        //    return db.BaseTown.ToList();
        //}
    }
}
