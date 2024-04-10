using EWL.EF_SQLite;
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
    public partial class ApiKeyForm : Form
    {
        SettingsForm Owner { get; set; }
        public ApiKeyForm(SettingsForm owner)
        {
            Owner = owner;

            KeyDown += Escape_KeyDown!;
            KeyDown += Enter_KeyDown;
            InitializeComponent();
            ApiKeyFormElipse.TargetControl = this;
            ApiKeyTextBox.Focus();
        }


        private void SettingForm_Shown(object sender, EventArgs e)
        {
            ApiKeyPanel.Visible = true;
            FadeInTimer.Start();
        }

        private void SettingForm_Load(object sender, EventArgs e)
            => this.Location = Owner.Location + (Owner.Size / 2) - (this.Size / 2);


        #region Fade in/out

        double FadeInOutDelta { get; } = 0.1;

        private void FadeInTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += FadeInOutDelta;
            else
                FadeInTimer.Stop();
        }

        private void FadeOutTimer_AndClose_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
                this.Opacity -= 2 * FadeInOutDelta;
            else
            //{
            //    FadeOutTimer.Stop();
                Close();
            //}
        }

        #endregion


        #region [ ApiKeyPanel ]

        private void SettingForm_Activated(object sender, EventArgs e)
            => ApiKeyPanel.BorderColor = Color.FromArgb(170, 101, 254);

        private void SettingForm_Deactivate(object sender, EventArgs e)
            => ApiKeyPanel.BorderColor = Color.FromArgb(74, 84, 93);

        #endregion

        private void ApiKeyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ApiKeyTextBox.Text != "")
                SaveApiKeyButton.Enabled = true;
        }

        private void SaveApiKeyButton_Click(object sender, EventArgs e)
        {
            SQLService.Set_GPTApiKey(ApiKeyTextBox.Text);
            ApiKeyAddingReportPopup.Popup();
            FadeOutTimer.Start();
            //Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            FadeOutTimer.Start();
            //Close();
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SaveApiKeyButton.PerformClick();
        }

        private void Escape_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                CancelButton.PerformClick();
        }
    }
}
