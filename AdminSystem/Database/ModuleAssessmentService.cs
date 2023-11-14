using System;
using AdminSystem.Models;

namespace AdminSystem.Database
{
	public class ModuleAssessmentService
	{
        private List<ModuleAssessment> moduleAssessments;

        public void AddModuleAssessment(ModuleAssessment moduleAssessment)
        {
            using var context = new DataContext();
            context.ModuleAssessments.Add(moduleAssessment);
            context.SaveChanges();
        }

        public IEnumerable<ModuleAssessment> GetModuleAssessments()
        {
            using var context = new DataContext();

            moduleAssessments = context.ModuleAssessments.ToList();

            return moduleAssessments;
        }

        public ModuleAssessment GetModuleAssessment(int moduleId, int assessmentId)
        {
            using var context = new DataContext();

            ModuleAssessment retrievedRecord = context.ModuleAssessments
                          .FirstOrDefault(p => p.ModuleId == moduleId && p.AssessmentId == assessmentId);

            return retrievedRecord;
        }

        public IEnumerable<ModuleAssessment> GetModuleAssessmentsByModuleId(int moduleId)
        {
            using var context = new DataContext();

            moduleAssessments = context.ModuleAssessments
                          .Where(p => p.ModuleId == moduleId).ToList(); ;

            return moduleAssessments;
        }
    }
}

