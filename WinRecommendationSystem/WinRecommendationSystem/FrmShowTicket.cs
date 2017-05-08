using System;
using System.Windows.Forms;
using WinRecomendationSystem.Enums;
using WinRecomendationSystem.ViewModel;

namespace WinRecomendationSystem
{
    public partial class FrmShowTicket : Form
    {
        public ShowClickedTicketViewModel _showClickedTicketViewModel;
        public OpinionViewModel _opinionViewModel;
        public FrmShowTicket(ShowTicketViewModel showTicketViewModel)
        {
            InitializeComponent();
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

        private void btnLike_Click(object sender, EventArgs e)
        {
            _opinionViewModel.EventOpinion = EventOpinion.Like;
        }

        private void btnDontLike_Click(object sender, EventArgs e)
        {
            _opinionViewModel.EventOpinion = EventOpinion.DontLike;
        }

        private void bntNormal_Click(object sender, EventArgs e)
        {
            _opinionViewModel.EventOpinion = EventOpinion.Normal;
        }
    }
}
