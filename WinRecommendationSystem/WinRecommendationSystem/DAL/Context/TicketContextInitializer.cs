using System;
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
            context.TicketEvents.Add(new TicketEvent
            {
                Date = DateTime.Now.Add(TimeSpan.FromDays(123)),
                EventCategory = Enums.EventCategory.Muzka,
                Localization= "Warsaw",
                Title="Koncert Maryli"
            });
            context.TicketEvents.Add(new TicketEvent
            {
                Date = DateTime.Now.Add(TimeSpan.FromDays(23)),
                EventCategory = Enums.EventCategory.Rodzina,
                Localization = "InoWrc",
                Title = "Rodzina 500+"
            });
            context.TicketEvents.Add(new TicketEvent
            {
                Date = DateTime.Now.Add(TimeSpan.FromDays(23)),
                EventCategory = Enums.EventCategory.Biznes,
                Localization = "Warsaw",
                Title = ".netEvent"
            });

        }
    }
}
