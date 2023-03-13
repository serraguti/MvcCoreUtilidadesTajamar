using MvcCoreUtilidades.Helpers;
using MvcCoreUtilidades.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<RepositoryCoches>();
builder.Services.AddTransient<CryptoEngine>();
// Add services to the container.
builder.Services.AddResponseCaching();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});


builder.Services.AddSingleton<HelperPathProvider>();
builder.Services.AddSingleton<HelperMail>();
builder.Services.AddTransient<HelperUploadFiles>();
builder.Services.AddControllersWithViews();

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

app.UseRouting();

app.UseAuthorization();

app.UseResponseCaching();

app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
