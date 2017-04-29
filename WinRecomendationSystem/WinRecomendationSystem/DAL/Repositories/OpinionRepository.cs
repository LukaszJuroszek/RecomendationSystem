using System;
using System.Collections.Generic;
using System.Linq;
using WinRecomendationSystem.Model;

namespace WinRecomendationSystem.DAL
{
    public class OpinionRepository : Repository<Opinion>
    {
        public OpinionRepository(TicketContext context) : base(context)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
        }
        public override void Add(Opinion element)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Opinion element)
        {
            throw new NotImplementedException();
        }

        public override void Edit(Opinion element)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Opinion> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Opinion GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
