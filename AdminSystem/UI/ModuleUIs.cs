using System;
using AdminSystem.Logic;
using AdminSystem.Models;

namespace AdminSystem.UI
{
	public class ModuleUIs
	{
        ModuleActions moduleActionsInstance = new ModuleActions();
        private IEnumerable<Module> modules;

        public void CreateModuleUI()
		{
            Console.WriteLine("Provide the title of the Module: ");
            string title = Console.ReadLine();

            string response = moduleActionsInstance.CreateModule(title);
            Console.WriteLine(response);
        }

        public void GetModulesUI()
        {
            modules = moduleActionsInstance.GetModules();
            foreach (var module in modules)
            {
                Console.WriteLine($"Module title: {module.Title}, Module Code: {module.Code}"); // prints out properties 

            }
        }

        public void CalculateStudentModuleResultUI() {
            try {

                Console.WriteLine("Kindly Provide the Module code: ");
                int moduleCode = int.Parse(Console.ReadLine());

                Console.WriteLine("Kindly Provide the Program code: ");
                int programCode = int.Parse(Console.ReadLine());

                Console.WriteLine("Kindly Provide the Student Identification Number: ");
                int studentId = int.Parse(Console.ReadLine());

                string response = moduleActionsInstance.CalculateStudentModuleResult(moduleCode, programCode, studentId);
                Console.WriteLine(response);
            } 
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Input. Please enter a valid number.");
            }

        }

    }
}

