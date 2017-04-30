using System.Collections.Generic;
namespace WinRecomendationSystem.Entities
{
    public class ClikedEvent
    {
        public int Id { get; set; }
        public virtual TicketEvent TicketEvent { get; set; }
        public virtual User User { get; set; }
        public ICollection<ViewedTicketEventDate> ViewedTicketEventDate { get; set; }
        public ClikedEvent()
        {
            ViewedTicketEventDate = new HashSet<ViewedTicketEventDate>();
        }
    }
}
