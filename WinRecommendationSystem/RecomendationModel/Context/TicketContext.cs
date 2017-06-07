using System.Data.Entity;
using RecomendationModel.Entities;
using RecomendationModel.Model.Context;

namespace RecomendationModel.Model
{
    public class TicketContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ClikedEvent> ClikedEvents { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<TicketEvent> TicketEvents { get; set; }
        public TicketContext()
        {
            Database.SetInitializer(new TicketContextInitializer());
        }
    }
}
