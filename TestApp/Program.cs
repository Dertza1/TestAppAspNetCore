
using TestApp.Repositories.IRepository;
using TestApp.Repositories.Repository;
using TestApp.Services.IService;
using TestApp.Services.Service;

namespace TestApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.


        builder.Services.AddControllers();

        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IMessageService, MessageService>();

        builder.Services.AddTransient<IUserRepository, UserRepository>();
        builder.Services.AddTransient<IMessageRepository, MessageRepository>();



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