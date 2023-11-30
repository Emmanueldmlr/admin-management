using System;
using AdminSystem.Models;
namespace AdminSystem.Database
{
	public class ProgrammeService
	{
        private List<Programme> programmes;
        private DataContext context = new DataContext();

        public void AddProgramme(Programme programme)
        {
            context.Programmes.Add(programme);
            context.SaveChanges();
        }

        public IEnumerable<Programme> GetProgrammes()
        {
            programmes = context.Programmes.ToList();
            return programmes;
        }

        public Programme GetProgramme(int programmeId)
        {
            Programme retrievedProgram = context.Programmes
                          .FirstOrDefault(p => p.Code == programmeId); 
            return retrievedProgram;
        }
    }
}

