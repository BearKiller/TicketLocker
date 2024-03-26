using Helper;
using NLog;

string bugPath = "Tickets.csv";
string enhancementPath = "Enhancements.csv";
string taskPath = "Tasks.csv";
string option; 
string path = Directory.GetCurrentDirectory() + $"{Path.DirectorySeparatorChar}nlog.config";
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");



do{
    //Console.Clear();
    TicketFile bugFile = new TicketFile(bugPath);
    EnhancementFile enhancementFile = new EnhancementFile(enhancementPath);
    TaskFile taskFile = new TaskFile(taskPath);

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

        //Adds new data to the existing files
        case "2":
        logger.Info("User choice: \"2\"");
        Console.Clear();
        Console.WriteLine("Add what type of ticket?");
        Console.WriteLine("1.Bugs | 2.Enhancements | 3.Tasks");
        fileOption = Console.ReadLine();
        switch(fileOption) {

            //Adds bug tickets to the Tickets.csv file
            case "1":
            logger.Info("User choice: Add Bug ticket");
            if (File.Exists(bugPath)) {
                Bug newBug = new Bug();

                Console.WriteLine("Enter bug summary:");
                newBug.summary = Console.ReadLine();

                Console.WriteLine("Enter bug status:");
                newBug.status = Console.ReadLine();

                Console.WriteLine("Enter bug priority:");
                newBug.priority = Console.ReadLine();

                Console.WriteLine("Enter bug submitter:");
                newBug.submitter = Console.ReadLine();

                Console.WriteLine("Enter user assigned to this ticket:");
                newBug.assigned = Console.ReadLine();

                Console.WriteLine("Enter any watchers (type 'done' to finish):");
                newBug.watching = new List<string>();
                string watcherInput;
                do {
                    watcherInput = Console.ReadLine();
                    if (watcherInput.ToLower() != "done")
                        newBug.watching.Add(watcherInput);
                } while (watcherInput.ToLower() != "done");

                Console.WriteLine("Enter the severity of the bug:");
                newBug.severity = Console.ReadLine();
                
                bugFile.AddBugTicket(newBug);

            } else {
                logger.Warn("Tickets.csv is missing.");
            }
            break;

            //Adds enhancement tickets to the Enhancements.csv file
            case "2":
            logger.Info("User choice: Add Enhancement ticket");
            if (File.Exists(enhancementPath)) {
                Enhancement newEnhancement = new Enhancement();

                Console.WriteLine("Enter bug summary:");
                newEnhancement.summary = Console.ReadLine();

                Console.WriteLine("Enter bug status:");
                newEnhancement.status = Console.ReadLine();

                Console.WriteLine("Enter bug priority:");
                newEnhancement.priority = Console.ReadLine();

                Console.WriteLine("Enter bug submitter:");
                newEnhancement.submitter = Console.ReadLine();

                Console.WriteLine("Enter user assigned to this ticket:");
                newEnhancement.assigned = Console.ReadLine();

                Console.WriteLine("Enter any watchers (type 'done' to finish):");
                newEnhancement.watching = new List<string>();
                string watcherInput;
                do {
                    watcherInput = Console.ReadLine();
                    if (watcherInput.ToLower() != "done")
                        newEnhancement.watching.Add(watcherInput);
                } while (watcherInput.ToLower() != "done");

                Console.WriteLine("Enter available software:");
                newEnhancement.software = Console.ReadLine();
                
                Console.WriteLine("Enter cost:");
                newEnhancement.cost = Console.ReadLine();

                Console.WriteLine("Enter a reason:");
                newEnhancement.reason = Console.ReadLine();

                Console.WriteLine("Enter an estimate:");
                newEnhancement.estimate = Console.ReadLine();

                enhancementFile.AddEnhancementTicket(newEnhancement);

            } else {
                logger.Warn("Enhancements.csv is missing.");
            }
            break;

            //Adds task tickets to the Tasks.csv file
            case "3":
            logger.Info("User choice: Add Task ticket");
            if (File.Exists(taskPath)) {
                Task newTask = new Task();

                Console.WriteLine("Enter bug summary:");
                newTask.summary = Console.ReadLine();

                Console.WriteLine("Enter bug status:");
                newTask.status = Console.ReadLine();

                Console.WriteLine("Enter bug priority:");
                newTask.priority = Console.ReadLine();

                Console.WriteLine("Enter bug submitter:");
                newTask.submitter = Console.ReadLine();

                Console.WriteLine("Enter user assigned to this ticket:");
                newTask.assigned = Console.ReadLine();

                Console.WriteLine("Enter any watchers (type 'done' to finish):");
                newTask.watching = new List<string>();
                string watcherInput;
                do {
                    watcherInput = Console.ReadLine();
                    if (watcherInput.ToLower() != "done")
                        newTask.watching.Add(watcherInput);
                } while (watcherInput.ToLower() != "done");

                Console.WriteLine("Enter a project name:");
                newTask.projectName = Console.ReadLine();
                
                Console.WriteLine("Enter a due date:");
                newTask.dueDate = Console.ReadLine();

                taskFile.AddTaskTicket(newTask);

            } else {
                logger.Warn("Tasks.csv is missing.");
            }
            break;
        }
        break;
    }
    

} while (option == "1" || option == "2");
logger.Info("Program ended");
