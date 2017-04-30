using System;
using WinRecomendationSystem.Entities;

namespace WinRecomendationSystem.ViewModel
{
    public class ShowTicketClickedViewModel
    {
        public TicketEvent TicketEvent { get; set; }
        public User User { get; set; }
        public DateTime DateCliked{ get; set; }
    }
}
