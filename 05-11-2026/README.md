# Ngày 05/11/2026 - MVC Database First 1 và Code First 1

Cả hai project dùng ASP.NET Core MVC .NET 10 và Entity Framework Core 10.0.0. Sửa `ConnectionStrings:DefaultConnection` trong `appsettings.json` trước khi chạy.

## MovieTicketDatabaseFirst (Movies và Tickets)

1. Chạy `MovieTicketDatabaseFirst/Database/MovieTicketDB.sql` trên SQL Server.
2. Chạy:

```bash
cd MovieTicketDatabaseFirst
dotnet run
```

Model và DbContext tương ứng kết quả của lệnh scaffold:

```bash
dotnet ef dbcontext scaffold "Name=ConnectionStrings:DefaultConnection" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir Data --context MovieTicketDbContext --no-onconfiguring --force
```

Chạy lại lệnh này với `--force` sẽ ghi đè các file Model/DbContext, mất các thuộc tính validation đã thêm tay.

## BookBorrowingCodeFirst (Books và BorrowingRecords)

1. Tạo migration và database:

```bash
cd BookBorrowingCodeFirst
dotnet ef migrations add InitialCreate
dotnet ef database update
```

2. Chạy:

```bash
dotnet run
```
