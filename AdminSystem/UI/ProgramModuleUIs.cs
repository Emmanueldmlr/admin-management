using System;
using AdminSystem.Database;
using AdminSystem.Logic;
using AdminSystem.Models;

namespace AdminSystem.UI
{
    public class ProgramModuleUIs
    {
        ProgramModuleActions programModuleInstance = new ProgramModuleActions();

        public void AddModuleToProgramUI()
        {
            try
            {
                Console.WriteLine("Provide the program code: ");
                int programCode = int.Parse(Console.ReadLine());

                Console.WriteLine("Provide the Module code: ");
                int moduleCode = int.Parse(Console.ReadLine());

                Console.WriteLine("Is the module optional for the program, true or false: ");
                Boolean moduleIsOptional = Boolean.Parse(Console.ReadLine());

                string response = programModuleInstance.AddModuleToProgram(programCode, moduleCode, moduleIsOptional);
                Console.WriteLine(response);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Input. Please enter a valid number.");
            }

        }

        public void GetProgramModulesUI()
        {
            try
            {
                Console.WriteLine("Provide the program code: ");
                int programCode = int.Parse(Console.ReadLine());
                (string message, IEnumerable<ProgrammeModule> programModules, Programme retrievedProgram) response = programModuleInstance.GetProgramModules(programCode);
                if (!response.programModules.Any())
                {
                    Console.WriteLine(response.message);
                    return;
                }

                foreach (ProgrammeModule element in response.programModules)
                {
                    ModuleService moduleServiceInstance = new ModuleService();
                    Module retrievedModule = moduleServiceInstance.GetModuleById(element.ModuleId);
                    Console.WriteLine($"Program Name: {response.retrievedProgram.Title}, Module Name: {retrievedModule.Title}, is optional: {element.IsOptional}, Programme Code: {response.retrievedProgram.Code}, Module Code: {retrievedModule.Code}"); // prints out properties 
                }

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Input. Please enter a valid number.");
            }

        }
    }
}

