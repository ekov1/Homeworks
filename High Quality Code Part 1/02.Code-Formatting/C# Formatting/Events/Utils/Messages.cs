namespace Events.Utils
{
    using System;
    using System.Text;
    using Models;

    public static class Messages
    {
        private static StringBuilder output;

        static Messages()
        {
            output = new StringBuilder();
        }

        public static string Log
        {
            get
            {
                return output.ToString();
            }
        }

        public static void EventAdded()
        {
            output.AppendLine("Event added");
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendLine(string.Format("{0} events deleted", x));
            }
        }

        public static void NoEventsFound()
        {
            output.AppendLine("No events found");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.AppendLine(eventToPrint + Environment.NewLine);
            }
        }
    }
}