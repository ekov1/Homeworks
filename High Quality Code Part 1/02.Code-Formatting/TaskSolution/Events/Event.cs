namespace Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Event : IComparable
    {
        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            Event otherEvent = obj as Event;

            int dateCompare = this.date.CompareTo(otherEvent.date);
            int titleCompare = this.title.CompareTo(otherEvent.title);
            int locationCompare = this.location.CompareTo(otherEvent.location);

            if (dateCompare == 0)
            {
                if (titleCompare == 0)
                {
                    return locationCompare;
                }
                else
                {
                    return titleCompare;
                }
            }
            else
            {
                return dateCompare;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            builder.Append(" | " + this.title);

            if (this.location != null && this.location != "")
            {
                builder.Append(" | " + this.location);
            }

            return builder.ToString();
        }
    }
}
