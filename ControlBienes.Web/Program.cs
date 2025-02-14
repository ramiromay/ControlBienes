using ControlBienes.Business;
using ControlBienes.Web.Middleware;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuracion de servicios
builder.Services.BRegistrarServiciosApp(builder.Configuration);




// Configuracion de CORS
builder.Services.AddCors(options =>
{
     options.AddPolicy("CorsPolicy", policy =>
     {
          policy.WithOrigins("http://localhost:5173", "http://localhost:5174") // Dominio del cliente permitido
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials(); // Permite el uso de credenciales
     });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Configuracion de Cookie
// app.UseCookiePolicy();

// Configuracion uso de Autentificacion con JWT
app.UseAuthentication();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
