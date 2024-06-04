
using AutoMapper;
using MediManage.Application.Services.Implementation;
using MediManage.Application.Services.Interfaces;
using MediManage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace MediManage.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var configuration = builder.Configuration;
            var connectionString = configuration.GetConnectionString("MediManage");

            builder.Services.AddDbContext<MediManageContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddControllers();


            //Auto Mapper
            //IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            //builder.Services.AddSingleton(mapper);
            //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            builder.Services.AddScoped<IPacienteServices, PacienteServices>();
            builder.Services.AddScoped<IServicoServices, ServicoServices>();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}