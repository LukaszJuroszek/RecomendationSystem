using System;
using System.Collections.Generic;
using WinRecomendationSystem.Model;

namespace WinRecomendationSystem.DAL
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(TicketContext context) : base(context)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
        }
        public void Add(User element)
        {
            throw new NotImplementedException();
        }


        public void Delete(User element)
        {
            throw new NotImplementedException();
        }

        public void Edit(User element)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
