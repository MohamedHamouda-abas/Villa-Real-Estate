using MagicVila_Web.Mapping;
using MagicVila_Web.Services;
using MagicVila_Web.Services.IServices;
using Montview_Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddHttpClient<IVilaService, VilaService>();
builder.Services.AddScoped<IVilaService, VilaService>();


builder.Services.AddHttpClient<IVilaNumberService, VilaNumberService>();
builder.Services.AddScoped<IVilaNumberService, VilaNumberService>();

builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSession(option =>
{
    option.IdleTimeout=TimeSpan.FromSeconds(100);
    option.Cookie.HttpOnly=true;
    option.Cookie.IsEssential=true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
