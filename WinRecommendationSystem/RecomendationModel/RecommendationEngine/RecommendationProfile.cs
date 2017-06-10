using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecomendationModel.DAL;
using RecomendationModel.Entities;
using RecomendationModel.Enums;
using PropertyChanged;

namespace RecomendationModel.RecommendationEngine
{
    [AddINotifyPropertyChangedInterface]
    public class RecommendationProfile
    {
        public User User { get; private set; }
        public OpinionsStorage UserTicketEventOpinions { get; private set; }
        public List<TicketEventWatchHistoryStorage> TicketEventWatchHistories{ get; private set; }
        public int AllTicketEventViewTimes { get; set; }
        private IUnitOfWork _unitOfWork;
        public RecommendationProfile(User user)
        {
            _unitOfWork = new UnitOfWork();
            User = user;
            UserTicketEventOpinions = GetUserOpinions(User);
            TicketEventWatchHistories = GetUserWatchedEvents(User);
            AllTicketEventViewTimes= TicketEventWatchHistories.Sum(x => x.SumOfAllClickedTicketEvents);
        }
        private OpinionsStorage GetUserOpinions(User user)
        {
            var opinionOfTicketEvent = new Dictionary<TicketEvent,EventOpinion>();
            var userOpinions = _unitOfWork.OpinionRepository
                .Filter(x => x.User.Id == user.Id)
                .ToList();
            foreach (var opinion in userOpinions)
            {
                opinionOfTicketEvent.Add(opinion.TicketEvents,opinion.EventOpinion);
            }
            return new OpinionsStorage
            {
                EventOpinions = opinionOfTicketEvent
            };
        }
        private List<TicketEventWatchHistoryStorage> GetUserWatchedEvents(User user)
        {
            var watchedEvents = new List<TicketEventWatchHistoryStorage>();
            var userEventis = _unitOfWork.ClikedEventRepository
                .Filter(x => x.User.Id == user.Id)
                .GroupBy(x => x.TicketEvent)
                .Select(x => x.Key)
                .ToList();
            foreach (var ticketEvent in userEventis)
            {
                watchedEvents.Add(new TicketEventWatchHistoryStorage(user,ticketEvent));
            }
            return watchedEvents;
        }
        public double GetPercentTicketEventsRatioFromAllTicketEvents(TicketEvent ticketEvent)
        {
            if (TicketEventWatchHistories.FindIndex(item => item.TicketEvent.Id == ticketEvent.Id) != 0)
            {
                var teViewsCount = TicketEventWatchHistories
                    .Where(x => x.TicketEvent.Id == ticketEvent.Id)
                    .First().SumOfAllClickedTicketEvents;
                return ( (double)teViewsCount / AllTicketEventViewTimes ) * 100;
            }
            return 0.0;
        }
        public string AnalysisToString()
        {
            var sb = new StringBuilder();
            sb.Append(UserTicketEventOpinions.ToString());
            foreach (var item in TicketEventWatchHistories)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
    }
}
