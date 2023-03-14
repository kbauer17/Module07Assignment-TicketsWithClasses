using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "//nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();

// designate the file to read/write to
string ticketFilePath = Directory.GetCurrentDirectory() + "//tickets.csv";

logger.Info("Program started");

TicketFile ticketFile = new TicketFile(ticketFilePath);

string choice = "";
string chosenSubClass = "";
do
{
  // display choices to user
  Console.WriteLine("1) Add Ticket");
  Console.WriteLine("2) Display All Tickets");
  Console.WriteLine("Enter to quit");

  // input selection
  choice = Console.ReadLine();
  logger.Info("User choice: {Choice}", choice);
  
  if (choice == "1")
  {
    // Add ticket
    HelpTicket ticket = new HelpTicket();

    // Ask which type of ticket to add
    Console.WriteLine("1) Add Help Ticket");
    Console.WriteLine("2) Add Enhancement");
    Console.WriteLine("3) Add Task");

    // input selection
    chosenSubClass = Console.ReadLine();
    logger.Info("User choice: {Choice}", choice);

    // Obtain input for the common fields
    
    // prompt for a ticket id number
    Console.WriteLine("Enter a Ticket Number: ");
    // save the Ticket id number
    ticket.ticketId = UInt64.Parse(Console.ReadLine());
    // prompt for ticket Summary
    Console.WriteLine("Enter a Summary for the ticket:  ");
    // save the ticket Summary
    ticket.summary = Console.ReadLine();
    // prompt for ticket status
    Console.WriteLine("Enter the ticket status (open/closed).");
    // save the ticket status
    ticket.status = Console.ReadLine();
    // prompt for priority
    Console.WriteLine("Enter the ticket priority (high/low).");
    // save the ticket priority
    ticket.priority = Console.ReadLine();
    // prompt for the name of the ticket submitter
    Console.WriteLine("Enter the name of the person submitting the ticket.");
    // save the name of the submitter
    ticket.submitter = Console.ReadLine();
    // prompt for the name of the person to whom the ticket is assigned
    Console.WriteLine("Enter the name of the person to whom the ticket is assigned.");
    // save the name of the assignee
    ticket.assigned = Console.ReadLine();
    // prompt for the name of the ticket watcher
    Console.WriteLine("Enter the name of the person watching the ticket.");
    // save the name of the watcher
    ticket.watcher = Console.ReadLine();

    // populate the fields specific to each subclass
    switch(chosenSubClass){
      case "1": // Help Ticket
          // prompt for a ticket severity
          Console.WriteLine("Enter the Severity (1 - 10): ");
          // save the Ticket id number
          ticket.severity = UInt64.Parse(Console.ReadLine());
          // add ticket
          ticketFile.AddTicket(ticket);
        break;
      case "2": // Enhancement
        break;
      case "3": // Task
        break;
    }

        

    

  } else if (choice == "2")
  {
    // Display All Tickets
    foreach(HelpTicket t in ticketFile.Tickets)
    {
      Console.WriteLine(t.Display());
    }
  }

} while (choice == "1" || choice == "2");


logger.Info("Program ended");
