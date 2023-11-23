using System;
using System.Drawing;
using AdminSystem.Database;
using AdminSystem.Models;
using AdminSystem.Utils;

namespace AdminSystem.Logic
{
	public class ModuleActions
	{
        private IEnumerable<Module> modules;

        public string CreateModule(string title)
        {
            
            if (title == null)
            {
                return ("Module Title and Duration must be entered.");
            }

            CodeFacade codeFacadeInstance = new CodeFacade();
            int moduleCode = codeFacadeInstance.GenerateCode(5);

            Module moduleInstance = new Module
            {
                Code = moduleCode,
                Title = title,
            };

            ModuleService moduleServiceInstance = new ModuleService();
            moduleServiceInstance.AddModule(moduleInstance);

            return ("Module added successfully!");
        }

        public IEnumerable<Module> GetModules()
        {
            ModuleService moduleServiceInstance = new ModuleService();
            modules = moduleServiceInstance.GetModules();
            return modules;
        }

        public string CalculateStudentModuleResult(int moduleCode, int programCode, int studentId)
        {

            if (moduleCode == null || studentId == null || programCode == null)
            {
                return ("Module code, Student code and program code must be entered.");
            }

            StudentService studentService = new StudentService();
            Student student = studentService.GetStudentByCode(studentId);

            ModuleService moduleService = new ModuleService();
            Module module = moduleService.GetModule(moduleCode);

            ProgrammeService programmeService = new ProgrammeService();
            Programme programme = programmeService.GetProgramme(programCode);

            ModuleGradeService moduleGradeService = new ModuleGradeService();

            if (student == null || module == null || programme == null)
            {
                return ("Student ID or Module Code or Programme code is not correct");
            }

            ModuleGrade studentModuleGrade = moduleGradeService.GetStudentModuleGrade(programme.Id, module.Id, student.Id);

            if(studentModuleGrade != null)
            {
                return ($"Student result for this module is: : {studentModuleGrade.Grade}");
            }

            ModuleAssessmentService moduleAssessmentService = new ModuleAssessmentService();
            IEnumerable<ModuleAssessment> moduleAssessments = moduleAssessmentService.GetModuleAssessmentsByModuleId(module.Id);
            double result = CalculateAssessmentScore(moduleAssessments, student);
            string studentGrade = DetermineModuleResult(result);
            if (result == -1)
            {
                return ($"Student result for this module is: : {studentGrade}");
            }

            ModuleGrade moduleGrade = new ModuleGrade
            {
                StudentId = student.Id,
                moduleId = module.Id,
                ProgramId = programme.Id,
                Grade = studentGrade,
                StudentScore = result,
            };

            moduleGradeService.AddModuleGrade(moduleGrade);

            return ($"Student result for this module is: : {studentGrade}");

        }

        public double CalculateAssessmentScore(IEnumerable<ModuleAssessment> assessments, Student student)
        {
            double studentAssessmentResult;
            int assessmentsMaxGradeSum = 0;
            double studentTotalScore = 0;

            if (!assessments.Any()) return -1; //indicates no assessment yet

            foreach(ModuleAssessment assessment in assessments)
            {
                AssessmentGradeService assessmentGradeService = new AssessmentGradeService();
                AssessmentGrade studentAssessmentGrade = assessmentGradeService.GetStudentAssessmentGrade(assessment.Id, student.Id);
                if (studentAssessmentGrade == null)
                {
                    studentTotalScore = -1; // indicates undefined
                    break;
                }
                AssessmentService assessmentService = new AssessmentService();
                Assessment assessmentDetails = assessmentService.GetAssessmentById(assessment.AssessmentId);
                assessmentsMaxGradeSum += assessmentDetails.MaximumGrade;
                studentTotalScore += studentAssessmentGrade.Score;
            }

            if (studentTotalScore == -1) return -1;

            studentAssessmentResult = studentTotalScore / studentTotalScore;
            double percent = 100.0;
            return studentAssessmentResult * percent;
        }

        public string DetermineModuleResult(double score)
        {
            if (score >= 50) return "Pass";
            else if (score >= 45) return "PassCompensation";
            else if (score >= 0) return "Fail";
            else return "Undefined";
        }
    }
}

