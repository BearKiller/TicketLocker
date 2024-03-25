using Helper;
using NLog;

string file = "Tickets.csv";
string option; 
string path = Directory.GetCurrentDirectory() + $"{Path.DirectorySeparatorChar}nlog.config";
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

do{
    Console.Clear();
    Console.WriteLine("1.) Read tickets from file.");
    Console.WriteLine("2.) Create new ticket file.");
    Console.WriteLine("3.) Append new ticket to file.");
    Console.WriteLine("4.) Exit program.");
    Console.Write("Enter option > ");
    option = Console.ReadLine();

    switch(option) {

        //Reads data from the Tickets.csv file
        case "1":
        if (File.Exists(file)) {
            StreamReader sr = new StreamReader("Tickets.csv");
            while (!sr.EndOfStream) {
                string? line = sr.ReadLine();
                string[] arr = line.Split(',');
                string watchersSep = line.Split(',').Last();
                string[] watchersArr = watchersSep.Split('|');
                string watchers = String.Join(", ", watchersArr);
                Console.WriteLine("\nTicket ID: {0} \n Summary: {1} \n Status: {2} \n Priority: {3} \n Submitter: {4} \n Watching: {5} \n", arr[0], arr[1], arr[2], arr[3], arr[4], watchers);
            } sr.Close();

        }
        else {
            Console.WriteLine("File does not exist.");
        }
            break;

        //Creates a new ticket file
        case "2":
        if (!File.Exists(file)) {
            CreateTicket(file);
            
        }
        else {
            Console.Write("File already exists. Overwrite? (Y/N) > ");
            string overwrite = Console.ReadLine().ToUpper();
            if (overwrite == "Y") {
                CreateTicket(file);
                
            }
            else {
                break;
            }
        }
            break;

        //Adds new data to the existing Tickets.csv file
        case "3":
        if (!File.Exists(file)) {
            Console.WriteLine("Please create file first.");
        } else {
            AppendTicket(file);
        }
            break;
    }

} while (option == "1" || option == "2" || option == "3");



static void CreateTicket(string file) {

    Console.Clear();
    string summary = Inputs.GetString("Enter a summary.");
    string status = Inputs.GetString("Enter the status of the ticket.");
    string priority = Inputs.GetString("Enter priority of the ticket.");
    string submitter = Inputs.GetString("Enter submitter.");
    string assigned = Inputs.GetString("Enter who this ticket is assigned to.");
    string watchers = Inputs.GetString("Enter any watchers (separated by commas)");
    string[] watcher = watchers.Split(", ");
    string watchersJoined = String.Join("|", watcher);

    Tickets newTicket = new Tickets(summary, status, priority, submitter, assigned, watchersJoined);

    StreamWriter sw = new StreamWriter(file);
    sw.WriteLine(newTicket.ID + "," + newTicket.Summary + "," + newTicket.Status + "," + newTicket.Priority + "," + newTicket.Submitter + "," + newTicket.Assigned + "," + newTicket.Watchers);
    sw.Close();

}



static void AppendTicket(string file) {

    Console.Clear();
    string summary = Inputs.GetString("Enter a summary.");
    string status = Inputs.GetString("Enter the status of the ticket.");
    string priority = Inputs.GetString("Enter priority of the ticket.");
    string submitter = Inputs.GetString("Enter submitter.");
    string assigned = Inputs.GetString("Enter who this ticket is assigned to.");
    string watchers = Inputs.GetString("Enter any watchers (separated by commas)");
    string[] watcher = watchers.Split(", ");
    string watchersJoined = String.Join("|", watcher);

    Tickets newTicket = new Tickets(summary, status, priority, submitter, assigned, watchersJoined);

    StreamWriter sw = new StreamWriter(file, true);
    sw.WriteLine(newTicket.ID + "," + newTicket.Summary + "," + newTicket.Status + "," + newTicket.Priority + "," + newTicket.Submitter + "," + newTicket.Assigned + "," + newTicket.Watchers);
    sw.Close();
}



public class Tickets {
    public int ID { get; set; }
    public string Summary { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public string Submitter { get; set; }
    public string Assigned { get; set; }
    public string Watchers { get; set; }

    public Tickets(string summary, string status, string priority, string submitter, string assigned, string watchers) {
    
        int i = 1;
        StreamReader sr = new StreamReader("Tickets.csv");
        while (!sr.EndOfStream) {
            i += 1;
        } sr.Close();

        ID = i;
        Summary = summary;
        Status = status;
        Priority = priority;
        Submitter = submitter;
        Assigned = assigned;
        Watchers = watchers;
    }

}
