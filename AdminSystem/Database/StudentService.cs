using System;
using AdminSystem.Models;

namespace AdminSystem.Database
{
	public class StudentService
	{
        private List<Student> students;

        public void AddStudent(Student student)
        {
            using var context = new DataContext();
            context.Students.Add(student);
            context.SaveChanges();
        }

        public IEnumerable<Student> GetStudents()
        {
            using var context = new DataContext();

            students = context.Students.ToList();

            return students;
        }

        public Student GetStudentById(int studentId)
        {
            using var context = new DataContext();

            Student retrievedStudent = context.Students
                          .FirstOrDefault(p => p.IdentificationNumber == studentId);

            return retrievedStudent;
        }
    }
}

