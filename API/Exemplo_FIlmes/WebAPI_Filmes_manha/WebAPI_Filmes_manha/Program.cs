var builder = WebApplication.CreateBuilder(args);

//Servi�os de controller
builder.Services.AddControllers();

//adiciona o serci�o de swagger
builder.Services.AddSwaggerGen();

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

