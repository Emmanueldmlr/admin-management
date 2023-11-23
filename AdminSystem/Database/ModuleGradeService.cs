using System;
using AdminSystem.Models;

namespace AdminSystem.Database
{
	public class ModuleGradeService
	{
        private List<ModuleGrade> moduleGrades;

        public void AddModuleGrade(ModuleGrade moduleGrade)
        {
            using var context = new DataContext();
            context.ModuleGrades.Add(moduleGrade);
            context.SaveChanges();
        }

        public IEnumerable<ModuleGrade> GetModuleGrades()
        {
            using var context = new DataContext();

            moduleGrades = context.ModuleGrades.ToList();

            return moduleGrades;
        }

        public ModuleGrade GetStudentModuleGrade(int programId, int moduleId,  int studentId)
        {
            using var context = new DataContext();

            ModuleGrade retrievedGrade = context.ModuleGrades
                          .FirstOrDefault(a => (a.ProgramId == programId) && (a.StudentId == studentId) && (a.moduleId == moduleId));

            return retrievedGrade;
        }

    }
}

