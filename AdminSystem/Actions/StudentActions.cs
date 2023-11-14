using System;
using AdminSystem.Database;
using AdminSystem.Models;
using AdminSystem.Utils;

namespace AdminSystem.Actions
{
	public class StudentActions
	{
        private IEnumerable<Student> students;
        public void CreateStudent()
        {

            try
            {
                Console.WriteLine("Provide the name of the student: ");
                string studentName = Console.ReadLine();

                Console.WriteLine("Provide the program ID: ");
                int programId = int.Parse(Console.ReadLine());

                Console.WriteLine("Provide the Academic year: ");
                int academicYear = int.Parse(Console.ReadLine());

                if (studentName == null || programId == null || academicYear == null)
                {
                    Console.WriteLine("Programme Id, student name and academic year must be entered.");
                    return;
                }

                ProgrammeService programmeServiceInstance = new ProgrammeService();

                Programme retrievedProgram = programmeServiceInstance.GetProgramme(programId);

                if (retrievedProgram == null)
                {
                    Console.WriteLine("Programme does not exist.");
                    return;
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

                Console.WriteLine("Student added successfully!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Input. Please enter a valid value for the academic year");
            }

        }

        public void GetStudents()
        {
            StudentService studentServiceInstance = new StudentService();
            students = studentServiceInstance.GetStudents();
            CohortService cohortServiceInstance = new CohortService();
            IEnumerable<Cohort> cohorts = cohortServiceInstance.GetCohorts();
            
            foreach (var student in students)
            {
                foreach(var cohort in cohorts)
                {
                    if(student.CohortId == cohort.Id)
                    {
                        Console.WriteLine($"Name: {student.Name}, IdentficationNumber: {student.IdentificationNumber}, cohortYear: {cohort.Year}, Programme Code: {cohort.ProgrammeId}"); // prints out properties 
                    }
                }
            }
        }
    }
}

