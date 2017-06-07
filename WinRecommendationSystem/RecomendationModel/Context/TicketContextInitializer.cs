using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RecomendationModel.Entities;
using RecomendationModel.Enums;

namespace RecomendationModel.Model.Context
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
            for (int i = 0; i < 40; i++)
            {
                AddRandomTicketEvents(context);
            }
        }

        private void AddRandomTicketEvents(TicketContext context)
        {
            var rnd = GetRandom7TicketEvents();
            for (int s = 0; s < rnd.Count(); s++)
            {
                context.TicketEvents.Add(rnd[s]);
            }
        }

        private List<TicketEvent> GetRandom7TicketEvents()
        {
            var list = new List<TicketEvent>();
            for (int i = 0; i < 7; i++)
            {
                list.Add(GetRandomTicketEvent(i));
            }
            return list;
        }
        private TicketEvent GetRandomTicketEvent(int cat)
        {
            var rnd = new Random();
            return new TicketEvent
            {
                Date = DateTime.Now.Add(TimeSpan.FromDays(-rnd.Next(0, 100))),
                EventCategory = (EventCategory)Enum.GetValues(typeof(EventCategory)).GetValue(cat),
                Localization = "Zimbawwe",
                Title = Guid.NewGuid().ToString("n").Substring(0, 8)
            };
        }
    }
}
