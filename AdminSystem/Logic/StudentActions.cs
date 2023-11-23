using System;
using AdminSystem.Database;
using AdminSystem.Models;
using AdminSystem.Utils;

namespace AdminSystem.Logic
{
	public class StudentActions
	{
        private IEnumerable<Student> students;
        public string CreateStudent(string studentName, int programId, int academicYear)
        {

            if (studentName == null || programId == null || academicYear == null)
            {
                return ("Programme Id, student name and academic year must be entered.");
            }

            ProgrammeService programmeServiceInstance = new ProgrammeService();

            Programme retrievedProgram = programmeServiceInstance.GetProgramme(programId);

            if (retrievedProgram == null)
            {
                return ("Programme does not exist.");
            }

            CohortService cohortServiceInstance = new CohortService();
            Cohort cohort = cohortServiceInstance.CreateOrFetchCohort(programId, academicYear);

            CodeFacade codeFacadeInstance = new CodeFacade();
            int studentIndentificationNumber = codeFacadeInstance.GenerateCode(6, academicYear);
            Student studentInstance = new Student
            {
                Name = studentName,
                CohortId = cohort.Id,
                IdentificationNumber = studentIndentificationNumber,
            };

            StudentService studentServiceInstance = new StudentService();
            studentServiceInstance.AddStudent(studentInstance);

            return("Student added successfully!");

        }

        public IEnumerable<Student> GetStudents()
        {
            StudentService studentServiceInstance = new StudentService();
            students = studentServiceInstance.GetStudents();
            return students;
        }
    }
}

