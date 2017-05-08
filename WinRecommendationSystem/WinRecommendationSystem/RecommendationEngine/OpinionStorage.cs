using System.Collections.Generic;
using System.Text;
using WinRecomendationSystem.Entities;
using WinRecomendationSystem.Enums;

namespace WinRecomendationSystem.RecommendationEngine
{
    public class OpinionsStorage
    {
        public User User { get; set; }
        public Dictionary<TicketEvent, EventOpinion> EventOpinions { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"User Name: {User.Name} ");
            foreach (KeyValuePair<TicketEvent, EventOpinion> item in EventOpinions)
            {
                sb.AppendLine($"Ticket Title:{item.Key.Title}, Category: {item.Key.EventCategory}, Opinion: {item.Value}");
            }
            return sb.ToString();
        }
    }
}
