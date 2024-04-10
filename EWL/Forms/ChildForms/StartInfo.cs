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
    public partial class StartInfo : Form
    {
        IOverlaySplashScreenHandle handler;
        MainForm owner;
        List<Image> images = new List<Image>();

        public StartInfo(MainForm owner, IOverlaySplashScreenHandle handler)
        {
            this.owner = owner;
            this.handler = handler;
            FullImagesList();

            KeyDown += Escape_KeyDown!;
            InitializeComponent();
        }

        void FullImagesList()
        {
            images.Add(Properties.Resources.start_1_0);
            //images.Add(Properties.Resources.IMG_57361_2_);
        }

        private void StartInfoForm_Shown(object sender, EventArgs e)
            => FadeInTimer.Start();

        private void SettingForm_Load(object sender, EventArgs e)
            => this.Location = owner.Location + (owner.Size / 2) - (this.Size / 2);


        #region Fade in/out

        double FadeInOutDelta { get; } = 0.1;

        private void FadeInTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += FadeInOutDelta;
            else
                FadeInTimer.Stop();
        }

        #endregion

        private void CloseButton_Click(object sender, EventArgs e)
        {
            handler.Close();
            Close();
        }

        private void Escape_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                CloseSettingsButton.PerformClick();
        }
    }
}
