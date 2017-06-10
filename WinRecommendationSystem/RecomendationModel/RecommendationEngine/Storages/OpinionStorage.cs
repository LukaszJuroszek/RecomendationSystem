using System.Collections.Generic;
using System.Text;
using RecomendationModel.Entities;
using RecomendationModel.Enums;

namespace RecomendationModel.RecommendationEngine
{
    public class OpinionsStorage
    {
        public Dictionary<TicketEvent, EventOpinion> EventOpinions { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (KeyValuePair<TicketEvent, EventOpinion> item in EventOpinions)
            {
                sb.AppendLine($"Ticket Title:{item.Key.Title}, Category: {item.Key.EventCategory}, Opinion: {item.Value}");
            }
            return sb.ToString();
        }
    }
}
