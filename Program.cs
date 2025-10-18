using Microsoft.EntityFrameworkCore;
using Webnhannuoi.Data; 

var builder = WebApplication.CreateBuilder(args);

// ==========================
// 🔹 Cấu hình kết nối CSDL
// ==========================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ==========================
// 🔹 Cấu hình dịch vụ MVC
// ==========================
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var app = builder.Build();

// ==========================
// 🔹 Middleware pipeline
// ==========================
app.UseSession();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();
