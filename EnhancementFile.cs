using NLog;

public class EnhancementFile {
    public string filePath { get; set; }
    public List<Enhancement> Enhancements { get; set; }
    private static NLog.Logger logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + $"{Path.DirectorySeparatorChar}nlog.config").GetCurrentClassLogger();
    

    public EnhancementFile(string enhancementFilePath) {
        filePath = enhancementFilePath;
        Enhancements = new List<Enhancement>();

        try {
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream) {
                Enhancement enhancement = new Enhancement();
                string line = sr.ReadLine();
                string[] ticketDetails = line.Split(',');
                enhancement.ticketID = UInt64.Parse(ticketDetails[0]);
                enhancement.summary = ticketDetails[1];
                enhancement.status = ticketDetails[2];
                enhancement.priority = ticketDetails[3];
                enhancement.submitter = ticketDetails[4];
                enhancement.assigned = ticketDetails[5];
                enhancement.watching = ticketDetails[6].Split('|').ToList();
                enhancement.software = ticketDetails[7];
                enhancement.cost = ticketDetails[8];
                enhancement.reason = ticketDetails[9];
                enhancement.estimate = ticketDetails[10];
                Enhancements.Add(enhancement);
            }
            sr.Close();
            logger.Info("Enhancements in ticket file {Count}", Enhancements.Count);
            
        } catch (Exception ex) {
            logger.Error(ex.Message);
        }
    }


    public void AddEnhancementTicket(Enhancement enhancement) {
        try {
            enhancement.ticketID = Enhancements.Max(m => m.ticketID) + 1;
            string summary = enhancement.summary;
            StreamWriter sw = new StreamWriter(filePath, true);
            sw.WriteLine($"{enhancement.ticketID},{enhancement.summary},{enhancement.status},{enhancement.priority},{enhancement.submitter},{enhancement.assigned},{string.Join("|", enhancement.watching)},{enhancement.software},{enhancement.cost},{enhancement.reason},{enhancement.estimate}");
            sw.Close();

        } catch (Exception ex) {
            logger.Error(ex.Message);
        }
    }
}