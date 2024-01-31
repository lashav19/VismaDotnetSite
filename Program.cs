
using Microsoft.EntityFrameworkCore;
using Project;
using Microsoft.AspNetCore.Identity;
using Project.Areas.Identity.Data;
using Project.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ProjectContextConnection") ?? throw new InvalidOperationException("Connection string 'ProjectContextConnection' not found.");

builder.Services.AddDbContext<ProjectContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ProjectUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ProjectContext>();
builder.Services.AddRazorPages();

// Add services to the container.
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
app.UseAuthentication();


app.UseEndpoints(endpoints =>
{
    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();

});





app.Run();
