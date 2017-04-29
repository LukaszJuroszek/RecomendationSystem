using System.Windows.Forms;
using WinRecomendationSystem.DAL;

namespace WinRecomendationSystem
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            var repo = new UnitOfWork();
            var p = repo.UserRepository.GetAll();
            this.listView = new ListView();
            listView.Columns.Ad
            InitializeComponent();
        }
    }
}
