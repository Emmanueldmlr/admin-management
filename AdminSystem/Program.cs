using AdminSystem.Database;
using AdminSystem.Actions;

// this ensures the database is created when the application is started
AdminDatabaseManager.Instance.AdminSystemDbFacade.EnsureCreated(); 

//Displays initial information for users
Console.WriteLine("Hi, this is an Admin system made by Bakare Damilare E. for Object Oriented Programming using C#");
Console.WriteLine("Use numbers to define the actions you want to perform");
Console.WriteLine("Press 1 to create a new Programme: ");
Console.WriteLine("Press 2 to View All Programmes: ");
Console.WriteLine("Press 3 to Create a Student: ");
Console.WriteLine("Press 4 to View All Students: ");
Console.WriteLine("Press 5 to Create a New Module: ");
Console.WriteLine("Press 6 to View All Modules: ");
Console.WriteLine("Press 7 to Add a Module to a Program: ");
Console.WriteLine("Press 8 to View all Program Modules: ");
Console.WriteLine("Press 9 to Create an Assessment: ");
Console.WriteLine("Press 10 to View all Assessments: ");
Console.WriteLine("Press 11 to Add an Assessment to a Module: ");
Console.WriteLine("Press 12 to View all Module Assessment: ");
//uses try-catch to handle invalid input from the user
try
{
    int userAction = int.Parse(Console.ReadLine());
    Console.WriteLine(userAction);
    ProgrammeActions programmeActionsInstance = new ProgrammeActions();
    StudentActions studentActionsInstance = new StudentActions();
    ModuleActions moduleActionsInstance = new ModuleActions();
    ProgramModuleActions programModuleInstance = new ProgramModuleActions();
    AssessmentActions assessmentActionsInstance = new AssessmentActions();
    ModuleAssessmentAction moduleAssessmentActionsInstance = new ModuleAssessmentAction();

    switch (userAction)
    {
        case 1:
            programmeActionsInstance.CreateProgram();
            break;
        case 2:
            programmeActionsInstance.GetProgrammes();
            break;
        case 3:
            studentActionsInstance.CreateStudent();
            break;
        case 4:
            studentActionsInstance.GetStudents();
            break;
        case 5:
            moduleActionsInstance.CreateModule();
            break;
        case 6:
            moduleActionsInstance.GetModules();
            break;
        case 7:
            programModuleInstance.AddModuleToProgram();
            break;
        case 8:
            programModuleInstance.GetProgramModules();
            break;
        case 9:
            assessmentActionsInstance.CreateAssessment();
            break;
        case 10:
            assessmentActionsInstance.GetAssessments();
            break;
        case 11:
            moduleAssessmentActionsInstance.AddAssessmentToModule();
            break;
        case 12:
            moduleAssessmentActionsInstance.GetModuleAssessments();
            break;
        default:
            Console.WriteLine("Invalid action. Please enter a number that corresponds to the action");
            break;
    }
}
catch (FormatException ex)
{
    Console.WriteLine("Invalid Input. Please enter a valid number.");
}




