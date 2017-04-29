using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinRecomendationSystem.Model
{
    public class ViewedTicketEventDate
    {
        public int Id { get; set; }
        public DateTime WhenCliked { get; set; }
        public virtual TicketEvent TicketEvent { get; set; }
    }
}
