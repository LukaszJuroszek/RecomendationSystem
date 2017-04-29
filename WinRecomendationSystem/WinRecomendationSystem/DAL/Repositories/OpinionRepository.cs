using System;
using System.Collections.Generic;
using System.Linq;
using WinRecomendationSystem.Model;

namespace WinRecomendationSystem.DAL
{
    public class OpinionRepository : IRepository<Opinion>
    {
        public OpinionRepository()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
        }
        public void Add(Opinion element)
        {
            throw new NotImplementedException();
        }

        public void Delete(Opinion element)
        {
            throw new NotImplementedException();
        }

        public void Edit(Opinion element)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Opinion> GetAll()
        {
            throw new NotImplementedException();
        }

        public Opinion GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
