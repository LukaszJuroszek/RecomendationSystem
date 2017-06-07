using RecomendationModel.Entities;
using RecomendationModel.Enums;

namespace RecomendationModel.ViewModel
{
    public class OpinionViewModel
    {
        public int Id { get; set; }
        public EventOpinion EventOpinion { get; set; }
        public User User { get; set; }
        public TicketEvent TicketEvents { get; set; }
    }
}
