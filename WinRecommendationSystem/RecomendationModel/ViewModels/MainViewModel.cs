using System.Collections.Generic;
using System.Linq;
using RecomendationModel.DAL;
using RecomendationModel.DAL.Entities;
using RecomendationModel.Entities;
using RecomendationModel.Model;
using RecomendationModel.RecommendationEngine;
using PropertyChanged;
using RecomendationModel.Enums;

namespace RecomendationModel.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        private IUnitOfWork _unitOfWork;
        public IEnumerable<TicketEvent> TicketEvents { get; set; }
        public IEnumerable<KeyValuePair<EventCategory,double>> UserRecomendation { get { return GetRecomendation(); } }
        public TicketEvent SelectedTicketEvent { get; set; }
        public User User { get; set; }
        private UserRecommendation _userRecommendation;
        public MainViewModel()
        {
            _unitOfWork = new UnitOfWork();
            TicketEvents = _unitOfWork.TicketEventRepository.All().ToList();
            User = _unitOfWork.UserRepository.All().First();
            _userRecommendation = new UserRecommendation(new RecommendationProfile(User));
        }
        public void AddOpinion(OpinionViewModel model)
        {
            var exsOpinion = _unitOfWork.OpinionRepository.Filter(x => x.TicketEvents.Id == model.TicketEvents.Id).ToList();
            if (exsOpinion.Count() != 0)//if opinion exist
                exsOpinion.First().EventOpinion = model.EventOpinion;
            else
                _unitOfWork.OpinionRepository.Add(new Opinion
                {
                    EventOpinion = model.EventOpinion,
                    TicketEvents = model.TicketEvents,
                    User = model.User
                });
            _unitOfWork.Commit();
        }
        public void AddClikedEvent(ShowClickedTicketViewModel model)
        {
            var exsClickedEvent = _unitOfWork.ClikedEventRepository.Filter(x => x.TicketEvent.Id == model.TicketEvent.Id);
            if (exsClickedEvent.Count() != 0)
                exsClickedEvent.First().ViewedTicketEventDates.Add(new ClikedEventDate { WhenClicked = model.WhenClicked });
            else
                _unitOfWork.ClikedEventRepository.Add(new ClikedEvent
                {
                    TicketEvent = model.TicketEvent,
                    User = model.User,
                    ViewedTicketEventDates = new List<ClikedEventDate>() { new ClikedEventDate { WhenClicked = model.WhenClicked } }
                });
            _unitOfWork.Commit();
        }
        public TicketEvent GetTicketEventById(int id)
        {
            return _unitOfWork.TicketEventRepository.Filter(x => x.Id == id).First();
        }
        public string GetRecomendationString() => new UserRecommendation(new RecommendationProfile(User)).ToString();    // refresh user recomendation todo

        public IEnumerable<KeyValuePair<EventCategory,double>> GetRecomendation() => new UserRecommendation(new RecommendationProfile(User)).RecommendedCategories; // refresh user recomendation todo
        public IEnumerable<TicketEvent> GetRemommendedTicketEvents(int count)
        {
            return _userRecommendation.GetRemommendedTicketEvents(TicketEvents,count);
        }
    }
}

