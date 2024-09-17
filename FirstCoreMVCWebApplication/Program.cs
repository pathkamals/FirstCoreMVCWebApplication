using FirstCoreMVCWebApplication.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
//builder.Services.AddSingleton<SomeOtherService>();

//builder.Services.AddScoped<IStudentRepository, StudentRepository>();
//builder.Services.AddScoped<SomeOtherService>();

builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<SomeOtherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseCors();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapGet("/hello", () => "Hello demo application");
app.Run();
