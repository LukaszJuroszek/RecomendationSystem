using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinRecomendationSystem.DAL;
using WinRecomendationSystem.Entities;
using WinRecomendationSystem.Enums;

namespace WinRecomendationSystem.RecomendationEngine
{
    public class RecomendationProfile
    {
        public User User { get; set; }
        public OpinionsStorage Opinions { get; private set; }
        public List<WatchedEventStorage> WatchedEvents { get; private set; }
        private UnitOfWork unitOfWork;
        public RecomendationProfile()
        {
            unitOfWork = new UnitOfWork();
            User = unitOfWork.UserRepository.All().First();
            SetOpinions();
            SetWatchedEvents();
            var op = Analysis();
            var p = 2;
        }
        public void SetOpinions()
        {
            var op = new Dictionary<TicketEvent, EventOpinion>();
            var temp = unitOfWork.OpinionRepository.All().Where(x => x.User.Id == User.Id).ToList();
            foreach (var opinion in temp)
            {
                op.Add(opinion.TicketEvents, opinion.EventOpinion);
            }
            Opinions = new OpinionsStorage
            {
                User = User,
                EventOpinions = op
            };
        }
        public void SetWatchedEvents()
        {
            WatchedEvents = new List<WatchedEventStorage>();
            var userEventis = unitOfWork.ClikedEventRepository.Filter(x => x.User.Id == User.Id).GroupBy(x => x.TicketEvent).Select(x=>x.Key).ToList();
            foreach (var ticketEvent in userEventis)
            {
                WatchedEvents.Add(new WatchedEventStorage(User, ticketEvent, unitOfWork));
            }
        }
        public string Analysis()
        {
            var sb = new StringBuilder();
            sb.Append(Opinions.ToString());
            foreach (var item in WatchedEvents)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
    }
}
