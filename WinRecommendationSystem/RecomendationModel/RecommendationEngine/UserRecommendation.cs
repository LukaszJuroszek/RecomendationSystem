﻿using System.Linq;
using System.Collections.Generic;
using System.Text;
using RecomendationModel.DAL;
using RecomendationModel.Entities;
using RecomendationModel.Enums;
using System;
using PropertyChanged;

namespace RecomendationModel.RecommendationEngine
{
    [AddINotifyPropertyChangedInterface]
    public class UserRecommendation
    {
        public IList<KeyValuePair<EventCategory,RecommendationState>> EventCategoryRecommendationState { get; private set; }
        public IEnumerable<KeyValuePair<EventCategory,double>> RecommendedCategories { get; private set; }
        private RecommendationProfile _recommendationProfile;
        private static readonly Random _random = new Random();
        private static readonly object _syncLock = new object();

        public UserRecommendation(RecommendationProfile recommendationProfile)
        {
            _recommendationProfile = recommendationProfile;
            EventCategoryRecommendationState = GetEventCategoryRecommendationState().ToList();
            RecommendedCategories = GetRecommendedCategories();
        }
        public IEnumerable<KeyValuePair<EventCategory,RecommendationState>> GetEventCategoryRecommendationState()
        {
            var recCat = new List<KeyValuePair<EventCategory,RecommendationState>>();
            foreach (KeyValuePair<TicketEvent,EventOpinion> item in _recommendationProfile.UserTicketEventOpinions.EventOpinions)
            {
                if (item.Value.Equals(EventOpinion.Like))
                {
                    recCat.Add(new KeyValuePair<EventCategory,RecommendationState>(item.Key.EventCategory,RecommendationState.Recommended));
                }
                else if (item.Value.Equals(EventOpinion.DontLike))
                {
                    recCat.Add(new KeyValuePair<EventCategory,RecommendationState>(item.Key.EventCategory,RecommendationState.NotRecommended));
                }
                else
                {
                    if (_recommendationProfile.GetPercentTicketEventsRatioFromAllTicketEvents(item.Key) > 5.0)
                        recCat.Add(new KeyValuePair<EventCategory,RecommendationState>(item.Key.EventCategory,RecommendationState.Recommended));
                    else
                        recCat.Add(new KeyValuePair<EventCategory,RecommendationState>(item.Key.EventCategory,RecommendationState.NotRecommended));
                }
            }
            return recCat;
        }
        public IEnumerable<KeyValuePair<EventCategory,double>> GetRecommendedCategories()
        {
            var recomCat = new List<KeyValuePair<EventCategory,double>>();
            foreach (EventCategory eventCategory in Enum.GetValues(typeof(EventCategory)))
            {
                recomCat.Add(new KeyValuePair<EventCategory,double>(eventCategory,RecommendedPercentRatio(eventCategory)));
            }
            return recomCat;
        }
        public List<EventCategory> GetEventsCategoriesBasedOnRecommendCategories(int count)
        {
            var result = new List<EventCategory>();
            for (int i = 0;i < count;i++)
            {
                result.Add(GetEventCategoryBasedOnRecommendCategories());
            }
            return result;
        }
        private EventCategory GetEventCategoryBasedOnRecommendCategories()
        {
            var recommendedCategoriesWithoutZeros = RecommendedCategories.Where(x => x.Value > 0).ToList();
            var randomNumberFromRecommendedCategories = GetRandomNumber(0,recommendedCategoriesWithoutZeros.Select(x => x.Value).Sum());
            var currentSum = 0.0;
            for (var i = 0;i < recommendedCategoriesWithoutZeros.Count();i++)
            {
                currentSum += recommendedCategoriesWithoutZeros[i].Value;
                if (currentSum >= randomNumberFromRecommendedCategories)
                    return recommendedCategoriesWithoutZeros[i].Key;
            }
            return EventCategory.None;
        }
        private double GetRandomNumber(double minimum,double maximum)
        {
            lock (_syncLock)
            { // synchronize
                return _random.NextDouble() * ( maximum - minimum ) + minimum;
            }
        }
        private double RecommendedPercentRatio(EventCategory eventCategory)
        {
            if (EventCategoryRecommendationState.GroupBy(x => x.Key).Select(x => x.Key).Contains(eventCategory))
            {
                var recommendedCount = EventCategoryRecommendationState
                    .Where(x => x.Key == eventCategory && x.Value == RecommendationState.Recommended).Count();
                var notRecommendedCunt = EventCategoryRecommendationState
                    .Where(x => x.Key == eventCategory && x.Value == RecommendationState.NotRecommended).Count();
                if (recommendedCount == 0)
                    return 0.0;
                else if (notRecommendedCunt == 0)
                    return 100.0;
                return ( (double)recommendedCount / ( notRecommendedCunt + recommendedCount ) ) * 100;
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
        public static int RandomNumber(int min,int max)
        {
            lock (_syncLock)
            { // synchronize
                return _random.Next(min,max);
            }
        }
        public IEnumerable<TicketEvent> GetRemommendedTicketEvents(IEnumerable<TicketEvent> ticketEvents,int count)
        {
            var listOfTicketEvent = GetEventsCategoriesBasedOnRecommendCategories(count);
            var result = new List<TicketEvent>();

            for (int i = 0;i < listOfTicketEvent.Count;i++)
            {
                var eventCategory = listOfTicketEvent[i];
                var toAdd = GetRandomTicketEventByEventCategory(ticketEvents,eventCategory);
                if (!result.Contains(toAdd))
                    if (ticketEvents.Where(x => x.EventCategory == listOfTicketEvent[i]).Count() >= count)
                        do
                        {
                            toAdd = GetRandomTicketEventByEventCategory(ticketEvents,eventCategory);
                        } while (result.Contains(toAdd));
                if (!result.Contains(toAdd))
                    result.Add(toAdd);
            }
            return result;
        }
        private TicketEvent GetRandomTicketEventByEventCategory(IEnumerable<TicketEvent> ticketEvents,EventCategory ticketEventCategory)
        {
            return ticketEvents.Where(x => x.EventCategory == ticketEventCategory).OrderBy(x => Guid.NewGuid()).First();
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{_recommendationProfile.User.Name} ");
            //sb.AppendLine($"{RecommendationCategoriesToString()} ");
            foreach (var item in RecommendedCategories)
            {
                sb.AppendLine($"{item.Key.ToString()} has {item.Value} % recomended ratio ");
            }
            return sb.ToString();
        }
    }
}
