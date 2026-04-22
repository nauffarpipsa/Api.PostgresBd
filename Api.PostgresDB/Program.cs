using Analysis.Services.Contract;
using Analysis.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.Contract;
using Repository.Implementation;
using Services.Contract;
using Services.Implementation;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Configurar Swagger para mostrar el entorno actual
builder.Services.AddSwaggerGen(c =>
{
    var useTestDb = builder.Configuration.GetValue<bool>("DatabaseConfig:UseTestDatabase");
    string envLabel = useTestDb ? "TEST (Nauffar)" : "PROD (Nauffar)";
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = $"Api.PostgresDB - {envLabel}",
        Version = "v1",
        Description = $"Actualmente conectado a base de datos de: **{envLabel}**"
    });
});


// Add services 
builder.Services.AddTransient(typeof(IGeneric<>), typeof(Generic<>));
builder.Services.AddScoped<IAccess, AccessService>();
builder.Services.AddScoped<IODataLink, ODataLinkService>();
builder.Services.AddScoped<IRequestOData, RequestOData>();
builder.Services.AddScoped<ITask, TaskService>();
builder.Services.AddScoped<ISupplierBanckAccount, SupplierBanckAccountServices>();
builder.Services.AddScoped<IMaestro_Historial_Tasas, Maestro_Historial_TasasServices>();
builder.Services.AddScoped<ISAP_Maestro_Bancos, SAP_Maestro_BancosServices>();
builder.Services.AddScoped<ISap_Maesto_Purchase_Orders, Sap_Maesto_Purchase_OrdersService>();
builder.Services.AddScoped<ISAPMaestroPrestamos, SAP_Maestro_PrestamosServices>();
builder.Services.AddScoped<IMaestro_Lineas_Credito, Maestro_Lineas_CreditoService>();
builder.Services.AddScoped<ICreditoCatalogo, CatalogoCreditoService>();
builder.Services.AddScoped<IMaestro_Cuota_Tipos, Maestro_Cuota_TiposService>();
builder.Services.AddScoped<ICondiciones, CondicionesService>();
builder.Services.AddScoped<IMaestro_Amortizaciones, Maestro_AmortizacionesServices>();
builder.Services.AddScoped<ISap_Maestro_Cuentas_Bancarias, SapMaestroCuentasBancariasServices>();

//DbContext
builder.Services.AddDbContext<applicationDbContext>((serviceProvider, options) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    bool useTestDb = configuration.GetValue<bool>("DatabaseConfig:UseTestDatabase");
    string connectionStringKey = useTestDb ? "Postgres_Test" : "Postgres_Prod";
    string? connectionString = configuration.GetConnectionString(connectionStringKey);

    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException($"La cadena de conexión '{connectionStringKey}' no se encontró.");
    }

    // Opcional: Log para saber a qué BD se está conectando (útil para debug)
    Console.WriteLine($"[INFO] Conectando a Base de Datos: {(useTestDb ? "PRUEBA" : "PRODUCCIÓN")} ({connectionStringKey})");

    options.UseNpgsql(connectionString);
});


var app = builder.Build();


//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
