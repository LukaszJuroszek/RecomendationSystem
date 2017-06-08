using PropertyChanged;
using RecomendationModel.Entities;

namespace RecomendationModel.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class ShowTicketViewModel
    {
        public TicketEvent TicketEvent { get; set; }
        public User User { get; set; }
    }
}
