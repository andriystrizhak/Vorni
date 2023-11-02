using DevExpress.XtraSplashScreen;
using EWL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eng_Flash_Cards_Learner.Forms.ChildForms
{
    public partial class SettingsForm : Form
    {
        IOverlaySplashScreenHandle handler;
        MainForm owner;
        public SettingsForm(MainForm owner, IOverlaySplashScreenHandle handler)
        {
            MdiParent = owner;
            this.owner = owner;
            this.handler = handler;
            InitializeComponent();
        }

        private void CloseSettingsButton_Click(object sender, EventArgs e)
        {
            //owner
            owner.Enabled = true;
            handler.Close();
            this.Close();
        }
    }
}
