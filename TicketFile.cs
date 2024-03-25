using NLog;

public class TicketFile {
    public string filePath { get; set; }
    public List<Bug> Bugs { get; set; }
    private static NLog.Logger logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + $"{Path.DirectorySeparatorChar}nlog.config").GetCurrentClassLogger();
    

    public TicketFile(string ticketFilePath) {
        filePath = ticketFilePath;
        Bugs = new List<Bug>();

        try {
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream) {
                Bug bug = new Bug();
                string line = sr.ReadLine();
                string[] ticketDetails = line.Split(',');
                bug.ticketID = UInt64.Parse(ticketDetails[0]);
                bug.summary = ticketDetails[1];
                bug.status = ticketDetails[2];
                bug.priority = ticketDetails[3];
                bug.submitter = ticketDetails[4];
                bug.assigned = ticketDetails[5];
                bug.watching = ticketDetails[6].Split('|').ToList();
                bug.severity = ticketDetails[7];
                Bugs.Add(bug);
            }
            sr.Close();
            logger.Info("Bugs in ticket file {Count}", Bugs.Count);
            
        } catch (Exception ex) {
            logger.Error(ex.Message);
        }
    }


    public void AddBugTicket(Bug bug) {
        try {
            bug.ticketID = Bugs.Max(m => m.ticketID) + 1;
            string summary = bug.summary;
            StreamWriter sw = new StreamWriter(filePath, true);
            sw.WriteLine($"{bug.ticketID},{bug.summary},{bug.status},{bug.priority},{bug.submitter},{bug.assigned},{string.Join("|", bug.watching)},{bug.severity}");
            sw.Close();

        } catch (Exception ex) {
            logger.Error(ex.Message);
        }
    }
}