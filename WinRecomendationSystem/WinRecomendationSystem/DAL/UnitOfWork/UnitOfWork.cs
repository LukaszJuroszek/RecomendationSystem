using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinRecomendationSystem.Model;

namespace WinRecomendationSystem.DAL
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        //used http://panictheorem.net/Blog/Repository-And-Unit-Of-Work
        private TicketContext _dbContext = new TicketContext();

        private Repository<ClikedEventRepository> _clikedEventRepository;
        private Repository<EventCategoryRepository> _eventCategoryRepository;
        private Repository<OpinionRepository> _opinionRepository;
        private Repository<TicketEventRepository> _ticketEventRepository;
        private Repository<UserRepository> _userRepository;
        private Repository<ViewedTicketEventDateRepository> _viewedTicketEventDateRepository;
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        //IDisposible implementation
        private bool disposed = false;

        public Repository<ClikedEventRepository> ClikedEventRepository {
            get
            {
                return _clikedEventRepository ?? new Repository<ClikedEventRepository>(_dbContext);
            }
        }
        public Repository<EventCategoryRepository> EventCategoryRepository {
            get
            {
                return _eventCategoryRepository ?? new Repository<EventCategoryRepository>(_dbContext);
            }
        }
        public Repository<OpinionRepository> OpinionRepository {
            get
            {
                return _opinionRepository ?? new Repository<OpinionRepository>(_dbContext);
            }
        }
        public Repository<TicketEventRepository> TicketEventRepository {
            get
            {
                return _ticketEventRepository ?? new Repository<TicketEventRepository>(_dbContext);
            }
        }
        public Repository<UserRepository> UserRepository {
            get
            {
                return _userRepository ?? new Repository<UserRepository>(_dbContext);
            }
        }
        public Repository<ViewedTicketEventDateRepository> ViewedTicketEventDateRepository {
            get
            {
                return _viewedTicketEventDateRepository ?? new Repository<ViewedTicketEventDateRepository>(_dbContext);
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    _dbContext.Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
