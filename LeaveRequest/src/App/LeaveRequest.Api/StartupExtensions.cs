using LeaveRequest.Persistence;
using LeaveRequest.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.WebAssembly.Services;

namespace LeaveRequest.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(
           this WebApplicationBuilder builder)
        {
            
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddResponseCaching();
            builder.Services.AddResponseCompression(cfg =>
            {
                cfg.EnableForHttps = true;
            });
            builder.Services.AddControllers(cfg =>
            {
                cfg.RespectBrowserAcceptHeader = true;
            }).AddNewtonsoftJson(cfg =>
            {
                cfg.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }).AddXmlSerializerFormatters();         

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, c =>
            {
                c.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
                c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidAudience = builder.Configuration["Auth0:Audience"],
                    ValidIssuer = $"https://{builder.Configuration["Auth0:Domain"]}"
                };
            });
           // builder.Services.AddScoped<LazyAssemblyLoader>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            return builder.Build();

        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            app.UseHttpsRedirection();
              app.UseBlazorFrameworkFiles();            
              app.UseStaticFiles();
              app.UseCors("open");
              app.UseResponseCaching();
              app.UseResponseCompression();
              app.UseAuthentication();
              app.UseAuthorization();            
              app.UseRouting();
              app.MapControllers();
              app.MapFallbackToFile("index.html");

           
            return app;

        }
       

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<LeaveRequestDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }
}