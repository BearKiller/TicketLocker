public abstract class Ticket {
    public UInt64 ticketID { get; set; }
    public string summary { get; set; }
    public string status { get; set; }
    public string priority { get; set; }
    public string submitter { get; set; }
    public string assigned { get; set; }
    public List<string> watching { get; set; }

    public Ticket(){
        watching = new List<string>();
    }

    public virtual string Display() {
        return $"\nTicket ID: {ticketID} \n Summary: {summary} \n Status: {status} \n Priority: {priority} \n Submitter: {submitter} \n Watching: {watching} \n";
    }
}



public class Bug : Ticket {
    public string severity { get; set; }
    public override string Display()
    {
        return $"\nTicket ID: {ticketID} \n Summary: {summary} \n Status: {status} \n Priority: {priority} \n Submitter: {submitter} \n Watching: {watching} \n Severity: {severity} \n";
    }
}



public class Enhancement : Ticket {
    public string software { get; set; }
    public string cost { get; set; }
    public string reason { get; set; }
    public string estimate { get; set; }
    public override string Display()
    {
        return $"\nTicket ID: {ticketID} \n Summary: {summary} \n Status: {status} \n Priority: {priority} \n Submitter: {submitter} \n Watching: {watching} \n Software: {software} \n Reason: {reason} \n Cost: {cost} - Estimate: {estimate} \n";
    }
}

public class Task : Ticket {
    public string projectName { get; set; }
    public string dueDate { get; set; }
    public virtual string Display() {
        return $"\nTicket ID: {ticketID} \n Summary: {summary} \n Status: {status} \n Priority: {priority} \n Submitter: {submitter} \n Watching: {watching} \n Projec tName: {projectName} \n Due Date: {dueDate} \n";
    }
}