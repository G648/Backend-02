using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Servi�os de controller
builder.Services.AddControllers();

//adiciona o serci�o de swagger
//adiciona informa��es sobre nossa API que estamos desenvolvendo
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Film Creation",
        Description = "An ASP.NET Core Web API for film managing - Introduction of Sprint 02 - BackEnd API ",
        Contact = new OpenApiContact
        {
            Name = "Guilherme Amorim - Senai Info",
            Url = new Uri("https://github.com/G648")
        }
    });

    //configura o Swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

//Aqui come�a a configura��o do swagger 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
//finaliza a configura��o do swagger

//Mapeamento dos controllers
app.MapControllers();

app.Run();

