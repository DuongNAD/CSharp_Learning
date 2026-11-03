var builder = WebApplication.CreateBuilder(args);

// 1. Đăng ký dịch vụ MVC (Controllers + Views)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 2. Cấu hình HTTP Request Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// 3. Kích hoạt Routing Middleware
app.UseRouting();

app.UseAuthorization();

// 4. Định tuyến mặc định: /Student/Index/{id?}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
