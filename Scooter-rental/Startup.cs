using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Scooter_rental.Core.Interfaces;
using Scooter_rental.Core.Models;
using Scooter_rental.Data;
using Scooter_rental.Services;

namespace Scooter_rental
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Scooter_rental", Version = "v1" });
            });

            services.AddDbContext<ScooterRentalDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ScooterRental"));
            });

            services.AddScoped<IDbService, DbService>();
            services.AddScoped<IEntityService<Scooter>, EntityService<Scooter>>();
            services.AddScoped<IEntityService<RentedScooter>, EntityService<RentedScooter>>();
            services.AddScoped<IScooterRentalDbContext, ScooterRentalDbContext>();
            services.AddScoped<IScooterService, ScooterService>();
            services.AddScoped<IRentedScooterService, RentedScooterService>();
            services.AddScoped<ICalculators, Calculators>();
            services.AddScoped<IRentalCompanyService, RentalCompanyService>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200").AllowAnyHeader()
                            .AllowCredentials()
                            .AllowAnyMethod();
                    });
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Scooter_rental v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:4200").AllowAnyHeader()
                    .AllowCredentials()
                    .AllowAnyMethod();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
