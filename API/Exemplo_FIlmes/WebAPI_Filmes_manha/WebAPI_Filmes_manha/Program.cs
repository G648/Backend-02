using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Serviços de controller
builder.Services.AddControllers();

//adiciona serviço JWT Bearer para autenticação 
builder.Services.AddAuthentication(options =>
    {
        options.DefaultChallengeScheme = "JwtBearer";
        options.DefaultAuthenticateScheme = "JwtBearer";
    })

    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //valida quem está solicitando
            ValidateIssuer = true,

            //valida quem está recebendo
            ValidateAudience = true,

            //define se o tempo de expiração será validado
            ValidateLifetime = true,

            //copiar a chave de autenticação utilizada no usuario controller, no qual definimos antes
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

            //valida o tempo de expiração do token
            ClockSkew = TimeSpan.FromMinutes(5),

            //nome do issuer: vindo do usuario controller (nome do projeto que estamos)
            ValidIssuer = "WebAPI_Filmes_manha",

            //nome do audience (para onde está indo)
            ValidAudience = "WebAPI_Filmes_manha"
        };
    });

//microserviços -> o que é ?

//adiciona o serciço de swagger
//adiciona informações sobre nossa API que estamos desenvolvendo
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

    //Usando a autenticaçao no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

});




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

//adiciona autenticação
app.UseAuthentication();

//adiciona autorização
app.UseAuthorization();

app.UseHttpsRedirection();

app.Run();

