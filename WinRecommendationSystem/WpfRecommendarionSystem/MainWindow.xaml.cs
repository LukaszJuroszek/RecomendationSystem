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
            InitializeComponent();
        }

        private void ticekEventsListView_SelectionChanged(object sender,SelectionChangedEventArgs e)
        {
            var stv = new ShowTicketWindow(new ShowTicketViewModel
            {
                TicketEvent = _mainViewModel.SelectedTicketEvent,
                User = _mainViewModel.User
            });
            stv.Visibility = Visibility.Visible;


        }
    }
}
