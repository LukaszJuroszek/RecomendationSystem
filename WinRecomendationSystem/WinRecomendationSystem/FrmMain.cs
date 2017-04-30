using System.Linq;
using System.Windows.Forms;
using WinRecomendationSystem.DAL;
using WinRecomendationSystem.ViewModel;

namespace WinRecomendationSystem
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            var repo = new UnitOfWork();
            /
            var p = repo.UserRepository.GetAll();
            this.listView = new ListView();
            var s = new FrmMainViewModel(repo);
            var ss= s.TicketEvents.ToArray();
            var sss= s.Users.ToArray();
            InitializeComponent();
        }
    }
}
