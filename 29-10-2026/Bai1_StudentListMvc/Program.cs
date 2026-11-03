var builder = WebApplication.CreateBuilder(args);

// 1. Đăng ký dịch vụ MVC (Controllers + Views) vào Dependency Injection Container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 2. Cấu hình HTTP Request Pipeline (Middleware)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// 3. Kích hoạt Middleware định tuyến (Routing)
app.UseRouting();

app.UseAuthorization();

// 4. Cấu hình Route mặc định trỏ thẳng vào StudentController -> Action Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
