using System.Collections.Generic;
using System.Linq;
using WinRecomendationSystem.DAL;
using WinRecomendationSystem.Entities;

namespace WinRecomendationSystem.ViewModel
{
    public class FrmMainViewModel 
    {
        private IUnitOfWork _unitOfWork;
        public IEnumerable<TicketEvent> TicketEvents { get; set; }
        public IEnumerable<User> Users { get; set; }
        public FrmMainViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            TicketEvents = _unitOfWork.TicketEventRepository.GetAll();
            Users = _unitOfWork.UserRepository.GetAll();
        }
    }
}
