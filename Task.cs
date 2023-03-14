public class Task : Ticket
{
  public string ProjectName { get; set; }
  public string DueDate { get; set; }
  

  // method to display tickets
  public override string Display()
    {
      return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatcher: {watcher}\nProject Name: {ProjectName}\nDue Date: {DueDate}\n"; 
    }
}