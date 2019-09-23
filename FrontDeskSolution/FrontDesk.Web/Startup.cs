using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using ClientPatientManagement.Core.Interfaces;
using ClientPatientManagement.Core.Model;
using ClientPatientManagement.Data;
using Microsoft.EntityFrameworkCore;
using AppointmentScheduling.Data;
using VetOffice.SharedDatabase.DataModel;
using AppointmentScheduling.Data.Repositories;
using AppointmentScheduling.Core.Interfaces;
using FrontDesk.Web.Models;

namespace FrontDesk.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRepository<Client>, Repository<Client>>();
            services.AddScoped<IApplicationSettings, OfficeSettings>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            // services.AddScoped<IOrderingService, WebSiteOrderingService>();
            // services.AddScoped<IOrderData, WebSiteOrderData>();

            services.AddDbContext<CrudContext>(o => o.UseMySql("Server=localhost;Port=3306;Database=fundamentals;Uid=gbarska;Pwd=password;"));
            services.AddDbContext<SchedulingContext>(o => o.UseMySql("Server=localhost;Port=3306;Database=fundamentals;Uid=gbarska;Pwd=password;"));
            services.AddDbContext<VetOfficeContext>(o => o.UseMySql("Server=localhost;Port=3306;Database=fundamentals;Uid=gbarska;Pwd=password;"));
            services.AddMvc();

             services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("V1", new Info { Title = "Projeto API com Dapper", Version = "V1" });
            });
      
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
             if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "Test.Web.Api");
            }); 
        }
    }
}
