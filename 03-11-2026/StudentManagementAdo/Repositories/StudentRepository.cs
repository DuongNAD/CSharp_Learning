using Microsoft.Data.SqlClient;
using StudentManagementAdo.Models;

namespace StudentManagementAdo.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private const string SelectColumns =
            "StudentId, StudentCode, FullName, DateOfBirth, Email, Phone";

        private readonly string _connectionString;

        public StudentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Thiếu ConnectionStrings:DefaultConnection trong appsettings.json");
        }

        public List<Student> GetAll()
        {
            var students = new List<Student>();

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                $"SELECT {SelectColumns} FROM Student ORDER BY StudentId", connection);

            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                students.Add(MapStudent(reader));
            }

            return students;
        }

        public Student? GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                $"SELECT {SelectColumns} FROM Student WHERE StudentId = @StudentId", connection);
            command.Parameters.AddWithValue("@StudentId", id);

            connection.Open();
            using var reader = command.ExecuteReader();
            return reader.Read() ? MapStudent(reader) : null;
        }

        public bool CodeExists(string studentCode, int excludeId = 0)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "SELECT COUNT(1) FROM Student WHERE StudentCode = @StudentCode AND StudentId <> @ExcludeId",
                connection);
            command.Parameters.AddWithValue("@StudentCode", studentCode);
            command.Parameters.AddWithValue("@ExcludeId", excludeId);

            connection.Open();
            return (int)command.ExecuteScalar()! > 0;
        }

        public void Add(Student student)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                @"INSERT INTO Student (StudentCode, FullName, DateOfBirth, Email, Phone)
                  VALUES (@StudentCode, @FullName, @DateOfBirth, @Email, @Phone)", connection);
            AddParameters(command, student);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public bool Update(Student student)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                @"UPDATE Student
                  SET StudentCode = @StudentCode, FullName = @FullName, DateOfBirth = @DateOfBirth,
                      Email = @Email, Phone = @Phone
                  WHERE StudentId = @StudentId", connection);
            AddParameters(command, student);
            command.Parameters.AddWithValue("@StudentId", student.StudentId);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "DELETE FROM Student WHERE StudentId = @StudentId", connection);
            command.Parameters.AddWithValue("@StudentId", id);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        private static void AddParameters(SqlCommand command, Student student)
        {
            command.Parameters.AddWithValue("@StudentCode", student.StudentCode);
            command.Parameters.AddWithValue("@FullName", student.FullName);
            command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth.Date);
            command.Parameters.AddWithValue("@Email", student.Email);
            command.Parameters.AddWithValue("@Phone", student.Phone);
        }

        private static Student MapStudent(SqlDataReader reader) => new()
        {
            StudentId = reader.GetInt32(0),
            StudentCode = reader.GetString(1),
            FullName = reader.GetString(2),
            DateOfBirth = reader.GetDateTime(3),
            Email = reader.GetString(4),
            Phone = reader.GetString(5)
        };
    }
}
