using System;
using AdminSystem.Models;

namespace AdminSystem.Database
{
	public class ModuleGradeService
	{
        private List<ModuleGrade> moduleGrades;
        private DataContext context = new DataContext();

        public void AddModuleGrade(ModuleGrade moduleGrade)
        {
            context.ModuleGrades.Add(moduleGrade);
            context.SaveChanges();
        }

        public IEnumerable<ModuleGrade> GetModuleGrades()
        {
            moduleGrades = context.ModuleGrades.ToList();

            return moduleGrades;
        }

        public ModuleGrade GetStudentModuleGrade(int programId, int moduleId,  int studentId)
        {
            ModuleGrade retrievedGrade = context.ModuleGrades
                          .FirstOrDefault(a => (a.ProgramId == programId) && (a.StudentId == studentId) && (a.moduleId == moduleId));

            return retrievedGrade;
        }

    }
}

