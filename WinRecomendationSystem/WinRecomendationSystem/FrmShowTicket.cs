using System.Windows.Forms;
using WinRecomendationSystem.ViewModel;

namespace WinRecomendationSystem
{
    public partial class FrmShowTicket : Form
    {
        private ShowTicketViewModel _showTicketViewModel;
        public FrmShowTicket(ShowTicketViewModel showTicketViewModel)
        {
            _showTicketViewModel = showTicketViewModel;
            InitializeComponent();
        }
    }
}
