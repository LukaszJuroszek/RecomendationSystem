using System.Linq;
using System.Collections.Generic;
using System.Text;
using WinRecomendationSystem.DAL;
using WinRecomendationSystem.Entities;
using WinRecomendationSystem.Enums;

namespace WinRecomendationSystem.RecommendationEngine
{
    public class Recommendation
    {
        public List<KeyValuePair<EventCategory, RecommendationState>> RecommendationCategories { get; set; }
        private UnitOfWork unitOfwork;
        private RecommendationProfile recommendationProfile;
        public Recommendation(RecommendationProfile rp)
        {
            unitOfwork = new UnitOfWork();
            recommendationProfile = rp;
            RecommendationCategories = new List<KeyValuePair<EventCategory, RecommendationState>>();
            SetRecommendationCategories();
        }
        public void SetRecommendationCategories()
        {
            foreach (KeyValuePair<TicketEvent, EventOpinion> item in recommendationProfile.Opinions.EventOpinions)
            {

                if (item.Value.Equals(EventOpinion.Like))
                {
                    RecommendationCategories.Add(new KeyValuePair<EventCategory, RecommendationState>(item.Key.EventCategory, RecommendationState.Recommended));
                }
                else if (item.Value.Equals(EventOpinion.DontLike))
                {
                    RecommendationCategories.Add(new KeyValuePair<EventCategory, RecommendationState>(item.Key.EventCategory, RecommendationState.NotRecommended));
                }
                else
                {
                    if (recommendationProfile.GetPercentTicketEventsParticipationFromAllTicketEvents(item.Key) > 5.0)
                        RecommendationCategories.Add(new KeyValuePair<EventCategory, RecommendationState>(item.Key.EventCategory, RecommendationState.Recommended));
                    else
                        RecommendationCategories.Add(new KeyValuePair<EventCategory, RecommendationState>(item.Key.EventCategory, RecommendationState.NotRecommended));
                }
            }
        }

        public IEnumerable<TicketEvent> Recommend()
        {
            var recommendation = new List<TicketEvent>();
            return recommendation;
        }
        public double RecommendedToNotRecommendedParticipation(EventCategory ec)
        {
            var recommendedCount = RecommendationCategories
                .Where(x => x.Key == ec && x.Value == RecommendationState.Recommended).Count();
            var notRecommendedCunt = RecommendationCategories
                .Where(x => x.Key == ec && x.Value == RecommendationState.NotRecommended).Count();
            if (recommendedCount == 0)
                return 0.0;
            else if (notRecommendedCunt == 0)
                return 100.0;
            return ((double)recommendedCount / notRecommendedCunt) *100;
        }
        public string RecommendationCategoriesToString()
        {
            var sb = new StringBuilder();
            foreach (var item in RecommendationCategories)
            {
                sb.AppendLine($"{item.Key.ToString()} is {item.Value.ToString()}");
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{recommendationProfile.User.Name} ");
            sb.AppendLine($"{RecommendationCategoriesToString()} ");
            foreach (var item in RecommendationCategories.GroupBy(x => x.Key).Select(x => x.Key))
            {
                sb.AppendLine($"{item.ToString()} has {RecommendedToNotRecommendedParticipation(item)} % recomended ratio ");
            }
            return sb.ToString();
        }
    }
}
