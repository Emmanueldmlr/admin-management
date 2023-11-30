using System;
using AdminSystem.Models;

namespace AdminSystem.Database
{
	public class GradeService
	{
        private List<Grade> grades;
        private DataContext context = new DataContext();

        public void AddProgramGrade(Grade programGrade)
        {
            context.Grades.Add(programGrade);
            context.SaveChanges();
        }

        public IEnumerable<Grade> GetGrades()
        {
            grades = context.Grades.ToList();

            return grades;
        }

        public Grade GetStudentProgramGrade(int programId, int studentId)
        {
            Grade retrievedGrade = context.Grades
                          .FirstOrDefault(a => (a.ProgramId == programId) && (a.StudentId == studentId));
            return retrievedGrade;
        }
    }
}

