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
        private bool disposed = false;

        private ClikedEventRepository _clikedEventRepository;
        private EventCategoryRepository _eventCategoryRepository;
        private OpinionRepository _opinionRepository;
        private TicketEventRepository _ticketEventRepository;
        private UserRepository _userRepository;
        private ViewedTicketEventDateRepository _viewedTicketEventDateRepository;
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public ClikedEventRepository ClikedEventRepository {
            get
            {
                return _clikedEventRepository ?? new ClikedEventRepository(_dbContext);
            }
        }
        public EventCategoryRepository EventCategoryRepository {
            get
            {
                return _eventCategoryRepository ?? new EventCategoryRepository(_dbContext);
            }
        }
        public OpinionRepository OpinionRepository {
            get
            {
                return _opinionRepository ?? new OpinionRepository(_dbContext);
            }
        }
        public TicketEventRepository TicketEventRepository {
            get
            {
                return _ticketEventRepository ?? new TicketEventRepository(_dbContext);
            }
        }
        public UserRepository UserRepository {
            get
            {
                return _userRepository ?? new UserRepository(_dbContext);
            }
        }
        public ViewedTicketEventDateRepository ViewedTicketEventDateRepository {
            get
            {
                return _viewedTicketEventDateRepository ?? new ViewedTicketEventDateRepository(_dbContext);
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
