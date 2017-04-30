using System.Linq;
using System.Windows.Forms;
using WinRecomendationSystem.ViewModel;

namespace WinRecomendationSystem
{
    public partial class FrmMain : Form
    {
        private MainViewModel _mainViewModel;
        public FrmMain()
        {
            _mainViewModel = new MainViewModel();
           
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
            var lv = new ListViewItem();
            foreach (var item in _mainViewModel.TicketEvents)
            {
            lv.Text = item.Localization;
            lv.SubItems.Add(item.EventCategory.ToString());
            lv.SubItems.Add(item.Date.ToShortDateString());
                listView.Items.Add(lv);
            }

        }
    }
}
