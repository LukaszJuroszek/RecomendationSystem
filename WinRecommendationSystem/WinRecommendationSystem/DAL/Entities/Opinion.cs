using WinRecomendationSystem.Entities;
using WinRecomendationSystem.Enums;

namespace WinRecomendationSystem.Model
{
    public class Opinion
    {
        public int Id { get; set; }
        public EventOpinion EventOpinion { get; set; }
        public virtual User User { get; set; }
        public virtual TicketEvent TicketEvents { get; set; }
    }
}
