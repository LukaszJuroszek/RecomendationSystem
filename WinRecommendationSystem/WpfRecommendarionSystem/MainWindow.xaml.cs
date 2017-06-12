using RecomendationModel.Entities;
using RecomendationModel.Enums;
using RecomendationModel.RecommendationEngine;
using RecomendationModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfRecommendarionSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel;
        private bool _allOrRecomended=true;

        public MainWindow()
        {
            _mainViewModel = new MainViewModel();
            DataContext = _mainViewModel;
            InitializeComponent();
        }
        private async void ShowTicketButton_Click(object sender,RoutedEventArgs e)
        {
            if (ticekEventsListView.SelectedItems.Count > 0)
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
        }
        private async void ShowRecommendedTicketEvent_Click(object sender,RoutedEventArgs e)
        {
            if (_allOrRecomended)
            {
                _mainViewModel.TicketEvents = await GetUserRecommendedTicketEventsAsync();
                _allOrRecomended = false;
            }
            else
            {
                _mainViewModel.TicketEvents = await GetUserAllTicketEventsAsync();
                _allOrRecomended = true;
            }
        }
        private Task<List<KeyValuePair<EventCategory,double>>> GetNewUserRecomendationAsync()
        {
            var task = new Task<List<KeyValuePair<EventCategory,double>>>(_mainViewModel.GetUserRecommendation);
            task.Start();
            return task;
        }
        private Task<IEnumerable<TicketEvent>> GetUserRecommendedTicketEventsAsync()
        {
            var task = new Task<IEnumerable<TicketEvent>>(_mainViewModel.GetRemommendedTicketEvents);
            task.Start();
            return task;
        }
        private Task<IEnumerable<TicketEvent>> GetUserAllTicketEventsAsync()
        {
            var task = new Task<IEnumerable<TicketEvent>>(_mainViewModel.GetAllTicketEvents);
            task.Start();
            return task;
        }
    }
}
