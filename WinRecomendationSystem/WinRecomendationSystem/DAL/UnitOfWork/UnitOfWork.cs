using System;
using WinRecomendationSystem.Entities;
using WinRecomendationSystem.Model;

namespace WinRecomendationSystem.DAL
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        //used http://panictheorem.net/Blog/Repository-And-Unit-Of-Work
        private TicketContext _dbContext = new TicketContext();
        private bool disposed = false;
        private Repository<ClikedEvent> _clikedEventRepository;
        private Repository<Opinion> _opinionRepository;
        private Repository<TicketEvent> _ticketEventRepository;
        private Repository<User> _userRepository;
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public IRepository<ClikedEvent> ClikedEventRepository {
            get { return _clikedEventRepository ?? new Repository<ClikedEvent>(_dbContext); }
        }
        public IRepository<Opinion> OpinionRepository {
            get { return _opinionRepository ?? new Repository<Opinion>(_dbContext); }
        }
        public IRepository<TicketEvent> TicketEventRepository {
            get { return _ticketEventRepository ?? new Repository<TicketEvent>(_dbContext); }
        }
        public IRepository<User> UserRepository {
            get { return _userRepository ?? new Repository<User>(_dbContext); }
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
