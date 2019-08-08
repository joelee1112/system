using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Dist.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Admin.Dist
{
    public class Startup : Api.Startup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }
        public override void OnConfigureServices(IServiceCollection services)
        {
            services.ConfigureHelpers();
            //services.ConfigureCors();
            //services.ConfigureSwagger();
            //services.AddScoped<AzureStorageAL>();
            //services.AddHttpClient();
            //services.Configure<App>(a => Configuration.GetSection("AppSetting").Bind(a));

            //services.AddMvc(config =>
            //{
            //    config.Filters.Add<ExceptionFilter>();
            //});
        }
    }
}
