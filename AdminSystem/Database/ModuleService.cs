using System;
using AdminSystem.Models;

namespace AdminSystem.Database
{
	public class ModuleService
	{
        private List<Module> modules;

        public void AddModule(Module module)
        {
            using var context = new DataContext();
            context.Modules.Add(module);
            context.SaveChanges();
        }

        public IEnumerable<Module> GetModules()
        {
            using var context = new DataContext();

            modules = context.Modules.ToList();

            return modules;
        }

        public Module GetModule(int moduleId)
        {
            using var context = new DataContext();

            Module retrievedModules = context.Modules
                          .FirstOrDefault(p => p.Code == moduleId);

            return retrievedModules;
        }

        public Module GetModuleById(int moduleId)
        {
            using var context = new DataContext();

            Module retrievedModules = context.Modules
                          .FirstOrDefault(p => p.Id == moduleId);

            return retrievedModules;
        }
    }
}

