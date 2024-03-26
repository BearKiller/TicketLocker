using NLog;

public class TaskFile {
    public string filePath { get; set; }
    public List<Task> Tasks { get; set; }
    private static NLog.Logger logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + $"{Path.DirectorySeparatorChar}nlog.config").GetCurrentClassLogger();
    

    public TaskFile(string taskFilePath) {
        filePath = taskFilePath;
        Tasks = new List<Task>();

        try {
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream) {
                Task task = new Task();
                string line = sr.ReadLine();
                string[] ticketDetails = line.Split(',');
                task.ticketID = UInt64.Parse(ticketDetails[0]);
                task.summary = ticketDetails[1];
                task.status = ticketDetails[2];
                task.priority = ticketDetails[3];
                task.submitter = ticketDetails[4];
                task.assigned = ticketDetails[5];
                task.watching = ticketDetails[6].Split('|').ToList();
                task.projectName = ticketDetails[7];
                task.dueDate = ticketDetails[8];
                Tasks.Add(task);
            }
            sr.Close();
            logger.Info("Tasks in ticket file {Count}", Tasks.Count);
            
        } catch (Exception ex) {
            logger.Error(ex.Message);
        }
    }


    public void AddTaskTicket(Task task) {
        try {
            task.ticketID = Tasks.Max(m => m.ticketID) + 1;
            string summary = task.summary;
            StreamWriter sw = new StreamWriter(filePath, true);
            sw.WriteLine($"{task.ticketID},{task.summary},{task.status},{task.priority},{task.submitter},{task.assigned},{string.Join("|", task.watching)},{task.projectName},{task.dueDate}");
            sw.Close();

        } catch (Exception ex) {
            logger.Error(ex.Message);
        }
    }
}
