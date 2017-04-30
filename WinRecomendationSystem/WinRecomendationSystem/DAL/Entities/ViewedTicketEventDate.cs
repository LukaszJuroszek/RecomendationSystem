using System;

namespace WinRecomendationSystem.Entities
{
    public class ViewedTicketEventDate
    {
        public int Id { get; set; }
        public DateTime WhenCliked { get; set; }
        public virtual TicketEvent TicketEvent { get; set; }
    }
}
