using System;
using AdminSystem.Database;
using AdminSystem.Utils;
using AdminSystem.Models;
using System.Reflection;

namespace AdminSystem.Logic
{
	public class AssessmentActions
	{
        private IEnumerable<Assessment> assessments;

        public string CreateAssessment(string assessmentTitle, string assessmentDetails, int maximumGrade)
        {
            if (assessmentTitle == null || assessmentDetails == null || maximumGrade == null)
            {
                return("Assessment Title, Details and Maximum Grade must be entered.");
            }

            if (maximumGrade > 100)
            {
                return("Assessment maximum grade cannot be more than 100");
            }

            CodeFacade codeFacadeInstance = new CodeFacade();
            int assessmentCode = codeFacadeInstance.GenerateCode(5);

            Assessment assessmentInstance = new Assessment
            {
                Details = assessmentDetails,
                Title = assessmentTitle,
                MaximumGrade = maximumGrade,
                Code = assessmentCode
            };

            AssessmentService assessmentServiceInstance = new AssessmentService();
            assessmentServiceInstance.AddAssessment(assessmentInstance);

            return("Assessment added successfully!");
        }

        public IEnumerable<Assessment> GetAssessments()
        {
            AssessmentService assessmentServiceInstance = new AssessmentService();
            assessments = assessmentServiceInstance.GetAssessments();
            return assessments;
        }

    }
}

