using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WinRecomendationSystem.DAL;
using WinRecomendationSystem.Entities;

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
        public void AddClikedEvent(ShowTicketClickedViewModel model)
        {
            Expression<Func<ClikedEvent, bool>> FilterByShowTicketClikedCiewModel()
            {
                return x => x.Id == model.TicketEvent.Id;
            }
            var exsClickedEvent = _unitOfWork.ClikedEventRepository.Filter(FilterByShowTicketClikedCiewModel());
            if (exsClickedEvent.Count() != 0)
                exsClickedEvent.First().ViewedTicketEventDates.Add(model.DateCliked);
            else
                _unitOfWork.ClikedEventRepository.Add(new ClikedEvent
                {
                    TicketEvent = model.TicketEvent,
                    User = model.User,
                    ViewedTicketEventDates = new List<DateTime>() { model.DateCliked }
                });
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
