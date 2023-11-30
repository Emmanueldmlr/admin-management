using System;
using AdminSystem.Database;
using AdminSystem.Logic;
using AdminSystem.Models;

namespace AdminSystem.UI
{
	public class AssessmentGradeUIs
	{
        AssessmentGradeActions assessmentGradeActions = new AssessmentGradeActions();
        StudentService studentService = new StudentService();
        ModuleAssessmentService moduleAssessmentInstance = new ModuleAssessmentService();
        AssessmentService assessmentService = new AssessmentService();
        ModuleService moduleService = new ModuleService();

        public void UploadStudentResultUI()
		{
            try
            {
                Console.WriteLine("Provide the student Id Number: ");
                int studentId = int.Parse(Console.ReadLine());

                Console.WriteLine("Provide the module code: ");
                int moduleCode = int.Parse(Console.ReadLine());

                Console.WriteLine("Provide the assessment code: ");
                int assessmentCode = int.Parse(Console.ReadLine());

                Console.WriteLine("Provide the student score for the assessment: ");
                double studentScore = double.Parse(Console.ReadLine());

                string response = assessmentGradeActions.UploadStudentResult(studentId, moduleCode, assessmentCode, studentScore);
                Console.WriteLine(response);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Input.");
            }
        }

        public void GetStudentsAssessmentResultUI()
        {
            IEnumerable<AssessmentGrade> assessmentsGrade = assessmentGradeActions.GetStudentsAssessmentResult();

            if (!assessmentsGrade.Any())
            {
                Console.WriteLine("Student Assessment Result not available");
            }

            foreach (AssessmentGrade grade in assessmentsGrade)
            {
                
                Student student = studentService.GetStudentById(grade.StudentId);
                ModuleAssessment moduleAssessment = moduleAssessmentInstance.GetModuleAssessmentsById(grade.ModuleAssessmentId);
                Assessment assessment = assessmentService.GetAssessmentById(moduleAssessment.AssessmentId);
                Module module = moduleService.GetModuleById(moduleAssessment.ModuleId);
                Console.WriteLine($" Student Name: {student.Name}, Student ID: {student.IdentificationNumber},Assessment title: {assessment.Title},Module Title: {module.Title}, Assessment Maximum Grade: {assessment.MaximumGrade}, Student Score: {grade.Score}"); // prints out properties 
            }
        }

    }
}

