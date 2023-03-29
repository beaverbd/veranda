using Veranda.Common.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddGrpcClientsConfig(builder.Environment);
builder.Services.AddUsersConnector(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
