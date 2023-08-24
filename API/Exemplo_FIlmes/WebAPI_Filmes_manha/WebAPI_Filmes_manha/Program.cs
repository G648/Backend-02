var builder = WebApplication.CreateBuilder(args);

//Serviços de controller
builder.Services.AddControllers();

//adiciona o serciço de swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Aqui começa a configuração do swagger 
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
//finaliza a configuração do swagger

//Mapeamento dos controllers
app.MapControllers();

app.Run();

