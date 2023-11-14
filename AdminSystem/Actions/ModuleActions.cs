using System;
using System.Drawing;
using AdminSystem.Database;
using AdminSystem.Models;
using AdminSystem.Utils;

namespace AdminSystem.Actions
{
	public class ModuleActions
	{
        private IEnumerable<Module> modules;
        public void CreateModule()
        {
            Console.WriteLine("Provide the title of the Module: ");
            string title = Console.ReadLine();

            if (title == null)
            {
                Console.WriteLine("Module Title and Duration must be entered.");
                return;
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

            Console.WriteLine("Module added successfully!");
        }

        public void GetModules()
        {
            ModuleService moduleServiceInstance = new ModuleService();
            modules = moduleServiceInstance.GetModules();
            foreach (var module in modules)
            {
                Console.WriteLine($"Module title: {module.Title}, Module Code: {module.Code}"); // prints out properties 

            }
        }
    }
}

