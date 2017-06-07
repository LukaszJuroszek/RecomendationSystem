using RecomendationModel.Entities;
using RecomendationModel.Model;

namespace RecomendationModel.DAL
{
    public interface IUnitOfWork
    {
        IRepository<ClikedEvent> ClikedEventRepository { get; }
        IRepository<Opinion> OpinionRepository { get; }
        IRepository<TicketEvent> TicketEventRepository { get; }
        IRepository<User> UserRepository { get; }
        void Commit();
        void Dispose();
    }
}