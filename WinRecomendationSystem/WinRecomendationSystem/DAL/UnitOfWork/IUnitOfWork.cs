using WinRecomendationSystem.Entities;
using WinRecomendationSystem.Model;

namespace WinRecomendationSystem.DAL
{
    public interface IUnitOfWork
    {
        IRepository<ClikedEvent> ClikedEventRepository { get; }
        IRepository<Opinion> OpinionRepository { get; }
        IRepository<TicketEvent> TicketEventRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<ViewedTicketEventDate> ViewedTicketEventDateRepository { get; }
        void Commit();
        void Dispose();
    }
}