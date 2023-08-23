var builder = WebApplication.CreateBuilder(args);

//Serviços de controller
builder.Services.AddControllers();

var app = builder.Build();

//Mapeamento dos controllers
app.MapControllers();

app.Run();