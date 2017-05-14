using System.Linq;
using System.Collections.Generic;
using System.Text;
using WinRecomendationSystem.DAL;
using WinRecomendationSystem.Entities;
using WinRecomendationSystem.Enums;
using System;

namespace WinRecomendationSystem.RecommendationEngine
{
    public class UserRecommendation
    {
        public IList<KeyValuePair<EventCategory, RecommendationState>> EventCategoryRecommendationState { get; private set; }
        public IList<KeyValuePair<EventCategory, double>> RecommendedCategories { get; private set; }
        private UnitOfWork unitOfwork;
        private RecommendationProfile recommendationProfile;
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
        public UserRecommendation(RecommendationProfile rp)
        {
            unitOfwork = new UnitOfWork();
            recommendationProfile = rp;
            EventCategoryRecommendationState = GetEventCategoryRecommendationState().ToList();
            RecommendedCategories = GetRecommendedCategories();
        }
        public IEnumerable<KeyValuePair<EventCategory, RecommendationState>> GetEventCategoryRecommendationState()
        {
            var recCat = new List<KeyValuePair<EventCategory, RecommendationState>>();
            foreach (KeyValuePair<TicketEvent, EventOpinion> item in recommendationProfile.Opinions.EventOpinions)
            {
                if (item.Value.Equals(EventOpinion.Like))
                {
                    recCat.Add(new KeyValuePair<EventCategory, RecommendationState>(item.Key.EventCategory, RecommendationState.Recommended));
                }
                else if (item.Value.Equals(EventOpinion.DontLike))
                {
                    recCat.Add(new KeyValuePair<EventCategory, RecommendationState>(item.Key.EventCategory, RecommendationState.NotRecommended));
                }
                else
                {
                    if (recommendationProfile.GetPercentTicketEventsRatioFromAllTicketEvents(item.Key) > 5.0)
                        recCat.Add(new KeyValuePair<EventCategory, RecommendationState>(item.Key.EventCategory, RecommendationState.Recommended));
                    else
                        recCat.Add(new KeyValuePair<EventCategory, RecommendationState>(item.Key.EventCategory, RecommendationState.NotRecommended));
                }
            }
            return recCat;
        }
        public IList<KeyValuePair<EventCategory, double>> GetRecommendedCategories()
        {
            var recomCat = new List<KeyValuePair<EventCategory, double>>();
            foreach (EventCategory eventCategory in Enum.GetValues(typeof(EventCategory)))
            {
                recomCat.Add(new KeyValuePair<EventCategory, double>(eventCategory, RecommendedPercentRatio(eventCategory)));
            }
            return recomCat;
        }
        public IList<EventCategory> GetEventsCategoriesBasedOnRecommendCategories(int count)
        {
            var result = new List<EventCategory>();
            for (int i = 0; i < count; i++)
            {
                result.Add(GetEventCategoryBasedOnRecommendCategories());
            }
            return result;
        }
        private EventCategory GetEventCategoryBasedOnRecommendCategories()
        {
            var recommendedCategoriesWithoutZeros = RecommendedCategories.Where(x => x.Value > 0).ToList();
            var randomNumberFromRecommendedCategories = GetRandomNumber(0, recommendedCategoriesWithoutZeros.Select(x => x.Value).Sum());
            var currentSum = 0.0;
            for (var i = 0; i < recommendedCategoriesWithoutZeros.Count(); i++)
            {
                currentSum += recommendedCategoriesWithoutZeros[i].Value;
                if (currentSum >= randomNumberFromRecommendedCategories)
                    return recommendedCategoriesWithoutZeros[i].Key;
            }
            return EventCategory.None;
        }
        private double GetRandomNumber(double minimum, double maximum)
        {
            lock (syncLock)
            { // synchronize
                return random.NextDouble() * (maximum - minimum) + minimum;
            }
        }
        private double RecommendedPercentRatio(EventCategory ec)
        {
            if (EventCategoryRecommendationState.GroupBy(x => x.Key).Select(x => x.Key).Contains(ec))
            {
                var recommendedCount = EventCategoryRecommendationState
                    .Where(x => x.Key == ec && x.Value == RecommendationState.Recommended).Count();
                var notRecommendedCunt = EventCategoryRecommendationState
                    .Where(x => x.Key == ec && x.Value == RecommendationState.NotRecommended).Count();
                if (recommendedCount == 0)
                    return 0.0;
                else if (notRecommendedCunt == 0)
                    return 100.0;
                return ((double)recommendedCount / (notRecommendedCunt + recommendedCount)) * 100;
            }
            return 0.0;
        }
        private string RecommendationCategoriesToString()
        {
            var sb = new StringBuilder();
            foreach (var item in EventCategoryRecommendationState)
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
            for (int i = 0; i < RecommendedCategories.Count(); i++)
            {
                sb.AppendLine($"{RecommendedCategories[i].Key.ToString()} has {RecommendedCategories[i].Value} % recomended ratio ");
            }
            return sb.ToString();
        }
    }
}
