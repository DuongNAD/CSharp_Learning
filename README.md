# C# & ASP.NET Core MVC Learning - Aptech C2411L

> Tổng hợp mã nguồn, bài tập về nhà (Homework) và dự án thực hành môn học **C# / ASP.NET Core MVC** tại **Aptech** (Lớp `AAHN_C2411L` - GV: Tiến Lực Văn).

---

## Danh Sách Bài Tập Theo Ngày Học

Toàn bộ các bài tập được chia theo thư mục ngày `DD-MM-YYYY` để dễ dàng quản lý, tra cứu luồng chạy MVC và nộp bài trên Google Classroom:

| STT | Ngày đăng | Tên bài tập trên Classroom | Thư mục / Project | Nội dung chính | Trạng thái |
| :---: | :---: | :--- | :--- | :--- | :---: |
| 1 | **29/10/2026** | **MVC - Homework - Student** | `29-10-2026/Bai1_StudentListMvc` | Khởi tạo danh sách sinh viên (`Id`, `Name`, `Age`, `Email`), hiển thị lên View và trình bày chi tiết luồng chạy MVC | Hoàn thành |
| 2 | **29/10/2026** | **MVC - Homework - Student Form** | `29-10-2026/Bai2_StudentFormMvc` | Tạo Form nhập liệu thông tin sinh viên (`GET`/`POST`), Model Binding, Validation và hiển thị danh sách/chi tiết sinh viên vừa nhập | Hoàn thành |
| 3 | **31/10/2026** | **MVC - Source Code Mẫu** | `31-10-2026/MvcHttpDemo` | Phân tích luồng chạy MVC mẫu, quản lý CRUD đối tượng `Student` và **bổ sung hoàn thiện chức năng Sửa sinh viên (`Edit`)** | Hoàn thành |

---

## Cấu Trúc Thư Mục Tổng Thể

```text
CSharp/
├── .gitignore
├── README.md
├── 29-10-2026/
│   ├── README.md                       # Giải thích chi tiết luồng chạy MVC & Hướng dẫn 2 bài ngày 29/10
│   ├── Bai1_StudentListMvc/            # Bài 1: Hiển thị danh sách sinh viên (Id, Name, Age, Email)
│   └── Bai2_StudentFormMvc/            # Bài 2: Form nhập liệu thông tin sinh viên & hiển thị lên web
└── 31-10-2026/
    ├── README.md                       # Trả lời câu hỏi luồng chạy MVC & Giải thích chức năng Sửa sinh viên
    └── MvcHttpDemo/                    # Bài 3: Source code MVC quản lý Sinh viên + Chức năng Edit hoàn chỉnh
```

---

## Hướng Dẫn Chạy Nhanh Các Project

Yêu cầu cài đặt **.NET SDK (8.0 trở lên)** hoặc mở trực tiếp file `.sln` / `.csproj` bằng **Visual Studio 2022** / **JetBrains Rider** / **VS Code**.

```bash
# Chạy Bài 1 (Ngày 29/10 - Danh sách sinh viên)
cd 29-10-2026/Bai1_StudentListMvc
dotnet run

# Chạy Bài 2 (Ngày 29/10 - Form nhập liệu sinh viên)
cd 29-10-2026/Bai2_StudentFormMvc
dotnet run

# Chạy Bài 3 (Ngày 31/10 - MvcHttpDemo + Chức năng Sửa sinh viên)
cd 31-10-2026/MvcHttpDemo
dotnet run
```
