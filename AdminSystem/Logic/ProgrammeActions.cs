using System;
using AdminSystem.Models;
using AdminSystem.Utils;
using AdminSystem.Database;
using static System.Formats.Asn1.AsnWriter;

namespace AdminSystem.Logic
{
	public class ProgrammeActions
	{
        public string CreateProgram(string title, int duration, int noOfOptionalModules)
        {
            if (title == null || duration == null)
            {
                return("Programme Title and Duration must be entered.");
            }

            if(noOfOptionalModules > 4)
            {
                return("No of Optional Courses can not be more than 4");
            }

            CodeFacade codeFacadeInstance = new CodeFacade();
            int programCode = codeFacadeInstance.GenerateCode(6);
            int noOfModules = Programme.GetProgramModuleSize(duration);

            if(noOfModules != 6 && noOfModules != 12)
            {
                return("Invalid program duration");
            }

            Programme programInstance = new Programme
            {
                Code = programCode,
                Title = title,
                Duration = duration,
                NumberOfModules = noOfModules,
                NumberOfOptionalModules = noOfOptionalModules
              
            };
                
            ProgrammeService programmeServiceInstance = new ProgrammeService();
            programmeServiceInstance.AddProgramme(programInstance);

            return("Programme added successfully!");

        }

        public IEnumerable<Programme> GetProgrammes()
        {
            ProgrammeService programmeServiceInstance = new ProgrammeService();
             return programmeServiceInstance.GetProgrammes();
        }

        public string CalculateStudentProgramResult(int programCode, int studentCode)
        {
            if (programCode == null || studentCode == null)
            {
                return ("Programme and Student Code must be entered.");
            }

            ProgrammeService programmeServiceInstance = new ProgrammeService();
            StudentService studentService = new StudentService();

            Student student = studentService.GetStudentByCode(studentCode);

            ProgrammeService programmeService = new ProgrammeService();
            Programme programme = programmeService.GetProgramme(programCode);

            if (student == null || programme == null)
            {
                return ("Student ID or Programme code is not correct");
            }

            GradeService gradeService = new GradeService();
            Grade studentGrade = gradeService.GetStudentProgramGrade(programme.Id, student.Id);

            if (studentGrade != null)
            {
                return ($"ID: {programme.Id}, Name: {programme.Title}, Student Name: {student.Name}, Student ID: {student.IdentificationNumber}, Student Score (%): {studentGrade.Score}, Student Grade (%): {studentGrade.Result}"); // prints out properties 
            }

            ProgramModuleService programModuleService = new ProgramModuleService();
            IEnumerable<ProgrammeModule> programModules = programModuleService.GetProgrammeModulesByProgramId(programme.Id);

            if (!programModules.Any())
            {
                return ("No Module Added yet");
            }

            double studentProgramResult = CalculateProgamScore(programModules, student);

            string grade = ComputeProgramResult(studentProgramResult);

            if (studentProgramResult == -1)
            {
                return ($"Student result for this Program is: : {grade}");
            }

            Grade programGrade = new Grade
            {
                StudentId = student.Id,
                Score = studentProgramResult,
                ProgramId = programme.Id,
                Result = grade,
            };

            gradeService.AddProgramGrade(programGrade);

            return ($"Student result for this program is: : {grade}");
            
        }

        public string ComputeProgramResult(double studentProgramScore)
        {

            if (studentProgramScore >= 70)
            {
                return "Distinction";
            }
            else if (studentProgramScore >= 50)
            {
                return "Pass";
            }
            else if(studentProgramScore >= 0)
            {
                return "Fail";
            }

            else return "Undefined";
        }

        public double CalculateProgamScore(IEnumerable<ProgrammeModule> programmeModules, Student student)
        {
            double studentProgramResult = 0;
            int moduleCount = 0;
            double studentTotalScore = 0;
            if (!programmeModules.Any()) return -1;
            foreach(ProgrammeModule module in programmeModules)
            {
                ModuleGradeService moduleGradeService = new ModuleGradeService();
                ModuleGrade moduleGrade = moduleGradeService.GetStudentModuleGrade(module.ProgrammeId, module.ModuleId, student.Id);
                if(moduleGrade is null && !module.IsOptional)
                {
                    studentProgramResult = -1;
                    break;
                }
                studentTotalScore += moduleGrade.StudentScore;
                moduleCount += 1;
            }
            if (studentProgramResult == -1 ) return -1;
            return (studentTotalScore / (moduleCount * 100)) * 100;
        }

    }
}


