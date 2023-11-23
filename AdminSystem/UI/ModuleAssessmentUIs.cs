using System;
using AdminSystem.Database;
using AdminSystem.Logic;
using AdminSystem.Models;

namespace AdminSystem.UI
{
	public class ModuleAssessmentUIs
	{
        ModuleAssessmentAction moduleAssessmentActionsInstance = new ModuleAssessmentAction();
        AssessmentService assessmentServiceInstance = new AssessmentService();
   
        public void AddAssessmentToModuleUI()
		{
            try
            {
                Console.WriteLine("Provide the module code: ");
                int moduleCode = int.Parse(Console.ReadLine());

                Console.WriteLine("Provide the Assessment code: ");
                int assessmentCode = int.Parse(Console.ReadLine());

                string response = moduleAssessmentActionsInstance.AddAssessmentToModule(moduleCode, assessmentCode);

                Console.WriteLine(response);

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Input. Please enter a valid number.");
            }
        }

        public void GetModuleAssessmentsUI()
        {
            try {
                Console.WriteLine("Provide the module code: ");
                int moduleCode = int.Parse(Console.ReadLine());

                (string Message, IEnumerable<ModuleAssessment> assessments, Module retrievedModule) moduleAssessments = moduleAssessmentActionsInstance.GetModuleAssessments(moduleCode);

                if(moduleAssessments.Message == null)
                {
                    Console.WriteLine(moduleAssessments.Message);
                }

                foreach (ModuleAssessment element in moduleAssessments.assessments)
                {
                    
                    Assessment retrievedAssessment = assessmentServiceInstance.GetAssessmentById(element.AssessmentId);
                    Console.WriteLine($"Module Name: {moduleAssessments.retrievedModule.Title}, Assessment Name: {retrievedAssessment.Title}, Assessment Max Grade: {retrievedAssessment.MaximumGrade}, Assessment Code: {retrievedAssessment.Code}, Module Code: {moduleAssessments.retrievedModule.Code}"); // prints out properties 
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Input. Please enter a valid number.");
            }
        }

    }
}

