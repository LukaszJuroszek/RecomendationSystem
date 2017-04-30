using System.Data.Entity;
using WinRecomendationSystem.Entities;

namespace WinRecomendationSystem.Model.Context
{
    internal class TicketContextInitializer : CreateDatabaseIfNotExists<TicketContext>
    {
        protected override void Seed(TicketContext context)
        {
            context.Users.Add(new User
            {
                Name = "Test",
                ComputerName = "TestComputerName"
            });
            context.EventCategories.Add(new EventCategory { Name = "Muzka" });
            context.EventCategories.Add(new EventCategory { Name = "Teatr" });
            context.EventCategories.Add(new EventCategory { Name = "Sport" });
            context.EventCategories.Add(new EventCategory { Name = "Rodzina" });
            context.EventCategories.Add(new EventCategory { Name = "Klasyka" });
            context.EventCategories.Add(new EventCategory { Name = "Widowiskowa" });
            context.EventCategories.Add(new EventCategory { Name = "Biznes" });
        }
    }
}
