using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Flashcard.Infrastructure.MongoDb;
using FlashCard.BusinessLogic;
using Flashcard.AppServices.APIs.Filters;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Routing;
using AutoMapper;
using Flashcard.AppServices.APIs.Configs;
using FlashCard.Models.Domains;
using Microsoft.AspNetCore.Identity;
using FlashCard.Domains.Services;

namespace FlashcardAPIs
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
            services.AddMvc(mvcOptions => mvcOptions.Filters.Add(new GlobalExceptionFilterAttribute()));
            services.AddMvc();

            services.AddSingleton<IMongoDbWriteRepository>(sp =>
            {
                return new MongoDbWriteRepository("mongodb://interns2:interns2@ds117485.mlab.com:17485/interns2");
            });

            //services.AddSingleton<FlashcardBusinessLogic>();
            services.AddSingleton<IFlashcardBusinessLogic, FlashcardBusinessLogic>();

            

            services.AddSingleton<IMapper>(new Mapper(AutoMapperConfiguration.RegisterMapper()));


            services.AddIdentity<User, Role>(
                identityOptions =>
                {
                    // Email settings
                    identityOptions.User.RequireUniqueEmail = true;

                    // Password settings
                    identityOptions.Password.RequiredLength = 8;
                    identityOptions.Password.RequireDigit = false;
                    identityOptions.Password.RequireNonAlphanumeric = false;
                    identityOptions.Password.RequireUppercase = false;
                    identityOptions.Password.RequireLowercase = false;

                    // Lockout settings
                    identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                    identityOptions.Lockout.MaxFailedAccessAttempts = 10;

                    // Cookie settings
                    //identityOptions.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(365);
                    //identityOptions.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
                    //identityOptions.Cookies.ApplicationCookie.LogoutPath = "/Account/Logout";
                })
                .AddDefaultTokenProviders();

            services.AddSingleton<IUserService, UserService>();
            // Add Cors
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyPolicy");
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();

        }
    }
}
