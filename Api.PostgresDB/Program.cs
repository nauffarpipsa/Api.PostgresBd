using Analysis.Services.Contract;
using Analysis.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Contract;
using Repository.Implementation;
using Services.Contract;
using Services.Implementation;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
builder.Services.AddDbContext<applicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));



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