
using System.Windows;
using TextCopy;

namespace GenerateGItBranchFromAzureDevOpsTicket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int limit = 2;
            while (true)
            {
                Console.WriteLine("Enter the ticket number.");
                var ticket = Console.ReadLine();

                Console.WriteLine();

                int ticketLength = ticket.Length;


                PrintDash(ticketLength);

               string getTicket = GenrateGitBranch(ticket);
               PrintTicket(getTicket, ticketLength);
                counter++;
                if(counter == limit)
                {
                    Console.Clear();
                    PrintTicket(getTicket, ticketLength);
                    counter = 0;
                }
            }
        }

        private static void PrintTicket(string ticket, int ticketLength)
        {
            Console.WriteLine(ticket);
            PrintDash(ticketLength);
            ClipboardService.SetText(ticket);
            Console.WriteLine();
        }

        private static void PrintDash(int lengthOfTicket)
        {
            for (int i = 0; i < lengthOfTicket; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");
        }

        private static string GenrateGitBranch(string? ticket)
        {
            if (ticket != null)
            {
                if (ticket.Contains(":"))
                {
                    ticket = ticket.Replace(":", " ");
                }
                if (ticket.Contains("["))
                {
                    var findSqBracketIndex = ticket.IndexOf('[');
                    ticket = ticket.Remove(findSqBracketIndex - 1);
                }

                var firstSpaceIndex = ticket.IndexOf(" ");
                ticket = ticket.Insert(firstSpaceIndex, "/ab#");
                ticket = ticket.Replace(' ', '-');

            }
           
            return "git checkout -b \"" + ticket + "\"";
            
        }
    }
}
