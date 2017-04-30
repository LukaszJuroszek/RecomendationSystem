using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WinRecomendationSystem.DAL;
using WinRecomendationSystem.DAL.Entities;
using WinRecomendationSystem.Entities;
using WinRecomendationSystem.Model;

namespace WinRecomendationSystem.ViewModel
{
    public class MainViewModel
    {
        private IUnitOfWork _unitOfWork;
        public IEnumerable<TicketEvent> TicketEvents { get; set; }
        public IEnumerable<User> Users { get; set; }
        public MainViewModel()
        {
            _unitOfWork = new UnitOfWork();
            TicketEvents = _unitOfWork.TicketEventRepository.All();
            Users = _unitOfWork.UserRepository.All();
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
            Expression<Func<TicketEvent, bool>> FilterTicketEventById()
            {
                return x => x.Id == id;
            }
            return _unitOfWork.TicketEventRepository.Filter(FilterTicketEventById()).First();
        }
    }
}
