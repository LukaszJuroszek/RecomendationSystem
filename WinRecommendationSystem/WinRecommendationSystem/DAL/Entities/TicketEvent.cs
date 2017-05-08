using System;
using WinRecomendationSystem.Enums;

namespace WinRecomendationSystem.Entities
{
    public class TicketEvent 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public EventCategory EventCategory { get; set; }
        public DateTime Date { get; set; }
        public string Localization { get; set; }
    }
}
