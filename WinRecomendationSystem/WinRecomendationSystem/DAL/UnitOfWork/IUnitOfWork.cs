namespace WinRecomendationSystem.DAL
{
    public interface IUnitOfWork
    {
        Repository<ClikedEventRepository> ClikedEventRepository { get; }
        Repository<EventCategoryRepository> EventCategoryRepository { get; }
        Repository<OpinionRepository> OpinionRepository { get; }
        Repository<TicketEventRepository> TicketEventRepository { get; }
        Repository<UserRepository> UserRepository { get; }
        Repository<ViewedTicketEventDateRepository> ViewedTicketEventDateRepository { get; }
        void Commit();
    }
}