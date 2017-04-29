using System;
using System.Collections.Generic;
using System.Linq;
using WinRecomendationSystem.Model;

namespace WinRecomendationSystem.DAL
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(TicketContext context) : base(context) { }
        public override void Add(User element)
        {
            throw new NotImplementedException();
        }
        public override void Delete(User element)
        {
            throw new NotImplementedException();
        }

        public override void Edit(User element)
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<User> GetAll()
        {
               return _context.Users.Select(x=>x);
        }
        public override User GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
