namespace Events
{
    using System;
    using Models;
    using Utils;

    public class Startup
    {
        private const char Separator = '|';

        private const string ListEventsCommand = "ListEvents";

        private const string AddEventCommand = "AddEvent";

        private const string DeleteEventsCommand = "DeleteEvents";

        private static EventHolder events = new EventHolder();

        public static void Main()
        {
            while (ExecuteNextCommand())
            {
                Console.WriteLine(Messages.Log);
            }
        }

        private static bool ExecuteNextCommand()
        {
            string command = Console.ReadLine();

            switch (command[0])
            {
                case 'A':
                    AddEvent(command);
                    return true;
                case 'D':
                    DeleteEvents(command);
                    return true;
                case 'L':
                    ListEvents(command);
                    return true;
                case 'E':
                    return false;
                default:
                    break;
            }

            return false;
        }

        private static void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf(Separator);
            DateTime date = GetDate(command, ListEventsCommand);

            string countString = command.Substring(pipeIndex + 1);
            int count = int.Parse(countString);

            events.ListEvents(date, count);
        }

        private static void DeleteEvents(string command)
        {
            string title = command.Substring(DeleteEventsCommand.Length + 1);

            events.DeleteEvents(title);
        }

        private static void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;

            GetParameters(command, AddEventCommand, out date, out title, out location);

            events.AddEvent(date, title, location);
        }

        private static void GetParameters(
            string commandForExecution,
            string commandType,
            out DateTime dateAndTime,
            out string eventTitle,
            out string eventLocation)
        {
            dateAndTime = GetDate(commandForExecution, commandType);

            int firstPipeIndex = commandForExecution.IndexOf(Separator);
            int lastPipeIndex = commandForExecution.LastIndexOf(Separator);

            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        private static DateTime GetDate(string command, string commandType)
        {
            DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
            return date;
        }
    }
}