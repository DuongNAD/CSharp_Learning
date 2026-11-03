var builder = WebApplication.CreateBuilder(args);

// Đăng ký dịch vụ MVC (Controllers + Views)
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Mặc định mở thẳng Form nhập liệu sinh viên hoặc danh sách sinh viên
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Create}/{id?}");

app.Run();
