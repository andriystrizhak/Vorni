using Eng_Flash_Cards_Learner.NOT_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;

namespace Eng_Flash_Cards_Learner
{
    public partial class SetUpForm : Form
    {
        Point LastPoint;
        List<Panel?> PanelList = new();
        int PanelIndex = 0;

        bool[] GroupBoxesAreChanged { get; set; } = { false, false, false };
        int GroupBoxIndex = 0;

        readonly DB_SQLite DB = Program.DB;
        int AddedWords = 0;

        public SetUpForm()
        {
            InitializeComponent();
        }

        #region Властивості верхньої панелі TopPanel

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Program.Mode = LearningMode.None;
            this.Close();
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
            => LastPoint = new Point(e.X, e.Y);
        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }

        #endregion

        //*************************************************************

        private void SourceTypeGroupBox_Enter(object sender, EventArgs e)
        {
            continueButton.Enabled = true;
            GroupBoxesAreChanged[GroupBoxIndex] = true;
        }

        //*************************************************************

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            #region Логіка переходу на нову форму
            if (continueButton.Text == "Вивчати!")
            {
                if (PanelList[PanelIndex] == panel4)
                {
                    MessageBox.Show(
                        "Це ще поки не реалізовано, киш-киш!",
                        "Технічні шеколадки",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    PanelIndex--;
                }
                else
                {
                    DB.SetWasLaunched(true);
                    Program.Mode = LearningMode.DataBase;
                    this.Close();
                }
            }
            #endregion
            #region Логіка розгалуження
            PanelList[2] = radioButtonBD.Checked ? panel3 : panel4;

            if (PanelList[PanelIndex] == panel3)
            {
                if (radioButtonAddNewW.Checked)
                    PanelList.Add(panel5);
                else PanelList = PanelList.Take(3).ToList();
            }
            #endregion

            if (PanelIndex < PanelList.Count - 1)
                PanelList[++PanelIndex]?.BringToFront();    //Перевірка на null або впевнитись в безпечності
            previousButton.Enabled = true;
            ContinueButton_Disable();
            ContinueButton_ChangeText();
        }

        #region Властивості кнопки "Продовжити"

        /// <summary>
        /// Метод для автоматичного відключeння кнопки "Продовжити"
        /// </summary>
        private void ContinueButton_Disable()
        {
            GroupBoxIndex = PanelList[PanelIndex] == panel2
            ? 0 : PanelList[PanelIndex] == panel3 ? 1 : 2;

            if ((PanelIndex == 1 || PanelIndex == 2) && !GroupBoxesAreChanged[GroupBoxIndex])
                continueButton.Enabled = false;
        }

        /// <summary>
        /// Метод для автоматичної зміни тексту кнопки "Продовжити"
        /// </summary>
        private void ContinueButton_ChangeText()
        {
            if (PanelIndex == 3
                || PanelList[PanelIndex] == panel4
                || (PanelList[PanelIndex] == panel3 && radioButtonLearnAvaliableW.Checked))
                continueButton.Text = "Вивчати!";
            else continueButton.Text = "Продовжити";
        }

        private void RadioButtonAddNewW_CheckedChanged(object sender, EventArgs e)
            => continueButton.Text = "Продовжити";
        private void RadioButtonLearnAvaliableW_CheckedChanged(object sender, EventArgs e)
            => continueButton.Text = "Вивчати!";

        #endregion

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (PanelIndex > 0)
                PanelList[--PanelIndex]?.BringToFront();    //Перевірка на null або впевнитись в безпечності
            if (PanelIndex == 0)
                previousButton.Enabled = false;
            continueButton.Enabled = true;
            ContinueButton_ChangeText();
        }

        //*************************************************************

        private void SetUpForm_Load(object sender, EventArgs e)
        {
            PanelList.Add(panel1);
            PanelList.Add(panel2);
            PanelList.Add(null);

            PanelList[PanelIndex]?.BringToFront();    //Перевірка на null або впевнитись в безпечності
        }

        #region Додавання нових слів
        private void AddWButton_Click(object sender, EventArgs e)
        {
            string engWord = EngTextBox.Text;
            string uaTrans = UaTextBox.Text;

            if (!DB.TryAdd_Word_ToAllWords(engWord, uaTrans))
                MessageBox.Show("Таке ж слово вже існує в БД", "Х'юстон, проблемка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                AddedWords++; //NEW
                EngTextBox.Text = "";
                UaTextBox.Text = "";
                AddWButton.Enabled = false;
                CancelPrevButton.Enabled = true;
            }
        }

        private void CancelPrevButton_Click(object sender, EventArgs e)
        {
            DB.Remove_LastWords_Permanently(1);
            AddedWords--;
            if (AddedWords <= 0)
                CancelPrevButton.Enabled = false;
        }

        #region Властивості текстових полів panel5

        private void EngUaTextBox_TextChanged(object sender, EventArgs e)
        {
            if (EngTextBox.Text != "" && UaTextBox.Text != "")
                AddWButton.Enabled = true;
        }

        private void EngTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int charCode = e.KeyChar;
            if (!(charCode >= 65 && charCode <= 90)   // Великі латинські букви A-Z
                && !(charCode >= 97 && charCode <= 122)   // Малі латинські букви a-z
                && charCode != 8 && charCode != 32         // Backspace (8) та пробіл (32)
                && charCode != '(' && charCode != ')')
                e.Handled = true;
        }

        private void UaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int charCode = e.KeyChar;
            if (!(charCode >= 1040 && charCode <= 1103)
                && charCode != 8 && charCode != 32
                && charCode != '(' && charCode != ')')
                e.Handled = true;
        }

        #endregion

        #endregion

    }
}
