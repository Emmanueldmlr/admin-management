using System;
using AdminSystem.Models;

namespace AdminSystem.Database
{
	public class AssessmentService
	{
        private List<Assessment> assessments;

        private DataContext context = new DataContext();

        public void AddAssessment(Assessment assessment)
        {
            context.Assessments.Add(assessment);
            context.SaveChanges();
        }

        public IEnumerable<Assessment> GetAssessments()
        {
            assessments = context.Assessments.ToList();

            return assessments;
        }

        public Assessment GetAssessment(int assessmentCode)
        {
            Assessment retrievedAssessment = context.Assessments
                          .FirstOrDefault(a => a.Code == assessmentCode);
            return retrievedAssessment;
        }

        public Assessment GetAssessmentById(int assessmentId)
        {
            Assessment retrievedAssessment = context.Assessments
                          .FirstOrDefault(a => a.Id == assessmentId);
            return retrievedAssessment;
        }

    }
}

