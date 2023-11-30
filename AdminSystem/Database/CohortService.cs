using System;
using System.Drawing;
using AdminSystem.Models;

namespace AdminSystem.Database
{
	public class CohortService
	{
        private List<Cohort> cohorts;
        private DataContext context = new DataContext();
        public int AddCohort(Cohort cohort)
        {
            context.Cohorts.Add(cohort);
            context.SaveChanges();
            return cohort.Id;
        }

        public Cohort CreateOrFetchCohort(int programId, int year)
        {
            Cohort retrievedCohort = context.Cohorts.FirstOrDefault(p => p.ProgrammeId == programId);
            if(retrievedCohort == null)
            {
                Cohort newCohort = new Cohort
                {
                    ProgrammeId = programId,
                    Year = year,
                };
                int newCohortId = this.AddCohort(newCohort);
                return newCohort;
            }
            return retrievedCohort;
        }

        public IEnumerable<Cohort> GetCohorts()
        {
            cohorts = context.Cohorts.ToList();
            return cohorts;
        }
    }
}

 