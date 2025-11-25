using AlmacenS.Core.Interfaces;
using AlmacenS.Infrastructure.Data;
using AlmacenS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var url = Environment.GetEnvironmentVariable("DATABASE");
Console.WriteLine($"La cadena de coneccion es esta: {url}");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AlmacenSContext>(options =>
    options.UseNpgsql(url)
);

builder.WebHost.UseUrls("http://0.0.0.0:8080");

builder.Services.AddHttpClient();

builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IInventarioEntradaRepository, InventarioEntradaRepository>();
builder.Services.AddScoped<ICargaProductoRepository, CargaProductoRepository>();
builder.Services.AddScoped<IDevolucionProductoRepository, DevolucionProductoRepository>();
builder.Services.AddScoped<IAlertaReabastecimientoRepository, AlertaReabastecimientoRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AlmacenSContext>();
    dbContext.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();
