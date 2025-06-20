
using Microsoft.EntityFrameworkCore;
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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
