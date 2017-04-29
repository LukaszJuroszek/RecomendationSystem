using System;
using System.Collections.Generic;
using System.Linq;
using WinRecomendationSystem.Model;

namespace WinRecomendationSystem.DAL
{
   public class TicketEventRepository : Repository<TicketEvent>
    {
        public TicketEventRepository(TicketContext context) : base(context) { }
        public void Add(TicketEvent element)
        {
            throw new NotImplementedException();
        }
        public void Delete(TicketEvent element)
        {
            throw new NotImplementedException();
        }
        public void Edit(TicketEvent element)
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<TicketEvent> GetAll()
        {
            using (_context)
            {
                return _context.TicketEvents.Select(x => x);
            }
        }
        public TicketEvent GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
