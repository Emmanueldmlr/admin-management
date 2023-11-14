using System;
using System.Reflection;
using AdminSystem.Models;

namespace AdminSystem.Database
{
	public class ProgramModuleService
	{
        private List<ProgrammeModule> programmeModules;

        public void AddProgramModule(ProgrammeModule programmeModule)
        {
            using var context = new DataContext();
            context.ProgrammeModules.Add(programmeModule);
            context.SaveChanges();
        }

        public IEnumerable<ProgrammeModule> GetProgrammeModules()
        {
            using var context = new DataContext();

            programmeModules = context.ProgrammeModules.ToList();

            return programmeModules;
        }

        public ProgrammeModule GetProgramModule(int moduleId, int programId)
        {
            using var context = new DataContext();

            ProgrammeModule retrievedRecord = context.ProgrammeModules
                          .FirstOrDefault(p => p.ModuleId == moduleId && p.ProgrammeId == programId);

            return retrievedRecord;
        }

        public IEnumerable<ProgrammeModule> GetProgrammeModulesByProgramId(int programId)
        {
            using var context = new DataContext();

            programmeModules = context.ProgrammeModules
                          .Where(p => p.ProgrammeId == programId).ToList(); ;

            return programmeModules;
        }
    }
}

