using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using IdentityServer4.AccessTokenValidation;
using itau.ted.ext.api.core;
using itau.ted.ext.api.core.Contracts;
using itau.ted.ext.api.core.Entities;
using itau.ted.ext.api.core.Entities.Dtos;
using itau.ted.ext.api.core.Services;
using itau.ted.ext.api.core.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace itau.ted.ext.api.application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the tediner.
        public void ConfigureServices(IServiceCollection services)
        {   
            services.Configure<RabbitConfiguration>(
         Configuration.GetSection(nameof(RabbitConfiguration)));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Ted API Externa",
                    Description = "API do serviço Ted Externa.\n\nVersão v1" + ". <style>.models {display: none !important}</style>",
                    Contact = new OpenApiContact() { Name = "Monike Stephany", Email = "monikestephany@gmail.com", Url = new Uri("https://www.linkedin.com/monike-stephany-developer/") }
                });
            });

            services.AddSingleton<IRabbitConfiguration>(sp =>
            sp.GetRequiredService<IOptions<RabbitConfiguration>>().Value);

            services.AddScoped<IRabbitService, RabbitService>();
            services.AddScoped<IValidator<Ted>, TedValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ted API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
