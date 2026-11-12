# Ngày 03/11/2026 - MVC Homework: Kết nối đến database

Project: `StudentManagementAdo`. Quản lý sinh viên bằng ASP.NET Core MVC (.NET 10) và ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataReader`).

Cấu trúc theo mô hình: `Models`, `Controllers`, `Repositories`, `Views` (Razor + Bootstrap).

Chức năng: xem danh sách, thêm, sửa, xóa sinh viên (`StudentId`, `StudentCode`, `FullName`, `DateOfBirth`, `Email`, `Phone`).

## Chạy

1. Chạy `StudentManagementAdo/Database/StudentManagementDB.sql` trên SQL Server.
2. Sửa `ConnectionStrings:DefaultConnection` trong `appsettings.json`.
3. Chạy:

```bash
cd StudentManagementAdo
dotnet run
```
