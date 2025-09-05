using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Contract;
using Repository.Implementation;
using Services.Contract;
using Services.Implementation;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add services 
builder.Services.AddTransient(typeof(IGeneric<>), typeof(Generic<>));
builder.Services.AddScoped<IMaestro_Historial_Tasas, Maestro_Historial_TasasServices>();
builder.Services.AddScoped<ISAP_Maestro_Bancos, SAP_Maestro_BancosServices>();
builder.Services.AddScoped<ISap_Maesto_Purchase_Orders, Sap_Maesto_Purchase_OrdersService>();
builder.Services.AddScoped<ISAPMaestroPrestamos, SAP_Maestro_PrestamosServices>();
builder.Services.AddScoped<IMaestro_Lineas_Credito, Maestro_Lineas_CreditoService>();
builder.Services.AddScoped<ICreditoCatalogo, CatalogoCreditoService>();
builder.Services.AddScoped<IMaestro_Cuota_Tipos, Maestro_Cuota_TiposService>();
builder.Services.AddScoped<ICondiciones, CondicionesService>();
builder.Services.AddScoped<IMaestro_Amortizaciones, Maestro_AmortizacionesServices>();

//DbContext
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .AddKeyPerFile("/run/secrets", optional: true);

// Lee y valida la cadena
var conn = builder.Configuration.GetConnectionString("Postgres");
if (string.IsNullOrWhiteSpace(conn))
    conn = builder.Configuration["ConnectionStrings:Postgres"];
if (string.IsNullOrWhiteSpace(conn))
    throw new InvalidOperationException("ConnectionStrings:Postgres no está configurada (env/appsettings).");


// ✅ Usa la cadena directamente
builder.Services.AddDbContext<applicationDbContext>(options =>
    options.UseNpgsql(conn));

//Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("Api.Postgres", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

//builder.Services.AddRateLimiter(options => {
    
//    options.RejectionStatusCode = 
//    StatusCodes.Status429TooManyRequests;
//    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
//    {
//        var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

//        return RateLimitPartition.GetFixedWindowLimiter(
//            partitionKey: ip, 
//            factory: _ => new FixedWindowRateLimiterOptions
//        {   
//                PermitLimit = 10, //número de solicitudes
//                Window = TimeSpan.FromSeconds(10), // intervalo de tiempo
//                QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
//                QueueLimit = 0 // sin cola de espera


//            });
//    });

//    options.AddSlidingWindowLimiter(policyName: "sliding", opt =>
//    {
//        opt.PermitLimit = 5;                 
//        opt.Window = TimeSpan.FromSeconds(10);
//        opt.SegmentsPerWindow = 10;           
//        opt.QueueLimit = 0;                  
//        // opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst; //  con cola de espera cola
//    });

//    options.OnRejected = async (context, token) =>
//    {
//        context.HttpContext.Response.Headers["Retry-After"] = "10s"; // tiempo de espera para reintentar
//        await context.HttpContext.Response.WriteAsync("Too many requests. Please try again later.", cancellationToken: token);
//    };

//});
 
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


//app.UseRateLimiter();
app.UseHttpsRedirection();

app.UseCors("Api.Postgres");
app.UseAuthorization();

app.MapControllers();

app.Run();
