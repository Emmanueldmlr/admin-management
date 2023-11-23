using System;
using System.Drawing;
using AdminSystem.Database;
using AdminSystem.Models;
using AdminSystem.Utils;

namespace AdminSystem.Logic
{
	public class AssessmentGradeActions
	{
        private IEnumerable<AssessmentGrade> assessmentsGrade;
        public string UploadStudentResult(int studentId, int moduleCode, int assessmentCode, double studentScore)
        {

            if (studentId == null || moduleCode == null || assessmentCode == null || studentScore == null)
            {
                return("Student Id, Assessment Code, Student Score and moduleCode must be entered.");
            }

            AssessmentService assessmentService = new AssessmentService();
            ModuleService moduleService = new ModuleService();
            StudentService studentService = new StudentService();

            Student student = studentService.GetStudentByCode(studentId);
            Module module = moduleService.GetModule(moduleCode);
            Assessment assessment = assessmentService.GetAssessment(assessmentCode);

            if(student == null || module == null || assessment == null)
            {
                return("Invalid student ID or Module code or Assessment Code");
            }

            ModuleAssessmentService moduleAssessmentInstance = new ModuleAssessmentService();
            ModuleAssessment moduleAssessment = moduleAssessmentInstance.GetModuleAssessment(module.Id, assessment.Id);
            if(moduleAssessment == null)
            {
                return("Assesment does not belong to the module");
            }

            AssessmentGradeService assessmentGradeService = new AssessmentGradeService();
            AssessmentGrade assessmentGrade = assessmentGradeService.GetStudentAssessmentGrade(moduleAssessment.Id, student.Id);

            if(assessmentGrade != null)
            {
                return("Student assessment for this module already graded");
            }

            if(studentScore > assessment.MaximumGrade)
            {
                return("Student Score cannot be Greater than than the maximum grade for the assessment");
            }

            AssessmentGrade studentAssessmentGrade = new AssessmentGrade
            {
                ModuleAssessmentId = moduleAssessment.Id,
                StudentId = student.Id,
                Score = studentScore,
            };

            assessmentGradeService.AddAssessmentGrade(studentAssessmentGrade);

            return("Student Assessment result successfully recorded");

        }

        public IEnumerable<AssessmentGrade> GetStudentsAssessmentResult()
        {
            AssessmentGradeService assessmentGradeServiceInstance = new AssessmentGradeService();
            assessmentsGrade = assessmentGradeServiceInstance.GetAssessmentGrades();
            return assessmentsGrade;
        }
    }
}

