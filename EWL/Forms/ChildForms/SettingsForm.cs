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
            SaveSettingsButton.Focus();
        }

        private void CloseSettingsButton_Click(object sender, EventArgs e)
        {
            handler.Close();
            Close();
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


        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            SaveSettingsButton.Enabled = false;
            DefaultSettingsButton.Enabled = true;

            SQLs.Set_NumberOfWordsToLearn((int)NumberOfWordsNumericUpDown.Value);
            SQLs.Set_WordAddingMode(WSourceComboBox.SelectedIndex);
        }

        private void DefaultSettingsButton_Click(object sender, EventArgs e)
        {
            DefaultSettingsButton.Enabled = false;
            SQLs.Set_NumberOfWordsToLearn(10);
            SQLs.Set_WordAddingMode(0);

            NumberOfWordsNumericUpDown.Value = DefaultNumberOfWordsToLearn;
            WSourceComboBox.SelectedIndex = DefaultAddingWModeIndex;
        }

        #region NumberOfWordsNumericUpDown

        private void NumberOfWordsNumericUpDown_MouseHover(object sender, EventArgs e)
            => NumberOfWordsNumericUpDown.BorderColor = Color.FromArgb(170, 101, 254);

        private void NumberOfWordsNumericUpDown_MouseLeave(object sender, EventArgs e)
            => NumberOfWordsNumericUpDownReaction();

        private void NumberOfWordsNumericUpDown_MouseMove(object sender, MouseEventArgs e)
            => NumberOfWordsNumericUpDown.BorderColor = Color.FromArgb(170, 101, 254);

        private void NumberOfWordsNumericUpDown_MouseEnter(object sender, EventArgs e)
            => NumberOfWordsNumericUpDown.BorderColor = Color.FromArgb(170, 101, 254);

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

        #region Button focuse event

        private void DefaultSettingsButton_Enter(object sender, EventArgs e)
        {
            DefaultSettingsButton.BorderColor = Color.FromArgb(170, 101, 254);
        }

        private void DefaultSettingsButton_Leave(object sender, EventArgs e)
        {
            DefaultSettingsButton.BorderColor = Color.FromArgb(33, 38, 42);
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
            CloseSettingsButton.BorderColor = Color.FromArgb(33, 38, 42);
        }

        #endregion
    }
}
