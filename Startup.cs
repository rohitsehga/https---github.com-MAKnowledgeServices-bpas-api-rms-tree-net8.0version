 
using HealthChecks.System;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ResourceRequestService.Configuration;
using ResourceRequestService.Data;
using ResourceRequestService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Connection = Microsoft.EntityFrameworkCore.DbLoggerCategory.Database.Connection;

namespace ResourceRequestService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var RepositoryDbContextName = typeof(RepositoryDbContext).Assembly.GetName().Name;
            services.AddDbContext<RepositoryDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Repository"), x => x.MigrationsAssembly(RepositoryDbContextName)));

            var EDMRepositoryDbContextName = typeof(EDMDbContext).Assembly.GetName().Name;
            services.AddDbContext<EDMDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EDMRepository"), x => x.MigrationsAssembly(EDMRepositoryDbContextName)));

            var ServiceManagementDbContextName = typeof(ServiceManagementDbContext).Assembly.GetName().Name;
            services.AddDbContext<ServiceManagementDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ServiceManagementRepository"), x => x.MigrationsAssembly(ServiceManagementDbContextName)));

            var CustomerFeedbackDbContextName = typeof(CustomerFeedbackDbContext).Assembly.GetName().Name;
            services.AddDbContext<CustomerFeedbackDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CustomerFeedbackRepository"), x => x.MigrationsAssembly(CustomerFeedbackDbContextName)));


            services.Configure<Connection>(Configuration.GetSection("connectionStrings"));
            services.Configure<OktaSettings>(Configuration.GetSection("Okta"));


            //services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RMS API", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup));
            //services.AddCors();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers();
            int space = Convert.ToInt32(Configuration.GetValue<string>("Drive:space"));
            string drive = Configuration.GetValue<string>("Drive:path");
            //string hostedUrl = Configuration.GetValue<string>("HostUrl:Uri");
            drive = drive + @":\";
            services.AddHealthChecks()
          .AddDbContextCheck<RepositoryDbContext>() //nuget: Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore
          .AddApplicationInsightsPublisher()
          .AddDiskStorageHealthCheck(setup: delegate (DiskStorageOptions diskStorageOptions)
          {
              diskStorageOptions.AddDrive(drive, minimumFreeMegabytes: space);
              //5000


          }, name: "My Drive", HealthStatus.Unhealthy); //nuget: AspNetCore.HealthChecks.Publisher.ApplicationInsights

            //services.AddHealthChecksUI(s =>
            //{
            //    //s.SetEvaluationTimeInSeconds(10);
            //    //s.MaximumHistoryEntriesPerEndpoint(30);
            //    //s.SetApiMaxActiveRequests(1);
            //    //s.AddHealthCheckEndpoint("Resource Request Micro service", "http://10.50.5.120:3031/healthcheck");
            //}).AddInMemoryStorage();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseSwagger();
            //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "RMS API v2"));

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("./v1/swagger.json", "RMS API v1"); });

            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
.AllowAnyHeader()
               );

            app.UseAuthorization();
           // app.UseMiddleware<AuthMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapHealthChecksUI(setup =>
                //{
                //    setup.AddCustomStylesheet("./Customization/Custom.css");
                //});
                endpoints.MapControllers();
                // endpoints.MapHealthChecks("/health");
            });
            app.UseHealthChecks("/healthcheck", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse //nuget: AspNetCore.HealthChecks.UI.Client
            });

            //nuget: AspNetCore.HealthChecks.UI

            //app.UseHealthChecksUI(options =>
            //{
            //    options.UIPath = "/healthchecks-ui";
            //    options.ApiPath = "/health-ui-api";
            //    options.AddCustomStylesheet("./wwwroot/Customization/StyleSheets.css");

            //});
        }
    }

}
