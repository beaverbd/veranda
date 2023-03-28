using Microsoft.AspNetCore.Server.Kestrel.Core;
using Veranda.Common.Configuration;
using Veranda.Common.InitActions;
using Veranda.Common.InitActions.Abstractions;
using Veranda.Common.InitActions.Actions;
using Veranda.Service.User.Api.Data;
using Veranda.Service.User.Api.GrpcServices;
using Veranda.Service.User.Api.Mapper;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.ConfigureEndpointDefaults(defaults =>
    {
        defaults.Protocols = HttpProtocols.Http2;
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddPostgres<UsersDbContext>(builder.Configuration.GetConnectionString("UsersDb")!);
builder.Services.AddGrpc();
builder.Services.AddScoped<IInitAction, DbInitializer<UsersDbContext>>();
builder.Services.AddHostedService<Initializer>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGrpcService<UsersService>();
app.UseAuthorization();

app.MapControllers();
app.Run();
