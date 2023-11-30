using System;
using AdminSystem.Logic;
using AdminSystem.Models;

namespace AdminSystem.UI
{
	public class AssessmentUIs
	{
        AssessmentActions assessmentActionsInstance = new AssessmentActions();
        private IEnumerable<Assessment> assessments;

        public void CreateAssessmentUI()
		{
            try
            {
                Console.WriteLine("Provide the title of the Assessment: ");
                string assessmentTitle = Console.ReadLine();

                Console.WriteLine("Provide the details of the Assessment: ");
                string assessmentDetails = Console.ReadLine();

                Console.WriteLine("Provide the maximum grade for the Assessment: ");
                int maximumGrade = int.Parse(Console.ReadLine());

                string response = assessmentActionsInstance.CreateAssessment(assessmentTitle, assessmentDetails, maximumGrade);
                Console.WriteLine(response);

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Input.");
            }
        }

        public void GetAssessmentsUI()
        {
            assessments = assessmentActionsInstance.GetAssessments();
            foreach (Assessment assessment in assessments)
            {
                Console.WriteLine($"Assessment title: {assessment.Title}, Assessment Details: {assessment.Details}, Assessment Maximum Grade: {assessment.MaximumGrade}, Assessment Code: {assessment.Code}"); // prints out properties 
            }
        }

    }
}

