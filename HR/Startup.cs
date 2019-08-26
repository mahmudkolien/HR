using AutoMapper;
using HR.Mapping;
using HR.Models;
using HR.Core;
using HR.Repository;
using HR.Repository.Context;
using HR.Repository.Contracts;
using HR.Services;
using HR.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http.Features;

namespace HR
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
            services.Configure<PhotoSettings>(Configuration.GetSection("PhotoSettings"));
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRoleService, UserRoleService>();
            services.AddTransient<IPhotoStorage, FileSystemPhotoStorage>();

            //Department
            services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            services.AddScoped<IUnitOfWork,DepartmentUnitOfWork>();
            services.AddTransient<IDepartmentService,DepartmentService>();
            //Company
            services.AddScoped<ICompanyRepository,CompanyRepository>();
            services.AddScoped<IUnitOfWork,DepartmentUnitOfWork>();
            services.AddTransient<ICompanyService,CompanyService>();
            //Branch
            services.AddScoped<IBranchRepository,BranchRepository>();
            services.AddScoped<IUnitOfWork,BranchUnitOfWork>();
            services.AddTransient<IBranchService,BranchService>();
            
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));
            services.AddDbContext<HRDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.Configure<FormOptions>(x => {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = long.MaxValue;
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
