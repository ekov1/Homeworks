namespace Events.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Utils;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        private MultiDictionary<string, Event> titleEvents = new MultiDictionary<string, Event>(true);
        private OrderedBag<Event> dateEvents = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);

            this.titleEvents.Add(title.ToLower(), newEvent);

            this.dateEvents.Add(newEvent);
            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removedEvents = 0;

            foreach (var eventToRemove in this.titleEvents[title])
            {
                removedEvents++;
                this.dateEvents.Remove(eventToRemove);
            }

            this.titleEvents.Remove(title);
            Messages.EventDeleted(removedEvents);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = 
                this.dateEvents.RangeFrom(new Event(date, string.Empty, string.Empty), true);

            int displayedEvents = 0;

            foreach (var eventToShow in eventsToShow)
            {
                if (displayedEvents == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                displayedEvents++;
            }

            if (displayedEvents == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}
