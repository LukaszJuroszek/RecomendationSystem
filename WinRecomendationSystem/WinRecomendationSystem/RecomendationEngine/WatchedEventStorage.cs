using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinRecomendationSystem.DAL;
using WinRecomendationSystem.Entities;

namespace WinRecomendationSystem.RecomendationEngine
{
    public class WatchedEventStorage
    {
        public User User { get; set; }
        public TicketEvent TicketEvent { get; set; }
        public Dictionary<DateTime, int> WatchedTicketEventCountsPerDay { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"User Name: {User.Name} ");
            sb.AppendLine($"Ticket Title:{TicketEvent.Title}, Category: {TicketEvent.EventCategory}");
            sb.AppendLine($"Watched Times:{WatchedTicketEventCountsPerDay.Values.Aggregate(0,(x,y)=>x+y)}");
            foreach (KeyValuePair<DateTime, int> item in WatchedTicketEventCountsPerDay)
            {
                sb.AppendLine($"Watched in {item.Key.ToShortDateString()} {item.Value} Times");
            }
            return sb.ToString();
        }
        public WatchedEventStorage(User user, TicketEvent ticketEvent, IUnitOfWork uow)
        {
            User = user;
            TicketEvent = ticketEvent;
            WatchedTicketEventCountsPerDay = GetWatchedTicketEventCountsPerDayLastWeek(uow);
        }
        private Dictionary<DateTime, int> GetWatchedTicketEventCountsPerDayLastWeek(IUnitOfWork uow)
        {
            var clickedEvent = uow.ClikedEventRepository.Filter(ev => ev.TicketEvent.Id == TicketEvent.Id && ev.User.Id == User.Id).First();
            return clickedEvent.ViewedTicketEventDates.Where(day => day.WhenClicked > DateTime.Now.Add(TimeSpan.FromDays(-7))).GroupBy(x => x.WhenClicked.Date).
                  ToDictionary(days => days.Key, clickedCount => clickedCount.Count());
        }

    }
}
