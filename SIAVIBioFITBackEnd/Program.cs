
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SiaviBioFit.Shared.Services;
using SIAVIBioFITBackEnd;
using SIAVIBioFITBackEnd.Data;
using SIAVIBioFITBackEnd.Services;

namespace SIAVIBioFITBackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BioFitContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<SessionService>();
            builder.Services.AddScoped<ExerciseService>();
            builder.Services.AddScoped<ExerciseLogService>();

            // Configura CORS (permite chamadas de qualquer origem)
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Adiciona controladores
            builder.Services.AddControllers();

            // Ativa Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Isep API", Version = "v1" });

                // Define servidor base do Swagger
#if DEBUG
                c.AddServer(new OpenApiServer { Url = "http://localhost:8080" });
#else
                c.AddServer(new OpenApiServer { Url = "https://siavibiofit-backend.onrender.com/" });
#endif

            });

            var app = builder.Build();

            // Força a API a ouvir em http://localhost:8080
            //app.Urls.Add("http://localhost:8080");
            //app.Urls.Add("http://0.0.0.0:8080");


            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();

            

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
