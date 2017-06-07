using System;
using RecomendationModel.Entities;

namespace RecomendationModel.ViewModel
{
    public class ShowClickedTicketViewModel
    {
        public TicketEvent TicketEvent { get; set; }
        public DateTime WhenClicked { get; set; }
        public User User { get; set; }
    }
}
