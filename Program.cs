using app_card;
using app_card.Models.Interfaces;
using app_card.Repositories;
using Vereyon.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddFlashMessage();
builder.Services.AddSession( options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

// Register the connection strings
builder.Services.AddTransient(_ => builder.Configuration.GetConnectionString("BirthdayCards"));
builder.Services.AddTransient(_ => builder.Configuration.GetConnectionString("ChristmasCards"));
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();
builder.Services.AddControllersWithViews()
        .AddViewOptions(options =>
        {
            options.HtmlHelperOptions.ClientValidationEnabled = true;
        });




var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//}
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
