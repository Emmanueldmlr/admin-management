using System;
using AdminSystem.Models;
using AdminSystem.Utils;
using AdminSystem.Database;

namespace AdminSystem.Actions
{
	public class ProgrammeActions
	{
        private IEnumerable<Programme> programmes;

        public void CreateProgram()
        {
            try
            {
                Console.WriteLine("Provide the title of the Programme: ");
                string title = Console.ReadLine();

                Console.WriteLine("What's the Programme duration: ");
                int duration = int.Parse(Console.ReadLine());

                Console.WriteLine("What's the Number of Optional Modules: ");
                int noOfOptionalModules = int.Parse(Console.ReadLine());

                if (title == null || duration == null)
                {
                    Console.WriteLine("Programme Title and Duration must be entered.");
                    return;
                }

                if(noOfOptionalModules > 4)
                {
                    Console.WriteLine("No of Optional Courses can not be more than 4");
                    return;
                }

                CodeFacade codeFacadeInstance = new CodeFacade();
                int programCode = codeFacadeInstance.GenerateCode(6);
                int noOfModules = Programme.GetProgramModuleSize(duration);

                if(noOfModules != 6 && noOfModules != 12)
                {
                    Console.WriteLine(noOfModules);
                    Console.WriteLine("Invalid program duration");
                    return;
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

                Console.WriteLine("Programme added successfully!");

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Input. Please enter a valid number.");
            }
            
        }

        public void GetProgrammes()
        {
            ProgrammeService programmeServiceInstance = new ProgrammeService();
             programmes = programmeServiceInstance.GetProgrammes();
            if (!programmes.Any())
            {
                Console.WriteLine("No Program added yet");
                return;
            }
            foreach (var programme in programmes)
            {
                Console.WriteLine($"ID: {programme.Id}, Name: {programme.Title}, Duration: {programme.Duration} Year(s), Programme Code: {programme.Code}, No of Modules: {programme.NumberOfModules}, No of Optional Moodules: {programme.NumberOfOptionalModules}"); // prints out properties 
            }
            return;
        }
    }
}


