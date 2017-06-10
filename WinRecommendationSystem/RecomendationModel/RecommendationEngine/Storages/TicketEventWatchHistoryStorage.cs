using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecomendationModel.DAL;
using RecomendationModel.Entities;

namespace RecomendationModel.RecommendationEngine
{
    public class TicketEventWatchHistoryStorage
    {
        public TicketEvent TicketEvent { get; set; }
        public Dictionary<DateTime,int> WatchTicketEventCountsPerDay { get; set; }
        public int SumOfAllClickedTicketEvents { get; set; }
        private IUnitOfWork _unitOfWork;
        public TicketEventWatchHistoryStorage(User user,TicketEvent ticketEvent)
        {
            _unitOfWork = new UnitOfWork();
            TicketEvent = ticketEvent;
            WatchTicketEventCountsPerDay = GetTicketEventCountPerDay(user,DateTime.Now.Add(TimeSpan.FromDays(-7)));
            SumOfAllClickedTicketEvents = WatchTicketEventCountsPerDay.Values.Sum();

        }
        private Dictionary<DateTime,int> GetTicketEventCountPerDay(User user,DateTime fromDate)
        {
            return GetUserClickedEvent(user).ViewedTicketEventDates
                .Where(day => day.WhenClicked > fromDate)
                .GroupBy(x => x.WhenClicked.Date)
                .ToDictionary(days => days.Key,clicked => clicked.Count());
        }
        private ClikedEvent GetUserClickedEvent(User user)
        {
            return _unitOfWork.ClikedEventRepository.Filter(ev => ev.TicketEvent.Id == TicketEvent.Id && ev.User.Id == user.Id).First();
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Ticket Title:{TicketEvent.Title}, Category: {TicketEvent.EventCategory}");
            sb.AppendLine($"Watchee Times:{SumOfAllClickedTicketEvents}");
            foreach (KeyValuePair<DateTime,int> item in WatchTicketEventCountsPerDay)
            {
                sb.AppendLine($"Watched in {item.Key.ToShortDateString()} {item.Value} Times");
            }
            return sb.ToString();
        }
    }
}
