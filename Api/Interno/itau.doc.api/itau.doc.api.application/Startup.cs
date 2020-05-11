using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using itau.doc.api.core.Contracts.Dtos;
using itau.doc.api.core.Contracts.Repositories;
using itau.doc.api.core.Contracts.Services;
using itau.doc.api.core.Entities;
using itau.doc.api.core.Entities.Dtos;
using itau.doc.api.core.Services;
using itau.doc.api.core.Validators;
using itau.doc.api.data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace itau.doc.api.application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the dociner.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DBClubeSettings>(
              Configuration.GetSection(nameof(DBClubeSettings)));

            services.AddScoped<IDocService, DocService>();
            services.AddScoped<IValidator<Doc>, DocValidator>();
            services.AddScoped<IDocRepository, DocRepository>();

            services.AddSingleton<IDBClubeSettings>(sp =>
                sp.GetRequiredService<IOptions<DBClubeSettings>>().Value);
            //mapper
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Doc API",
                    Description = "API do serviço Doc.\n\nVersão v1" + ". <style>.models {display: none !important}</style>",
                    Contact = new OpenApiContact() { Name = "Monike Stephany", Email = "monikestephany@gmail.com", Url = new Uri("https://www.linkedin.com/monike-stephany-developer/") }
                });

            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Doc API");
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
