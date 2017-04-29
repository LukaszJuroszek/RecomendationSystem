using System.Collections.Generic;

namespace WinRecomendationSystem.Model
{
    public class ClikedEvent
    {
        public int Id { get; set; }
        public virtual TicketEvent TicketEvent { get; set; }
        public ICollection<  ViewedTicketEventDate >ViewedTicketEventDate { get; set; }
        public ClikedEvent()
        {
            ViewedTicketEventDate = new HashSet<ViewedTicketEventDate>();
        }
    }
}
