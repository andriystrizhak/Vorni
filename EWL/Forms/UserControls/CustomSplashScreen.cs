using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Eng_Flash_Cards_Learner.Forms.UserControls
{
    public partial class CustomSplashScreen : SplashScreen
    {
        public CustomSplashScreen()
        {
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        private void peImage_EditValueChanged(object sender, EventArgs e)
        {

        }

        public enum SplashScreenCommand
        {
        }
    }
}