using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TASİNMAZ.Business.Abstract.Interfaces;
using TASİNMAZ.Business.Concrete.Services;
using TASİNMAZ.Business.Conrete.Services;
using TASİNMAZ.DataAccess.Conrete;

namespace TASİNMAZ
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
            // CORS politikalarını ekleyin
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                builder => builder.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader());
            });

            services.AddControllers();

            // PostgreSQL için Connection String'i al
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            // Swagger için ayarları yapın
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Taşınmaz API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            // DbContext'i ekleyin
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString)); // PostgreSQL için UseNpgsql kullanımı

            // JWT Authentication'ı ekleyin
            var key = Encoding.ASCII.GetBytes(Configuration["Appsettings:Token"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // Scoped servis kayıtları
            services.AddScoped<CityInterface, CityService>();
            services.AddScoped<DistrictInterface, DistrictService>();
            services.AddScoped<NeigborhoodInterface, NeigborhoodService>(); // 'NeigborhoodInterface' yerine 'NeighborhoodInterface'
            services.AddScoped<tasinmazInterface, TasinmazService>(); // 'tasinmazInterface' yerine 'TasinmazInterface'
            services.AddScoped<UserInterface, UserService>();
            services.AddScoped<AuthInterface, AuthService>();
            services.AddScoped<logInterface, LogService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts(); // HTTPS kullanımı
            }

            // CORS middleware'lerini ekleyin
            app.UseCors("AllowOrigin");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication(); // Authentication middleware'i ekleyin
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Taşınmaz API v1");
                // c.RoutePrefix = string.Empty; // Eğer Swagger UI'ı kök URL'de göstermek istiyorsanız bu satırı açın.
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}





