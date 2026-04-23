using CoreBankingApplication.Application.Services;
using CoreBankingApplication.Infrastructure.Data;
using CoreBankingApplication.Infrastructure.Services;
using CoreBankingApplication.UI.Components;
using CoreBankingApplication.UI.Services;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// UI
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// DB
var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "banking.db");

builder.Services.AddDbContextFactory<BankingDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

// Services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<AuthService>(); // 👈 fixes your last error
builder.Services.AddScoped<ToastService>();

var app = builder.Build();
app.UseStaticFiles();

// Seed DB
using (var scope = app.Services.CreateScope())
{
    var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<BankingDbContext>>();
    using var context = factory.CreateDbContext();

    await DbInitializer.InitializeAsync(context);
}

// Middleware
app.UseAntiforgery();

// UI routing
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();