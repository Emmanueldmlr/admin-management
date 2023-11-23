using AdminSystem.Database;
using AdminSystem.Utils;

// this ensures the database is created when the application is started
AdminDatabaseManager.Instance.AdminSystemDbFacade.EnsureCreated();

//Displays initial information for users
foreach (string option in MenuOptions.Options)
{
    Console.WriteLine(option);
}

//uses try-catch to handle invalid input from the user
try
{
    int userAction = int.Parse(Console.ReadLine());
    StartupProcess.InitiateProcess(userAction);
}
catch (FormatException ex)
{
    Console.WriteLine("Invalid Input. Please enter a valid number.");
}

