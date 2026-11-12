using StudentManagementAdo.Models;

namespace StudentManagementAdo.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student? GetById(int id);
        bool CodeExists(string studentCode, int excludeId = 0);
        void Add(Student student);
        bool Update(Student student);
        bool Delete(int id);
    }
}
