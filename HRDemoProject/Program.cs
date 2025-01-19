using HRDemoProject.Services.Department;
using HRDemoProject.Services.EmployeeData;
using HRDemoProject.Services.EmployeeStatus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Services
builder.Services.AddScoped<IDepartmentDataSerivce, DepartmentDataSerivce>();
builder.Services.AddScoped<IEmployeeDataService, EmployeeDataService>();
builder.Services.AddScoped<IEmployeeStatusDataSerivce, EmployeeStatusDataSerivce>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/Index");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=EmployeeData}/{action=Index}/{id?}");

app.Run();
