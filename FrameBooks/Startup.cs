﻿using FrameBooks.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace FrameBooks
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FrameBooks", Version = "v1" });
            });
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("ServerConnection")));
        }

        //This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FrameBooks v1"));
            }

            app.UseHttpsRedirection();
        }
    }
}
