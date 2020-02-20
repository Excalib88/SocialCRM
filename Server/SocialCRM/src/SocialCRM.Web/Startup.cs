using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SocialCRM.DAL;
using SocialCRM.DAL.Entities;
using SocialCRM.DAL.Repositories;
using SocialCRM.Domain.Abstractions;
using SocialCRM.Domain.Services;

namespace SocialCRM.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(
                    new SlugifyParameterTransformer()));
                options.Filters.Add(new ErrorFilter());
            });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SocialCRM API", Version = "v1" });
            });
            
            services.AddDbContext<DataContext>(options =>
            {
                options
                    .UseNpgsql(_configuration.GetConnectionString("DefaultConnection"),
                        assembly =>
                            assembly.MigrationsAssembly("SocialCRM.DAL.Migrations"));
            });
            
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IDbRepository, DbRepository>();
            services.AddTransient<ILeadService, LeadService>();
            services.AddSingleton(new UserEntity{Id = Guid.Empty});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseRouting();
            app.UseAuthorization();
            
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Social CRM API v1");
                x.RoutePrefix = "swagger";
            });
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
        
        public class SlugifyParameterTransformer : IOutboundParameterTransformer
        {
            public string TransformOutbound(object value) => value == null ? null : 
                Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
        }
    
        public class ErrorFilter : ExceptionFilterAttribute
        {
            public override async Task OnExceptionAsync(ExceptionContext context)
            {
                var exception = context.Exception;
                var response = $"{{\"error\": \"{exception.Message}{exception.InnerException?.Message}\"}}";
                await using var responseWriter = new StreamWriter(context.HttpContext.Response.Body, Encoding.UTF8);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.HttpContext.Response.ContentType = "application/json; charset=utf-8";
                context.HttpContext.Response.ContentLength = Encoding.UTF8.GetBytes(response).Length + 3;
                await responseWriter.WriteAsync(response);
            }
        }
    }
}