using System;
using AdminSystem.Logic;
using AdminSystem.Models;

namespace AdminSystem.UI
{
	public class ProgramUIs
	{
        ProgrammeActions programmeActionsInstance = new ProgrammeActions();
        private IEnumerable<Programme> programmes;

        public void CreateProgramUI()
		{
            try
            {
                Console.WriteLine("Provide the title of the Programme: ");
                string title = Console.ReadLine();

                Console.WriteLine("What's the Programme duration: ");
                int duration = int.Parse(Console.ReadLine());

                Console.WriteLine("What's the Number of Optional Modules: ");
                int noOfOptionalModules = int.Parse(Console.ReadLine());

                string response = programmeActionsInstance.CreateProgram(title, duration, noOfOptionalModules);

                Console.WriteLine(response);
            }        
            catch (FormatException ex)
            {
                Console.Write("Invalid Input. Please enter a valid number.");
            }

        }

        public void GetProgrammesUI()
        {
            programmes = programmeActionsInstance.GetProgrammes();

            if (!programmes.Any())
            {
                Console.WriteLine("No Program added yet");
                return;
            }

            foreach (var programme in programmes)
            {
                Console.WriteLine($"ID: {programme.Id}, Name: {programme.Title}, Duration: {programme.Duration} Year(s), Programme Code: {programme.Code}, No of Modules: {programme.NumberOfModules}, No of Optional Moodules: {programme.NumberOfOptionalModules}"); // prints out properties 
            }

        }

        public void CalculateStudentProgramResultUI()
        {
            try
            {
                Console.WriteLine("Provide the Programme Code: ");
                int programCode = int.Parse(Console.ReadLine());

                Console.WriteLine("What's the Student Identification nNumber: ");
                int studentCode = int.Parse(Console.ReadLine());

                string response = programmeActionsInstance.CalculateStudentProgramResult(programCode, studentCode);
                Console.WriteLine(response);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Input. Please enter a valid number.");
            }
        }

    }
}

