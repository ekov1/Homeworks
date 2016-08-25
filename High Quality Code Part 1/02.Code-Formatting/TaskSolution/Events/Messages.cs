namespace Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Messages
    {
        private static StringBuilder output = new StringBuilder();

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
                output.AppendFormat("{0} events deleted\n", x);
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
