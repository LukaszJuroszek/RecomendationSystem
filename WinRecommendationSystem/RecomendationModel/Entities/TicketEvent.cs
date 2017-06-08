using System;
using RecomendationModel.Enums;
using PropertyChanged;

namespace RecomendationModel.Entities
{
    [AddINotifyPropertyChangedInterface]
    public class TicketEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public EventCategory EventCategory { get; set; }
        public DateTime Date { get; set; }
        public string Localization { get; set; }
    }
}
