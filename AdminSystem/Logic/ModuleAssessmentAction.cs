using System;
using AdminSystem.Database;
using AdminSystem.Models;

namespace AdminSystem.Logic
{
    public class ModuleAssessmentAction
    {
        public string AddAssessmentToModule(int moduleCode, int assessmentCode)
        {

            if (moduleCode == null || assessmentCode == null)
            {
                return ("Module and Assessment codes must be entered.");
            }

            //check if module code and assessment code exist
            AssessmentService assessmentServiceInstance = new AssessmentService();
            ModuleService moduleServiceInstance = new ModuleService();
            Assessment fetchedAssessment = assessmentServiceInstance.GetAssessment(assessmentCode);
            Module fetchedModule = moduleServiceInstance.GetModule(moduleCode);

            if (fetchedAssessment == null || fetchedModule == null)
            {
                return ("Assessment or Module does not exist");
            }

            ModuleAssessmentService moduleAssessmentServiceInstance = new ModuleAssessmentService();
            ModuleAssessment currentModuleAssessment = moduleAssessmentServiceInstance.GetModuleAssessment(fetchedModule.Id, fetchedAssessment.Id);

            if (currentModuleAssessment != null)
            {
                return ("Assessment Already added to the module");
            }

            IEnumerable<ModuleAssessment> existingModuleAssessments = moduleAssessmentServiceInstance.GetModuleAssessmentsByModuleId(fetchedModule.Id);

            int totalAssessmentMaxScore = 0;

            foreach (ModuleAssessment moduleAssessment in existingModuleAssessments)
            {
                Assessment assessment = assessmentServiceInstance.GetAssessmentById(moduleAssessment.AssessmentId);

                totalAssessmentMaxScore = assessment.MaximumGrade + totalAssessmentMaxScore;
            }

            if (totalAssessmentMaxScore + fetchedAssessment.MaximumGrade > 100)
            {
                return ("Module Assessments score can not be greater than 100");
            }

            ModuleAssessment newModuleAssessment = new ModuleAssessment
            {
                AssessmentId = fetchedAssessment.Id,
                ModuleId = fetchedModule.Id,
            };

            moduleAssessmentServiceInstance.AddModuleAssessment(newModuleAssessment);
            return ("Assessment successfully added to the Module!");
        }

        public (string Message, IEnumerable<ModuleAssessment>, Module module) GetModuleAssessments(int moduleCode)
        {

            ModuleService moduleServiceInstance = new ModuleService();
            Module retrievedModule = moduleServiceInstance.GetModule(moduleCode);

            if (retrievedModule == null)
            {
                return ("Module does not exist", null, null);
            }

            ModuleAssessmentService moduleAssessmentInstance = new ModuleAssessmentService();
            IEnumerable<ModuleAssessment> moduleAssessments = moduleAssessmentInstance.GetModuleAssessmentsByModuleId(retrievedModule.Id);

            if (!moduleAssessments.Any())
            {
                return ("No module Assessments exist", null, null);
            }

            return (null, moduleAssessments, retrievedModule);

        }
    }
}

