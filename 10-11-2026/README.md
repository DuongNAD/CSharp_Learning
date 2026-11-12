# MVC - Lệnh Entity Framework (10/11/2026)

## 1. Cài các package vào project

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 10.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 10.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 10.0.0
```

| Lệnh | Ý nghĩa |
| :--- | :--- |
| `dotnet add package` | Thêm một thư viện NuGet vào file `.csproj` của project hiện tại. |
| `Microsoft.EntityFrameworkCore.SqlServer` | Provider của EF Core cho SQL Server. Có package này mới dùng được `UseSqlServer(...)` và `DbContext` làm việc với SQL Server. |
| `Microsoft.EntityFrameworkCore.Design` | Chứa phần code lúc thiết kế (design-time) mà các lệnh `scaffold`, `migrations add` cần để đọc model/database và sinh code. |
| `Microsoft.EntityFrameworkCore.Tools` | Thêm lệnh cho Package Manager Console của Visual Studio (`Scaffold-DbContext`, `Add-Migration`, `Update-Database`). |
| `--version 10.0.0` | Cố định đúng phiên bản 10.0.0 để khớp với .NET 10, tránh lệch phiên bản giữa các package. |

## 2. Cài công cụ dotnet-ef

```bash
dotnet tool install --global dotnet-ef --version 10.0.0
dotnet tool update --global dotnet-ef --version 10.0.0
```

| Lệnh | Ý nghĩa |
| :--- | :--- |
| `dotnet tool install --global dotnet-ef` | Cài công cụ dòng lệnh `dotnet ef` cho cả máy (`--global`), dùng được ở mọi project. |
| `dotnet tool update --global dotnet-ef` | Cập nhật `dotnet-ef` lên phiên bản chỉ định (dùng khi đã cài bản cũ). |

## 3. Kiểm tra phiên bản

```bash
dotnet ef --version
```

Kiểm tra `dotnet-ef` đã cài chưa và đang là phiên bản nào (cần là 10.0.0 để khớp với các package ở trên).

## 4. Database First: tạo Model và DbContext từ database có sẵn

```bash
dotnet ef dbcontext scaffold "Server=42.xxx.xxx.xxx;Database=StudentManagementDB;User Id=your_user;Password=your_password;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir Data --context StudentManagementDbContext --no-onconfiguring --force
```

| Thành phần | Ý nghĩa |
| :--- | :--- |
| `dotnet ef dbcontext scaffold` | Đọc cấu trúc database rồi tự sinh ra các class Model (mỗi bảng một class) và một class `DbContext`. |
| `"Server=...;Database=...;User Id=...;Password=...;TrustServerCertificate=True;"` | Connection string: địa chỉ server, tên database, tài khoản, mật khẩu. `TrustServerCertificate=True` bỏ qua kiểm tra chứng chỉ SSL (hay dùng khi server dùng chứng chỉ tự ký). |
| `Microsoft.EntityFrameworkCore.SqlServer` | Provider dùng để kết nối (SQL Server). |
| `--output-dir Models` | Các class Model sinh ra nằm trong thư mục `Models`. |
| `--context-dir Data` | Class `DbContext` sinh ra nằm trong thư mục `Data`. |
| `--context StudentManagementDbContext` | Đặt tên cho class `DbContext`. |
| `--no-onconfiguring` | Không sinh hàm `OnConfiguring` chứa connection string cứng trong code. Connection string sẽ cấu hình trong `appsettings.json` và đăng ký ở `Program.cs`. |
| `--force` | Ghi đè các file đã tồn tại. Chạy lại lệnh sẽ mất mọi chỉnh sửa tay trong các file Model/DbContext. |

Lưu ý: không nên để mật khẩu trực tiếp trong lệnh hay đẩy lên git. Có thể thay chuỗi kết nối bằng `"Name=ConnectionStrings:DefaultConnection"` để lệnh đọc từ `appsettings.json` hoặc user-secrets.
