using System;
using AdminSystem.UI;

namespace AdminSystem.Utils
{
	public static class StartupProcess
	{
		public static void InitiateProcess(int userAction)
		{
            ProgramUIs programUIs = new ProgramUIs();
            StudentUIs studentUIs = new StudentUIs();
            ModuleUIs moduleUIs = new ModuleUIs();
            ProgramModuleUIs programModuleUIs = new ProgramModuleUIs();
            AssessmentUIs assessmentUIs = new AssessmentUIs();
            ModuleAssessmentUIs moduleAssessmentUIs = new ModuleAssessmentUIs();
            AssessmentGradeUIs assessmentGradeUIs = new AssessmentGradeUIs();

            switch (userAction)
            {
                case 1:
                    programUIs.CreateProgramUI();
                    break;
                case 2:
                    programUIs.GetProgrammesUI();
                    break;
                case 3:
                    studentUIs.CreateStudentUI();
                    break;
                case 4:
                    studentUIs.GetStudentsUI();
                    break;
                case 5:
                    moduleUIs.CreateModuleUI();
                    break;
                case 6:
                    moduleUIs.GetModulesUI();
                    break;
                case 7:
                    programModuleUIs.AddModuleToProgramUI();
                    break;
                case 8:
                    programModuleUIs.GetProgramModulesUI();
                    break;
                case 9:
                    assessmentUIs.CreateAssessmentUI();
                    break;
                case 10:
                    assessmentUIs.GetAssessmentsUI();
                    break;
                case 11:
                    moduleAssessmentUIs.AddAssessmentToModuleUI();
                    break;
                case 12:
                    moduleAssessmentUIs.GetModuleAssessmentsUI();
                    break;
                case 13:
                    assessmentGradeUIs.UploadStudentResultUI();
                    break;
                case 14:
                    assessmentGradeUIs.GetStudentsAssessmentResultUI();
                    break;
                case 15:
                    moduleUIs.CalculateStudentModuleResultUI();
                    break;
                case 16:
                    programUIs.CalculateStudentProgramResultUI();
                    break;
                default:
                    Console.WriteLine("Invalid action. Please enter a number that corresponds to the action");
                    break;
            }
        }
	}
}
