using System;
using System.Windows.Forms;
using WinRecomendationSystem.ViewModel;

namespace WinRecomendationSystem
{
    public partial class FrmShowTicket : Form
    {
        public ShowTicketClickedViewModel _showTicketClickedViewModel;
        public FrmShowTicket(ShowTicketViewModel showTicketViewModel)
        {
            InitializeComponent();
            _showTicketClickedViewModel = new ShowTicketClickedViewModel
            {
                DateCliked = DateTime.Now,
                TicketEvent = showTicketViewModel.TicketEvent,
                User = showTicketViewModel.User
            };
            SetTextBoxTextAndBlockEdit(textBoxDate, showTicketViewModel.TicketEvent.Date.ToShortDateString());
            SetTextBoxTextAndBlockEdit(textBoxLocalization, showTicketViewModel.TicketEvent.Localization);
            SetTextBoxTextAndBlockEdit(textBoxTitle, showTicketViewModel.TicketEvent.Title);
        }
        private void SetTextBoxTextAndBlockEdit(TextBox textBox, string text)
        {
            textBox.Text = text;
            textBox.ReadOnly = true;
            textBox.BorderStyle = 0;
            textBox.BackColor = BackColor;
            textBox.TabStop = false;
        }
    }
}
