using System;
using AdminSystem.Database;
using System.Reflection;
using AdminSystem.Models;
using AdminSystem.Utils;
using Module = AdminSystem.Models.Module;
using System.Drawing;
using System.Xml.Linq;

namespace AdminSystem.Logic
{
	public class ProgramModuleActions
	{

        public void AddModuleToProgram()
        {
            try
            {
                Console.WriteLine("Provide the program code: ");
                int programCode = int.Parse(Console.ReadLine());

                Console.WriteLine("Provide the Module code: ");
                int moduleCode = int.Parse(Console.ReadLine());

                Console.WriteLine("Is the module optional for the program, true or false: ");
                Boolean moduleIsOptional = Boolean.Parse(Console.ReadLine());

                if (programCode == null || moduleCode == null)
                {
                    Console.WriteLine("Program and Module codes must be entered.");
                    return;
                }

                //check if program code and module code exist
                ProgrammeService programmeServiceInstance = new ProgrammeService();
                ModuleService moduleServiceInstance = new ModuleService();
                Programme fetchedProgram = programmeServiceInstance.GetProgramme(programCode);
                Module fetchedModule = moduleServiceInstance.GetModule(moduleCode);

                if (fetchedProgram == null || fetchedModule == null)
                {
                    Console.WriteLine("Program or Module does not exist");
                    return;
                }

                ProgramModuleService programmeModuleServiceInstance = new ProgramModuleService();

                IEnumerable<ProgrammeModule> existingProgramModules = programmeModuleServiceInstance.GetProgrammeModulesByProgramId(fetchedProgram.Id);

                ProgrammeModule programmeModule = new ProgrammeModule
                {
                    ProgrammeId = fetchedProgram.Id,
                    ModuleId = fetchedModule.Id,
                    IsOptional = moduleIsOptional,
                };

                if (!existingProgramModules.Any())
                {
                    programmeModuleServiceInstance.AddProgramModule(programmeModule);
                    Console.WriteLine("Module successfully added to the program!");
                    return;
                }
                //checks if exceed the maximum no of modules for the program
                if (existingProgramModules.Count() + 1 > fetchedProgram.NumberOfModules)
                {
                    Console.WriteLine("You cannot exceed the maximum no of modules for this program");
                    return;
                }

                int optionalModulesCount = existingProgramModules.Count(module => module.IsOptional);

                if (moduleIsOptional && optionalModulesCount + 1 > fetchedProgram.NumberOfOptionalModules)
                {
                    Console.WriteLine("You cannot exceed the maximum no of optional modules for this program");
                    return;
                }

                programmeModuleServiceInstance.AddProgramModule(programmeModule);
                Console.WriteLine("Module successfully added to the program!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Input. Please enter a valid number.");
            }


        }

        public void GetProgramModules()
        {
            try
            {
                Console.WriteLine("Provide the program code: ");
                int programCode = int.Parse(Console.ReadLine());

                ProgrammeService programServiceInstance = new ProgrammeService();
                Programme retrievedProgram = programServiceInstance.GetProgramme(programCode);

                if (retrievedProgram == null)
                {
                    Console.WriteLine("Program does not exist");
                    return;
                }

                ProgramModuleService programModuleServiceInstance = new ProgramModuleService();
                IEnumerable<ProgrammeModule>  programModules = programModuleServiceInstance.GetProgrammeModulesByProgramId(retrievedProgram.Id);
                if (!programModules.Any())
                {
                    Console.WriteLine("No Program modules exist");
                    return;
                }
                foreach (ProgrammeModule element in programModules)
                {
                    ModuleService moduleServiceInstance = new ModuleService();
                    Module retrievedModule = moduleServiceInstance.GetModuleById(element.ModuleId);
                    Console.WriteLine($"Program Name: {retrievedProgram.Title}, Module Name: {retrievedModule.Title}, is optional: {element.IsOptional}, Programme Code: {retrievedProgram.Code}, Module Code: {retrievedModule.Code}"); // prints out properties 
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Input. Please enter a valid number.");
            }
        }
    }
}

