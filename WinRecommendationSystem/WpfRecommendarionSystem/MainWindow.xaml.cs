using RecomendationModel.Entities;
using RecomendationModel.Enums;
using RecomendationModel.RecommendationEngine;
using RecomendationModel.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private async void ShowTicketButton_Click(object sender,RoutedEventArgs e)
        {
            var showTicketViewModel = new ShowTicketViewModel
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
            _mainViewModel.UserRecommendation = await GetNewUserRecomendationAsync();
        }
        private Task<List<KeyValuePair<EventCategory,double>>> GetNewUserRecomendationAsync()
        {
            var task = new Task<List<KeyValuePair<EventCategory,double>>>(_mainViewModel.GetUserRecommendation);
            task.Start();
            return task;
        }
    }
}
