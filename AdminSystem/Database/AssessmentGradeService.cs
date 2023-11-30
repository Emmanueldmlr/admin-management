using System;
using AdminSystem.Models;

namespace AdminSystem.Database
{
	public class AssessmentGradeService
	{
        private List<AssessmentGrade> assessmentGrades;

        private DataContext context = new DataContext();

    public void AddAssessmentGrade(AssessmentGrade grade)
        {
            context.AssessmentGrades.Add(grade);
            context.SaveChanges();
        }

        public IEnumerable<AssessmentGrade> GetAssessmentGrades()
        {
            assessmentGrades = context.AssessmentGrades.ToList();

            return assessmentGrades;
        }

        public AssessmentGrade GetAssessmentGradeById(int assessmentId)
        {
            AssessmentGrade retrievedGrade = context.AssessmentGrades
                          .FirstOrDefault(a => a.Id == assessmentId);

            return retrievedGrade;
        }

        public AssessmentGrade GetStudentAssessmentGrade(int moduleAssessmentId, int studentId)
        {
            AssessmentGrade retrievedGrades = context.AssessmentGrades
                          .FirstOrDefault(a => (a.ModuleAssessmentId == moduleAssessmentId) && (a.StudentId == studentId));

            return retrievedGrades;
        }

        public IEnumerable<AssessmentGrade> GetStudentAssessmentGrade(int studentId)
        {
            assessmentGrades = context.AssessmentGrades
                          .Where(a => (a.StudentId == studentId)).ToList();
            return assessmentGrades;
        }
    }
}

