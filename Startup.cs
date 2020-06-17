using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

using LyrnicsDotnetCore.Repository;
using LyrnicsDotnetCore.Repository.Implementations;
using LyrnicsDotnetCore.Model.Context;

using LyrnicsDotnetCore.Business;
using LyrnicsDotnetCore.Business.Implementations;

namespace LyrnicsDotnetCore
{
    public class Startup
    {
        IConfiguration Configuration {get;}
        
        // Load configuration infos from appsetings.json
        public Startup( IConfiguration configuration ){
            this.Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews( o => {
                o.UseGeneralRoutePrefix( "api" );
            } );
            //Loads the value from appsettings.json
            var connection = Configuration["PosgresConnection:PosgresConnectionString"];
            services.AddDbContext<LyrnicsDBContext>( options => options.UseNpgsql( connection ) );
            
            services.AddScoped<IArtistBusiness, ArtistBusinessImpl>();
            services.AddScoped<IArtistRepository, ArtistRepositoryImpl>();
            services.AddScoped<ISongBusiness, SongBusinessImpl>();
            services.AddScoped<ISongRepository, SongRepositoryImpl>();

            services.AddScoped( typeof(IGenericRepository<>), typeof(GenericRepository<>) );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints( endpoints => {
                endpoints.MapControllers();
                
                endpoints.MapGet("/", async context =>
                {
                     await context.Response.WriteAsync("Hello Lyrnics!");
                });
            });
        }
    }//END class

    public static class MvcOptionsExtensions {
        public static void UseGeneralRoutePrefix(this MvcOptions opts, IRouteTemplateProvider routeAttribute)
        {
            opts.Conventions.Add(new RoutePrefixConvention(routeAttribute));
        }

        public static void UseGeneralRoutePrefix(this MvcOptions opts, string 
        prefix)
        {
            opts.UseGeneralRoutePrefix(new RouteAttribute(prefix));
        }
    }//END class

    public class RoutePrefixConvention : IApplicationModelConvention {
        private readonly AttributeRouteModel _routePrefix;

        public RoutePrefixConvention(IRouteTemplateProvider route)
        {
            _routePrefix = new AttributeRouteModel(route);
        }

        public void Apply(ApplicationModel application)
        {
            foreach (var selector in application.Controllers.SelectMany(c => c.Selectors))
            {
                if (selector.AttributeRouteModel != null)
                {
                    selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(_routePrefix, selector.AttributeRouteModel);
                }
                else
                {
                    selector.AttributeRouteModel = _routePrefix;
                }
            }
        }
    }//END class RoutePrefixConvention()
}//END namespace
