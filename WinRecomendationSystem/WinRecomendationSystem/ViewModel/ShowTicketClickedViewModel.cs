using System;
using WinRecomendationSystem.Entities;

namespace WinRecomendationSystem.ViewModel
{
    public class ShowClickedTicketViewModel
    {
        public TicketEvent TicketEvent { get; set; }
        public User User { get; set; }
        public DateTime WhenClicked{ get; set; }
    }
}
