using System.Data.Entity;
using WinRecomendationSystem.Entities;
using WinRecomendationSystem.Model.Context;

namespace WinRecomendationSystem.Model
{
    public class TicketContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ClikedEvent> ClikedEvents { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<TicketEvent> TicketEvents { get; set; }
        public DbSet<ViewedTicketEventDate> ViewedTicketEventDates { get; set; }
        public TicketContext()
        {
            Database.SetInitializer(new TicketContextInitializer());
        }
    }
}
