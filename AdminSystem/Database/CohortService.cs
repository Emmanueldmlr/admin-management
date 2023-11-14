using System;
using System.Drawing;
using AdminSystem.Models;

namespace AdminSystem.Database
{
	public class CohortService
	{
        private List<Cohort> cohorts;
        public int AddCohort(Cohort cohort)
        {
            using var context = new DataContext();
            context.Cohorts.Add(cohort);
            context.SaveChanges();
            return cohort.Id;
        }

        public Cohort CreateOrFetchCohort(int programId, int year)
        {
            using var context = new DataContext();
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
            using var context = new DataContext();

            cohorts = context.Cohorts.ToList();

            return cohorts;
        }
    }
}

 