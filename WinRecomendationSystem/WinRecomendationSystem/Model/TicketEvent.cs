using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinRecomendationSystem.Model
{
    public class TicketEvent
    {
        public int Id { get; set; }
        public virtual EventCategory EventCategory { get; set; }
        public DateTime Date{ get; set; }
        public string Lokalizacja { get; set; }
    }
}
