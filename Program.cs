using Helper;
using NLog;

string bugPath = "Tickets.csv";
string enhancementPath = "Enhancements.csv";
string taskPath = "Tasks.csv";
string option; 
string path = Directory.GetCurrentDirectory() + $"{Path.DirectorySeparatorChar}nlog.config";
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

TicketFile bugFile = new TicketFile(bugPath);
EnhancementFile enhancementFile = new EnhancementFile(enhancementPath);
TaskFile taskFile = new TaskFile(taskPath);

do{
    //Console.Clear();
    Console.WriteLine("\n1.) Read tickets from file.");
    Console.WriteLine("2.) Append new ticket to file.");
    Console.WriteLine("3.) Exit program.");
    Console.Write("Enter option > ");
    option = Console.ReadLine();

    switch(option) {

        //Reads data from the Tickets.csv file
        case "1":
        logger.Info("User choice: \"1\"");
        string fileOption;
        Console.Clear();
        Console.WriteLine("Read what file?");
        Console.WriteLine("1.Bugs | 2.Enhancements | 3.Tasks");
        fileOption = Console.ReadLine();
        switch(fileOption) {

            //Reads from the Tickets.csv file
            case "1":
            if (File.Exists(bugPath)) {
                foreach (Bug bug in bugFile.Bugs) {
                    Console.Write($"\nID: {bug.ticketID} - ");
                    Console.WriteLine($"Summary: {bug.summary}");
                    Console.WriteLine($"Status: {bug.status}");
                    Console.Write($"Priority: {bug.priority} - ");
                    Console.Write($"Submitter: {bug.submitter} - ");
                    Console.WriteLine($"Assigned: {bug.assigned}");
                    Console.WriteLine($"Watchers: {string.Join(", ", bug.watching)}");
                    Console.WriteLine($"Severity: {bug.severity}");
                }
                break;
            } else {
            Console.WriteLine("File does not exist.");
            }
            break;

            //Reads from the Enhancements.csv file
            case "2":
            if (File.Exists(enhancementPath)) {
                foreach (Enhancement enhancement in enhancementFile.Enhancements) {
                    Console.Write($"\nID: {enhancement.ticketID} - ");
                    Console.WriteLine($"Summary: {enhancement.summary}");
                    Console.WriteLine($"Status: {enhancement.status}");
                    Console.Write($"Priority: {enhancement.priority} - ");
                    Console.Write($"Submitter: {enhancement.submitter} - ");
                    Console.WriteLine($"Assigned: {enhancement.assigned}");
                    Console.WriteLine($"Watchers: {string.Join(", ", enhancement.watching)}");
                    Console.WriteLine($"Software: {enhancement.software}");
                    Console.WriteLine($"Cost: {enhancement.cost}");
                    Console.WriteLine($"Reason: {enhancement.reason}");
                    Console.WriteLine($"Estimate: {enhancement.estimate}");
                }
                break;
            } else {
            Console.WriteLine("File does not exist.");
            }
            break;

            //Reads from the Tasks.csv file
            case "3":
            if (File.Exists(taskPath)) {
                foreach (Task task in taskFile.Tasks) {
                    Console.Write($"\nID: {task.ticketID} - ");
                    Console.WriteLine($"Summary: {task.summary}");
                    Console.WriteLine($"Status: {task.status}");
                    Console.Write($"Priority: {task.priority} - ");
                    Console.Write($"Submitter: {task.submitter} - ");
                    Console.WriteLine($"Assigned: {task.assigned}");
                    Console.WriteLine($"Watchers: {string.Join(", ", task.watching)}");
                    Console.WriteLine($"Project Name: {task.projectName}");
                    Console.WriteLine($"Due Date: {task.dueDate}");
                }
                break;
            } else {
            Console.WriteLine("File does not exist.");
            }
            break;
        }
        break;

        //Adds new data to the existing Tickets.csv file
        case "2":
        break;
    }

} while (option == "1" || option == "2");
logger.Info("Program ended");
