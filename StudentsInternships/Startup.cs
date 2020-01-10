using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentsInternships.Data;
using StudentsInternships.Data.Repositories;

namespace CoreCodeCamp
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigin = "_myAllowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InternHuntContext>();
            services.AddScoped<IUserRepository, UsersRepository>();
            services.AddScoped<IInternshipsRepository, InternshipsRepository>();
            services.AddScoped<IApplicationsRepository, ApplicationsRepository>();
            services.AddScoped<ICompaniesRepository, CompaniesRepository>();
            services.AddScoped<IStudentsRepository, StudentsRepository>();
            services.AddScoped<ICitiesRepository, CitiesRepository>();


            services.AddAutoMapper(typeof(Startup));

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigin,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            services.AddMvc()
              .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
              .AddMvcOptions(o=>o.EnableEndpointRouting=false);
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseCors(MyAllowSpecificOrigin);
            app.UseMvc();
        }
    }
}
