using System;
using AdminSystem.Database;
using AdminSystem.Logic;
using AdminSystem.Models;

namespace AdminSystem.UI
{
	public class StudentUIs
	{
        StudentActions studentActionInstance = new StudentActions();
        CohortService cohortServiceInstance = new CohortService();
        private IEnumerable<Student> students;
        private IEnumerable<Cohort> cohorts;

        public void CreateStudentUI()
		{
            try
            {
                Console.WriteLine("Provide the name of the student: ");
                string studentName = Console.ReadLine();

                Console.WriteLine("Provide the program ID: ");
                int programId = int.Parse(Console.ReadLine());

                Console.WriteLine("Provide the Academic year: ");
                int academicYear = int.Parse(Console.ReadLine());

                string response = studentActionInstance.CreateStudent(studentName, programId, academicYear);
            }  
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Input. Please enter a valid value for the academic year");
            }
        }

        public void GetStudentsUI()
        {
            students = studentActionInstance.GetStudents();
            cohorts = cohortServiceInstance.GetCohorts();

            foreach (var student in students)
            {
                foreach (var cohort in cohorts)
                {
                    if (student.CohortId == cohort.Id)
                    {
                        Console.WriteLine($"Name: {student.Name}, IdentficationNumber: {student.IdentificationNumber}, cohortYear: {cohort.Year}, Programme Code: {cohort.ProgrammeId}"); // prints out properties 
                    }
                }
            }
        }
    }
}

