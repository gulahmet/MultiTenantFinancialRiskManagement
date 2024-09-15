using FinancialRiskManagement.Business.Mapping;
using FinancialRiskManagement.Business.Middleware;
using FinancialRiskManagement.Business.Repositories;
using FinancialRiskManagement.Business.Services;
using FinancialRiskManagement.DataAccess;
using FinancialRiskManagement.DataAccess.Concrete;
using FinancialRiskManagement.DataAccess.Model;
using FinancialRiskManagement.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.WebSockets;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Configure JwtSettings from configuration
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
// Add UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add services
builder.Services.AddScoped<IBusinessPartnerService, BusinessPartnerService>();
builder.Services.AddScoped<IBusinessTopicService, BusinessTopicService>();
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IFinancialReportService, FinancialReportService>();
builder.Services.AddScoped<IRiskAnalysisService, RiskAnalysisService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAgreementEvaluationService, AgreementEvaluationService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWebSocketHandler, WebSocketHandler>();
// Register the token service
builder.Services.AddSingleton<ITokenService, TokenService>();

// Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.





builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// AutoMapper konfigürasyonu
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseWebSockets(); // WebSocket middleware'i ekleyin

/*app.UseMiddleware<WebSocketMiddleware>();*/ // Eðer özel bir middleware kullanýyorsanýz




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// WebSocket Middleware
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/ws")
    {
        if (context.WebSockets.IsWebSocketRequest)
        {
            var webSocket = await context.WebSockets.AcceptWebSocketAsync();
            // WebSocketHandler sýnýfýndaki Echo metodunu çaðýrýyoruz.
            await WebSocketMiddleware.Echo(context, webSocket);
        }
        else
        {
            context.Response.StatusCode = 400;
        }
    }
    else
    {
        await next();
    }
});

app.MapControllers();

app.Run();
