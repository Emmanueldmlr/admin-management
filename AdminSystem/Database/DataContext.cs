using Microsoft.EntityFrameworkCore;
using AdminSystem.Models;
namespace AdminSystem
{
	public class DataContext:DbContext
    {
        // configures the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Get the base directory of the application
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // Combine the base directory with the database file name

            string dbPath = Path.Combine(basePath, "AdminSystem.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");

        }

        // sets the entities details
        public DbSet<Student> Students { get; set; }

        public DbSet<Programme> Programmes { get; set; }

        public DbSet<ProgrammeModule> ProgrammeModules { get; set; }

        public DbSet<ModuleAssessment> ModuleAssessments { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Cohort> Cohorts { get; set; }

        public DbSet<AssessmentGrade> AssessmentGrades { get; set; }

        public DbSet<Assessment> Assessments { get; set; }

        public DbSet<ModuleGrade> ModuleGrades { get; set; }

    }
}

