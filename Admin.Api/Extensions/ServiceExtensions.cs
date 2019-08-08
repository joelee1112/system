using Admin.Dist.Helper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Dist.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureHelpers(this IServiceCollection services)
        {
            services.AddScoped<HelperWrapper>();
            services.AddSingleton<CacheHelper>();
            services.AddAutoMapper();
        }
    }
}
