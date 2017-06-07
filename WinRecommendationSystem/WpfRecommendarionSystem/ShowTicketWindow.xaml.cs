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
        public ShowTicketViewModel ShowTicketViewModel { get; set; }
        public ShowTicketWindow(ShowTicketViewModel showTicketViewModel)
        {
            if (showTicketViewModel.TicketEvent == null)
            {
                throw new Exception("null");
            }
            ShowTicketViewModel = showTicketViewModel;
            InitializeComponent();
            showTextBox.Text = ShowTicketViewModel.TicketEvent.Title;
        }

        private void okButton_Click(object sender,RoutedEventArgs e)
        {
            Close();
        }
    }
}
