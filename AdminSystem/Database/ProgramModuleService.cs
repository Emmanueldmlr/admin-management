using System;
using System.Reflection;
using AdminSystem.Models;

namespace AdminSystem.Database
{
	public class ProgramModuleService
	{
        private List<ProgrammeModule> programmeModules;
        private DataContext context = new DataContext();

        public void AddProgramModule(ProgrammeModule programmeModule)
        {
            context.ProgrammeModules.Add(programmeModule);
            context.SaveChanges();
        }

        public IEnumerable<ProgrammeModule> GetProgrammeModules()
        {
            programmeModules = context.ProgrammeModules.ToList();
            return programmeModules;
        }

        public ProgrammeModule GetProgramModule(int moduleId, int programId)
        {
            ProgrammeModule retrievedRecord = context.ProgrammeModules
                          .FirstOrDefault(p => p.ModuleId == moduleId && p.ProgrammeId == programId);

            return retrievedRecord;
        }

        public IEnumerable<ProgrammeModule> GetProgrammeModulesByProgramId(int programId)
        {
            programmeModules = context.ProgrammeModules
                          .Where(p => p.ProgrammeId == programId).ToList(); ;
            return programmeModules;
        }
    }
}

