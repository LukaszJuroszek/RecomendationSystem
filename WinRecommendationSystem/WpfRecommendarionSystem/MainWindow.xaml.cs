using RecomendationModel.Entities;
using RecomendationModel.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace WpfRecommendarionSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel;

        public MainWindow()
        {
            _mainViewModel = new MainViewModel();
            DataContext = _mainViewModel;
            InitializeComponent();
        }

        private void ShowTicketButton_Click(object sender,RoutedEventArgs e)
        {
           var showTicketViewModel=  new ShowTicketViewModel
            {
                TicketEvent = _mainViewModel.SelectedTicketEvent,
                User = _mainViewModel.User
            };
            var stv = new ShowTicketWindow(showTicketViewModel);
            stv.Visibility = Visibility.Visible;
            if (stv.ShowDialog() != true)
            {
                _mainViewModel.AddClikedEvent(stv._showClickedTicketViewModel);
                _mainViewModel.AddOpinion(stv._opinionViewModel);
            }
        }
        private void ShowRecomendation_Click(object sender,RoutedEventArgs e)
        {
            textBlockRecomendation_info.Text = _mainViewModel.GetRecomendationString();
        }
        private void ticekEventsListView_SelectionChanged(object sender,SelectionChangedEventArgs e)
        {
            _mainViewModel.SelectedTicketEvent = ticekEventsListView.SelectedValue as TicketEvent;
            //var stv = new ShowTicketWindow(new ShowTicketViewModel
            // {
            //     TicketEvent = _mainViewModel.SelectedTicketEvent,
            //     User = _mainViewModel.User
            // });
            // stv.Visibility = Visibility.Visible;
        }
    }
}
