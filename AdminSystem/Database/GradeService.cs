using System;
using AdminSystem.Models;

namespace AdminSystem.Database
{
	public class GradeService
	{
        private List<Grade> grades;

        public void AddProgramGrade(Grade programGrade)
        {
            using var context = new DataContext();
            context.Grades.Add(programGrade);
            context.SaveChanges();
        }

        public IEnumerable<Grade> GetGrades()
        {
            using var context = new DataContext();

            grades = context.Grades.ToList();

            return grades;
        }

        public Grade GetStudentProgramGrade(int programId, int studentId)
        {
            using var context = new DataContext();

            Grade retrievedGrade = context.Grades
                          .FirstOrDefault(a => (a.ProgramId == programId) && (a.StudentId == studentId));
            return retrievedGrade;
        }
    }
}

