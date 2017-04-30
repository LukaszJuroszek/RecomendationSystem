using System;
namespace WinRecomendationSystem.Entities
{
    public class TicketEvent
    {
        public int Id { get; set; }
        public virtual EventCategory EventCategory { get; set; }
        public DateTime Date{ get; set; }
        public string Lokalizacja { get; set; }
    }
}
