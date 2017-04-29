using System;
using System.Collections.Generic;
using System.Linq;
using WinRecomendationSystem.Model;

namespace WinRecomendationSystem.DAL
{
    public class ClikedEventRepository : IRepository<ClikedEvent>
    {
        public ClikedEventRepository()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
        }
        public void Add(ClikedEvent element)
        {
            throw new NotImplementedException();
        }

        public void Delete(ClikedEvent element)
        {
            throw new NotImplementedException();
        }

        public void Edit(ClikedEvent element)
        {
            throw new NotImplementedException();
        }

        public IEquatable<ClikedEvent> GetAll()
        {
            throw new NotImplementedException();
        }

        public ClikedEvent GetByID(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ClikedEvent> IRepository<ClikedEvent>.GetAll()
        {
            throw new NotImplementedException();
        }
   
    }
}
