using System;
using AdminSystem.Models;
namespace AdminSystem.Database
{
	public class ProgrammeService
	{
        private List<Programme> programmes;

        public void AddProgramme(Programme programme)
        {
            using var context = new DataContext();
            context.Programmes.Add(programme);
            context.SaveChanges();
        }

        public IEnumerable<Programme> GetProgrammes()
        {
            using var context = new DataContext();

            programmes = context.Programmes.ToList();

            return programmes;
        }

        public Programme GetProgramme(int programmeId)
        {
            using var context = new DataContext();

            Programme retrievedProgram = context.Programmes
                          .FirstOrDefault(p => p.Code == programmeId); 

            return retrievedProgram;
        }
    }
}

