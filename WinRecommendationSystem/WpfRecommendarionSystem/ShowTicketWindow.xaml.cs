using RecomendationModel.Enums;
using RecomendationModel.ViewModel;
using System;
using System.Windows;

namespace WpfRecommendarionSystem
{
    /// <summary>
    /// Interaction logic for ShowTicketWindow.xaml
    /// </summary>
    public partial class ShowTicketWindow : Window
    {
        public ShowClickedTicketViewModel _showClickedTicketViewModel;
        public OpinionViewModel _opinionViewModel;
        public ShowTicketWindow(ShowTicketViewModel showTicketViewModel)
        {
            InitializeComponent();
            DataContext = showTicketViewModel;
            _showClickedTicketViewModel = new ShowClickedTicketViewModel
            {
                WhenClicked = DateTime.Now,
                TicketEvent = showTicketViewModel.TicketEvent,
                User = showTicketViewModel.User
            };
            _opinionViewModel = new OpinionViewModel
            {
                TicketEvents = showTicketViewModel.TicketEvent,
                User = showTicketViewModel.User,
                EventOpinion = EventOpinion.Normal
            };
        }

        private void okButton_Click(object sender,RoutedEventArgs e)
        {
            Close();
        }
        private void btnLike_Click(object sender,EventArgs e)
        {
            _opinionViewModel.EventOpinion = EventOpinion.Like;
            Close();
        }

        private void btnDontLike_Click(object sender,EventArgs e)
        {
            _opinionViewModel.EventOpinion = EventOpinion.DontLike;
            Close();
        }

        private void bntNormal_Click(object sender,EventArgs e)
        {
            _opinionViewModel.EventOpinion = EventOpinion.Normal;
            Close();
        }
    }
}
