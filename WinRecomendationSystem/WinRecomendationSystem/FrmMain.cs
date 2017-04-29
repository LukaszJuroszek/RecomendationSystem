using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            InitializeComponent();
        }
    }
}
