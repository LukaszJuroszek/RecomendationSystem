using System.Linq;
using System.Windows.Forms;
using WinRecomendationSystem.RecommendationEngine;
using WinRecomendationSystem.ViewModel;

namespace WinRecomendationSystem
{
    public partial class FrmMain : Form
    {
        private MainViewModel _mainViewModel;
        public FrmMain()
        {
            _mainViewModel = new MainViewModel();
            var rec = new Recommendation(new RecommendationProfile()).ToString();
            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            const string message = "Are you sure that you would like to exit ?";
            const string caption = "Cancel exit";
            var result = MessageBox.Show(message, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
            e.Cancel = (result == DialogResult.No);
        }
        private void FrmMain_Load(object sender, System.EventArgs e)
        {
            ViewEvents(_mainViewModel);
            SetAutoAdjustColumnSize();
        }
        private void SetAutoAdjustColumnSize()
        {
            for (int i = 0; i < listView.Columns.Count; i++)
            {
                listView.Columns[i].Width = -2;
            }
        }
        private void ViewEvents(MainViewModel mainViewModel)
        {
            foreach (var item in mainViewModel.TicketEvents)
            {
                var lv = new ListViewItem() { Text = item.Title.ToString() };
                lv.Tag = item.Id;
                lv.SubItems.Add(item.EventCategory.ToString());
                lv.SubItems.Add(item.Localization.ToString());
                lv.SubItems.Add(item.Date.ToShortDateString());
                listView.Items.Add(lv);
            }
        }
        private void btnShow_Click(object sender, System.EventArgs e)
        {
            var tickedEvent = _mainViewModel.GetTicketEventById(int.Parse(listView.SelectedItems[0].Tag.ToString()));
            var showTicketViewModel = new ShowTicketViewModel()
            {
                TicketEvent = tickedEvent,
                User = _mainViewModel.Users.First() // for one user
            };
            var frmShowTicket = new FrmShowTicket(showTicketViewModel);
            if (frmShowTicket.ShowDialog() == DialogResult.Cancel)
            {
                _mainViewModel.AddClikedEvent(frmShowTicket._showClickedTicketViewModel);
                _mainViewModel.AddOpinion(frmShowTicket._opinionViewModel);
            }
        }
    }
}
