namespace Events.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Event : IComparable
    {
        private const string DateFormat = "yyyy-MM-ddTHH:mm:ss";
        private const string Separator = " | ";

        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public int CompareTo(object obj)
        {
            Event otherEvent = obj as Event;

            if (obj == null)
            {
                throw new ArgumentException();
            }

            int dateCompare = this.Date.CompareTo(otherEvent.Date);
            int titleCompare = this.Title.CompareTo(otherEvent.Title);
            int locationCompare = this.Location.CompareTo(otherEvent.Location);

            if (dateCompare != 0)
            {
                return dateCompare;
            }

            if (titleCompare != 0)
            {
                return titleCompare;
            }

            return locationCompare;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(this.Date.ToString(DateFormat));
            builder.Append(Separator + this.Title);

            if (this.Location != null && this.Location != string.Empty)
            {
                builder.Append(Separator + this.Location);
            }

            return builder.ToString();
        }
    }
}
