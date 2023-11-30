using System;
using AdminSystem.Models;

namespace AdminSystem.Database
{
	public class ModuleService
	{
        private List<Module> modules;
        private DataContext context = new DataContext();

        public void AddModule(Module module)
        {
            context.Modules.Add(module);
            context.SaveChanges();
        }

        public IEnumerable<Module> GetModules()
        {
            modules = context.Modules.ToList();

            return modules;
        }

        public Module GetModule(int moduleId)
        {
            Module retrievedModules = context.Modules
                          .FirstOrDefault(p => p.Code == moduleId);

            return retrievedModules;
        }

        public Module GetModuleById(int moduleId)
        {
            Module retrievedModules = context.Modules
                          .FirstOrDefault(p => p.Id == moduleId);

            return retrievedModules;
        }
    }
}

