using System;
using System.Collections.Generic;
using System.Linq;
using WinRecomendationSystem.Model;

namespace WinRecomendationSystem.DAL
{
    public class ClikedEventRepository : Repository<ClikedEvent>
    {
        public ClikedEventRepository(TicketContext context) : base(context){}
        public override void Add(ClikedEvent element)
        {
            throw new NotImplementedException();
        }
        public override void Delete(ClikedEvent element)
        {
            throw new NotImplementedException();
        }
        public override void Edit(ClikedEvent element)
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<ClikedEvent> GetAll()
        {
            throw new NotImplementedException();
        }
        public override ClikedEvent GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
