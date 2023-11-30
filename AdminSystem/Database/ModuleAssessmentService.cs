using System;
using AdminSystem.Models;

namespace AdminSystem.Database
{
	public class ModuleAssessmentService
	{
        private List<ModuleAssessment> moduleAssessments;
        private DataContext context = new DataContext();

        public void AddModuleAssessment(ModuleAssessment moduleAssessment)
        {
            context.ModuleAssessments.Add(moduleAssessment);
            context.SaveChanges();
        }

        public IEnumerable<ModuleAssessment> GetModuleAssessments()
        {

            moduleAssessments = context.ModuleAssessments.ToList();

            return moduleAssessments;
        }

        public ModuleAssessment GetModuleAssessment(int moduleId, int assessmentId)
        {

            ModuleAssessment retrievedRecord = context.ModuleAssessments
                          .FirstOrDefault(p => p.ModuleId == moduleId && p.AssessmentId == assessmentId);

            return retrievedRecord;
        }

        public IEnumerable<ModuleAssessment> GetModuleAssessmentsByModuleId(int moduleId)
        {

            moduleAssessments = context.ModuleAssessments
                          .Where(p => p.ModuleId == moduleId).ToList(); ;

            return moduleAssessments;
        }

        public ModuleAssessment GetModuleAssessmentsById(int id)
        {

            ModuleAssessment retrievedRecord = context.ModuleAssessments
                          .FirstOrDefault(p => p.Id == id); ;

            return retrievedRecord;
        }
    }
}

