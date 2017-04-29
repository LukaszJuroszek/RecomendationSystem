namespace WinRecomendationSystem.DAL
{
    public interface IUnitOfWork
    {
        ClikedEventRepository ClikedEventRepository { get; }
        EventCategoryRepository EventCategoryRepository { get; }
        OpinionRepository OpinionRepository { get; }
        TicketEventRepository TicketEventRepository { get; }
        UserRepository UserRepository { get; }
        ViewedTicketEventDateRepository ViewedTicketEventDateRepository { get; }
        void Commit();
    }
}