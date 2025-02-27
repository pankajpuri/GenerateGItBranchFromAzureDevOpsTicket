
using System.Windows;
using TextCopy;

namespace GenerateGItBranchFromAzureDevOpsTicket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter the ticket number.");
                var ticket = Console.ReadLine();

                Console.WriteLine();

                int ticketLength = ticket.Length;


                PrintDash(ticketLength);

                GenrateGitBranch(ticket, ticketLength);
            }
        }

        private static void PrintDash(int lengthOfTicket)
        {
            for (int i = 0; i < lengthOfTicket; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");
        }

        private static void GenrateGitBranch(string? ticket, int ticketLength)
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
            else
            {
                return;
            }
            var printTicket = "git checkout -b \"" + ticket + "\"";
            Console.WriteLine(printTicket);
            PrintDash(ticketLength);
            ClipboardService.SetText(printTicket);
            Console.WriteLine();
        }
    }
}
