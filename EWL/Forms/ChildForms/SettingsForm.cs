using DevExpress.XtraSplashScreen;
using EWL;
using EWL.EF_SQLite;
using Microsoft.VisualBasic.Devices;
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
            this.owner = owner;
            this.handler = handler;

            KeyDown += Escape_KeyDown!;

            InitializeComponent();

            NumberOfWordsNumericUpDown.Value = SQLs.Get_NumberOfWordsToLearn();
            WSourceComboBox.SelectedIndex = SQLs.Get_WordAddingMode();
            SetDefaultSButtonAvailability();
            NumberOfWordsNumericUpDown.Focus();
            NumberOfWordsNumericUpDown.UpDownButtonForeColor = Color.White;
            SettingFormElipse.TargetControl = this;
        }

        /// <summary>
        /// Метод що робить основну панель видимою одразу після завантаження й показу форми 
        /// (прибирає візуальні баги появи панелі)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingForm_Shown(object sender, EventArgs e)
        {
            SettingPanel.Visible = true;
            SaveSettingsButton.Enabled = false;
        }

        //TODO - Додати перемикач категорії для вивчення
        int DefaultNumberOfWordsToLearn = 10;
        int DefaultAddingWModeIndex = 0;

        private void WordCountNumericUpDown_ValueChanged(object sender, EventArgs e)
            => SetDefaultAndSaveSButtonAvailability();
        private void WSourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
            => SetDefaultAndSaveSButtonAvailability();

        void SetDefaultAndSaveSButtonAvailability()
        {
            SetDefaultSButtonAvailability();
            SaveSettingsButton.Enabled = true;
        }

        void SetDefaultSButtonAvailability()
            => DefaultSettingsButton.Enabled = !(NumberOfWordsNumericUpDown.Value == DefaultNumberOfWordsToLearn
                && WSourceComboBox.SelectedIndex == DefaultAddingWModeIndex);


        #region Buttons click events

        private void CloseSettingsButton_Click(object sender, EventArgs e)
        {
            handler.Close();
            Close();
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            SaveSettingsButton.Enabled = false;
            DefaultSettingsButton.Enabled = true;

            SQLs.Set_NumberOfWordsToLearn((int)NumberOfWordsNumericUpDown.Value);
            SQLs.Set_WordAddingMode(WSourceComboBox.SelectedIndex);

            CloseSettingsButton.PerformClick();
        }

        private void DefaultSettingsButton_Click(object sender, EventArgs e)
        {
            DefaultSettingsButton.Enabled = false;
            SQLs.Set_NumberOfWordsToLearn(10);
            SQLs.Set_WordAddingMode(0);

            NumberOfWordsNumericUpDown.Value = DefaultNumberOfWordsToLearn;
            WSourceComboBox.SelectedIndex = DefaultAddingWModeIndex;
        }

        #endregion

        #region Buttons focus events

        private void DefaultSettingsButton_Enter(object sender, EventArgs e)
        {
            DefaultSettingsButton.BorderColor = Color.FromArgb(170, 101, 254);
        }

        private void DefaultSettingsButton_Leave(object sender, EventArgs e)
        {
            DefaultSettingsButton.BorderColor = Color.FromArgb(24, 27, 32);
        }

        private void SaveSettingsButton_Enter(object sender, EventArgs e)
        {
            SaveSettingsButton.BorderColor = Color.FromArgb(190, 131, 254);
        }

        private void SaveSettingsButton_Leave(object sender, EventArgs e)
        {
            SaveSettingsButton.BorderColor = Color.FromArgb(138, 44, 254);
        }

        private void CloseSettingsButton_Enter(object sender, EventArgs e)
        {
            CloseSettingsButton.BorderColor = Color.FromArgb(170, 101, 254);
        }

        private void CloseSettingsButton_Leave(object sender, EventArgs e)
        {
            CloseSettingsButton.BorderColor = Color.FromArgb(24, 27, 32);
        }

        #endregion

        #region NumberOfWordsNumericUpDown focus events

        private void NumberOfWordsNumericUpDown_MouseHover(object sender, EventArgs e)
            => NumberOfWordsNumericUpDown.BorderColor = Color.FromArgb(170, 101, 254);

        private void NumberOfWordsNumericUpDown_MouseMove(object sender, MouseEventArgs e)
            => NumberOfWordsNumericUpDown.BorderColor = Color.FromArgb(170, 101, 254);

        private void NumberOfWordsNumericUpDown_MouseEnter(object sender, EventArgs e)
            => NumberOfWordsNumericUpDown.BorderColor = Color.FromArgb(170, 101, 254);

        private void NumberOfWordsNumericUpDown_MouseLeave(object sender, EventArgs e)
            => NumberOfWordsNumericUpDownReaction();

        void NumberOfWordsNumericUpDownReaction()
        {
            //if (Cursor != Cursors.IBeam)
            NumberOfWordsNumericUpDown.BorderColor = Color.FromArgb(74, 84, 93);
        }

        #endregion

        private void Escape_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                CloseSettingsButton.PerformClick();
        }
    }
}
