using System;
using AdminSystem.Database;
using AdminSystem.Models;

namespace AdminSystem.Actions
{
	public class ModuleAssessmentAction
	{
        public void AddAssessmentToModule()
        {
            try
            {
                Console.WriteLine("Provide the module code: ");
                int moduleCode = int.Parse(Console.ReadLine());

                Console.WriteLine("Provide the Assessment code: ");
                int assessmentCode = int.Parse(Console.ReadLine());

                if (moduleCode == null || assessmentCode == null)
                {
                    Console.WriteLine("Module and Assessment codes must be entered.");
                    return;
                }

                //check if module code and assessment code exist
                AssessmentService assessmentServiceInstance = new AssessmentService();
                ModuleService moduleServiceInstance = new ModuleService();
                Assessment fetchedAssessment = assessmentServiceInstance.GetAssessment(assessmentCode);
                Module fetchedModule = moduleServiceInstance.GetModule(moduleCode);

                if (fetchedAssessment == null || fetchedModule == null)
                {
                    Console.WriteLine("Assessment or Module does not exist");
                    return;
                }


                ModuleAssessmentService moduleAssessmentServiceInstance = new ModuleAssessmentService();
                ModuleAssessment currentModuleAssessment = moduleAssessmentServiceInstance.GetModuleAssessment(fetchedModule.Id,fetchedAssessment.Id);

                if (currentModuleAssessment != null)
                {
                    Console.WriteLine("Assessment Already added to the module");
                    return;
                }

                IEnumerable<ModuleAssessment> existingModuleAssessments = moduleAssessmentServiceInstance.GetModuleAssessmentsByModuleId(fetchedModule.Id);

                int totalAssessmentMaxScore = 0;

                foreach(ModuleAssessment moduleAssessment in existingModuleAssessments)
                {
                    Assessment assessment = assessmentServiceInstance.GetAssessmentById(moduleAssessment.AssessmentId);

                    totalAssessmentMaxScore = assessment.MaximumGrade + totalAssessmentMaxScore;
                }

                if(totalAssessmentMaxScore + fetchedAssessment.MaximumGrade > 100)
                {
                    Console.WriteLine("Module Assessments score can not be greater than 100");
                    return;
                }

                ModuleAssessment newModuleAssessment = new ModuleAssessment
                {
                    AssessmentId = fetchedAssessment.Id,
                    ModuleId = fetchedModule.Id,
                };

                moduleAssessmentServiceInstance.AddModuleAssessment(newModuleAssessment);
                Console.WriteLine("Assessment successfully added to the Module!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Input. Please enter a valid number.");
            }

        }
        public void GetModuleAssessments()
        {
            try
            {
                Console.WriteLine("Provide the module code: ");
                int moduleCode = int.Parse(Console.ReadLine());

                ModuleService moduleServiceInstance = new ModuleService();
                Module retrievedModule = moduleServiceInstance.GetModule(moduleCode);

                if (retrievedModule == null)
                {
                    Console.WriteLine("Module does not exist");
                    return;
                }

                ModuleAssessmentService moduleAssessmentInstance = new ModuleAssessmentService();
                IEnumerable<ModuleAssessment> moduleAssessments = moduleAssessmentInstance.GetModuleAssessmentsByModuleId(retrievedModule.Id);
                if (!moduleAssessments.Any())
                {
                    Console.WriteLine("No Program modules exist");
                    return;
                }
                foreach (ModuleAssessment element in moduleAssessments)
                {
                    AssessmentService assessmentServiceInstance = new AssessmentService();
                    Assessment retrievedAssessment = assessmentServiceInstance.GetAssessmentById(element.AssessmentId);
                    Console.WriteLine($"Module Name: {retrievedModule.Title}, Assessment Name: {retrievedAssessment.Title}, Assessment Max Grade: {retrievedAssessment.MaximumGrade}, Assessment Code: {retrievedAssessment.Code}, Module Code: {retrievedModule.Code}"); // prints out properties 
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Input. Please enter a valid number.");
            }
        }
    }
}

