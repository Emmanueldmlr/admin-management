using System;
using AdminSystem.Models;

namespace AdminSystem.Database
{
	public class StudentService
	{
        private List<Student> students;
        private DataContext context = new DataContext();

        public void AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public IEnumerable<Student> GetStudents()
        {
            students = context.Students.ToList();
            return students;
        }

        public Student GetStudentByCode(int studentId)
        {
            Student retrievedStudent = context.Students
                          .FirstOrDefault(p => p.IdentificationNumber == studentId);
            return retrievedStudent;
        }

        public Student GetStudentById(int id)
        {
            Student retrievedStudent = context.Students
                          .FirstOrDefault(p => p.Id == id);
            return retrievedStudent;
        }
    }
}

