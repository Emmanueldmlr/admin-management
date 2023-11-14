using System;
using AdminSystem.Database;
using AdminSystem.Utils;
using AdminSystem.Models;
using System.Reflection;

namespace AdminSystem.Actions
{
	public class AssessmentActions
	{
        private IEnumerable<Assessment> assessments;
        public void CreateAssessment()
        {
            try
            {
                Console.WriteLine("Provide the title of the Assessment: ");
                string assessmentTitle = Console.ReadLine();

                Console.WriteLine("Provide the details of the Assessment: ");
                string assessmentDetails = Console.ReadLine();

                Console.WriteLine("Provide the maximum grade for the Assessment: ");
                int maximumGrade = int.Parse(Console.ReadLine());

                if (assessmentTitle == null || assessmentDetails == null || maximumGrade == null)
                {
                    Console.WriteLine("Assessment Title, Details and Maximum Grade must be entered.");
                    return;
                }

                if (maximumGrade > 100)
                {
                    Console.WriteLine("Assessment maximum grade cannot be more than 100");
                    return;
                }

                CodeFacade codeFacadeInstance = new CodeFacade();
                int assessmentCode = codeFacadeInstance.GenerateCode(5);

                Assessment assessmentInstance = new Assessment
                {
                    Details = assessmentDetails,
                    Title = assessmentDetails,
                    MaximumGrade = maximumGrade,
                    Code = assessmentCode
                };

                AssessmentService assessmentServiceInstance = new AssessmentService();
                assessmentServiceInstance.AddAssessment(assessmentInstance);

                Console.WriteLine("Assessment added successfully!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Input.");
            }
        }

        public void GetAssessments()
        {
            AssessmentService assessmentServiceInstance = new AssessmentService();
            assessments = assessmentServiceInstance.GetAssessments();
            foreach (Assessment assessment in assessments)
            {
                Console.WriteLine($"Assessment title: {assessment.Title}, Assessment Details: {assessment.Details}, Assessment Maximu Grade: {assessment.MaximumGrade}, Assessment Code: {assessment.Code}"); // prints out properties 

            }
        }
    }
}

