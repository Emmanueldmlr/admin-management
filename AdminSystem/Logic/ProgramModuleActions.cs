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
        ProgrammeService programmeServiceInstance = new ProgrammeService();
        ModuleService moduleServiceInstance = new ModuleService();

        public string AddModuleToProgram(int programCode, int moduleCode, Boolean moduleIsOptional)
        {

            if (programCode == null || moduleCode == null)
            {
                return("Program and Module codes must be entered.");
            }

            //check if program code and module code exist
            Programme fetchedProgram = programmeServiceInstance.GetProgramme(programCode);
            Module fetchedModule = moduleServiceInstance.GetModule(moduleCode);

            if (fetchedProgram == null || fetchedModule == null)
            {
                return ("Program or Module does not exist");
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
                return ("Module successfully added to the program!");
            }
            //checks if exceed the maximum no of modules for the program
            if (existingProgramModules.Count() + 1 > fetchedProgram.NumberOfModules)
            {
                return("You cannot exceed the maximum no of modules for this program");
            }

            int optionalModulesCount = existingProgramModules.Count(module => module.IsOptional);

            if (moduleIsOptional && optionalModulesCount + 1 > fetchedProgram.NumberOfOptionalModules)
            {
                return("You cannot exceed the maximum no of optional modules for this program");
            }

            programmeModuleServiceInstance.AddProgramModule(programmeModule);
            return("Module successfully added to the program!");

        }

        public (string Message, IEnumerable<ProgrammeModule> programModules, Programme program) GetProgramModules(int programCode)
        {
 
            Programme retrievedProgram = programmeServiceInstance.GetProgramme(programCode);

            if (retrievedProgram == null)
            {
                return ("Program does not exist", null, null);
            }

            ProgramModuleService programModuleServiceInstance = new ProgramModuleService();
            IEnumerable<ProgrammeModule>  programModules = programModuleServiceInstance.GetProgrammeModulesByProgramId(retrievedProgram.Id);
            if (!programModules.Any())
            {
                return ("No Program modules exist", null, null);

            }

            return (null, programModules, retrievedProgram);
        }
    }
}

