using System;
using AdminSystem.Models;

namespace AdminSystem.Database
{
	public class AssessmentService
	{
        private List<Assessment> assessments;

        public void AddAssessment(Assessment assessment)
        {
            using var context = new DataContext();
            context.Assessments.Add(assessment);
            context.SaveChanges();
        }

        public IEnumerable<Assessment> GetAssessments()
        {
            using var context = new DataContext();

            assessments = context.Assessments.ToList();

            return assessments;
        }

        public Assessment GetAssessment(int assessmentCode)
        {
            using var context = new DataContext();

            Assessment retrievedAssessment = context.Assessments
                          .FirstOrDefault(a => a.Code == assessmentCode);

            return retrievedAssessment;
        }

        public Assessment GetAssessmentById(int assessmentId)
        {
            using var context = new DataContext();

            Assessment retrievedAssessment = context.Assessments
                          .FirstOrDefault(a => a.Id == assessmentId);

            return retrievedAssessment;
        }

    }
}

