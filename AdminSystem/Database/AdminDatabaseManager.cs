using Microsoft.EntityFrameworkCore.Infrastructure;


namespace AdminSystem.Database
{
	public class AdminDatabaseManager
	{
        private static readonly Lazy<AdminDatabaseManager> instance =
            new Lazy<AdminDatabaseManager>(() => new AdminDatabaseManager());

        public static AdminDatabaseManager Instance => instance.Value;

        public DatabaseFacade AdminSystemDbFacade { get; }

        private AdminDatabaseManager()
        {
            AdminSystemDbFacade = new DatabaseFacade(new DataContext());
            AdminSystemDbFacade.EnsureCreated();
        }
    }

}

