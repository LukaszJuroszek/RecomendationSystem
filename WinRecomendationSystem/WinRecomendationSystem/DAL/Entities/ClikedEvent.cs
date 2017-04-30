using System;
using System.Collections.Generic;
namespace WinRecomendationSystem.Entities
{
    public class ClikedEvent 
    {
        public int Id { get; set; }
        public virtual TicketEvent TicketEvent { get; set; }
        public virtual User User { get; set; }
        public ICollection<DateTime> ViewedTicketEventDates { get; set; }
    }
}
