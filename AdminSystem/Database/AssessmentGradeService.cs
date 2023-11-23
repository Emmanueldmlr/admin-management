using System;
using AdminSystem.Models;

namespace AdminSystem.Database
{
	public class AssessmentGradeService
	{
        private List<AssessmentGrade> assessmentGrades;

        public void AddAssessmentGrade(AssessmentGrade grade)
        {
            using var context = new DataContext();
            context.AssessmentGrades.Add(grade);
            context.SaveChanges();
        }

        public IEnumerable<AssessmentGrade> GetAssessmentGrades()
        {
            using var context = new DataContext();

            assessmentGrades = context.AssessmentGrades.ToList();

            return assessmentGrades;
        }

        public AssessmentGrade GetAssessmentGradeById(int assessmentId)
        {
            using var context = new DataContext();

            AssessmentGrade retrievedGrade = context.AssessmentGrades
                          .FirstOrDefault(a => a.Id == assessmentId);

            return retrievedGrade;
        }

        public AssessmentGrade GetStudentAssessmentGrade(int moduleAssessmentId, int studentId)
        {
            using var context = new DataContext();

            AssessmentGrade retrievedGrades = context.AssessmentGrades
                          .FirstOrDefault(a => (a.ModuleAssessmentId == moduleAssessmentId) && (a.StudentId == studentId));

            return retrievedGrades;
        }

        public IEnumerable<AssessmentGrade> GetStudentAssessmentGrade(int studentId)
        {
            using var context = new DataContext();

            assessmentGrades = context.AssessmentGrades
                          .Where(a => (a.StudentId == studentId)).ToList();

            return assessmentGrades;
        }
    }
}

