using Eng_Flash_Cards_Learner.Logic;
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
        Point lastPoint;
        List<Panel> panelList = new List<Panel>();
        int panelIndex = 0;

        bool[] groupBoxesAreChanged = { false, false, false };
        int groupBoxIndex = 0;

        DB_SQLite db = Program.db;
        int addedWords = 0;

        public SetUpForm()
        {
            InitializeComponent();
        }

        #region Властивості верхньої панелі TopPanel

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Program.mode = LearningMode.None;
            this.Close();
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
            => lastPoint = new Point(e.X, e.Y);
        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        #endregion

        //*************************************************************

        private void SourceTypeGroupBox_Enter(object sender, EventArgs e)
        {
            continueButton.Enabled = true;
            groupBoxesAreChanged[groupBoxIndex] = true;
        }

        //*************************************************************

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            #region Логіка переходу на нову форму
            if (continueButton.Text == "Вивчати!")
            {
                if (panelList[panelIndex] == panel4)
                {
                    MessageBox.Show(
                        "Це ще поки не реалізовано, киш-киш!",
                        "Технічні шеколадки",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    panelIndex--;
                }
                else
                {
                    db.SetWasLaunched(true);
                    Program.mode = LearningMode.DataBase;
                    this.Close();
                }
            }
            #endregion
            #region Логіка розгалуження
            panelList[2] = radioButtonBD.Checked ? panel3 : panel4;

            if (panelList[panelIndex] == panel3)
            {
                if (radioButtonAddNewW.Checked)
                    panelList.Add(panel5);
                else panelList = panelList.Take(3).ToList();
            }
            #endregion

            if (panelIndex < panelList.Count - 1)
                panelList[++panelIndex].BringToFront();
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
            groupBoxIndex = panelList[panelIndex] == panel2
            ? 0 : panelList[panelIndex] == panel3 ? 1 : 2;

            if ((panelIndex == 1 || panelIndex == 2) && !groupBoxesAreChanged[groupBoxIndex])
                continueButton.Enabled = false;
        }

        /// <summary>
        /// Метод для автоматичної зміни тексту кнопки "Продовжити"
        /// </summary>
        private void ContinueButton_ChangeText()
        {
            if (panelIndex == 3
                || panelList[panelIndex] == panel4
                || (panelList[panelIndex] == panel3 && radioButtonLearnAvaliableW.Checked))
                continueButton.Text = "Вивчати!";
            else continueButton.Text = "Продовжити";
        }

        private void radioButtonAddNewW_CheckedChanged(object sender, EventArgs e)
            => continueButton.Text = "Продовжити";
        private void radioButtonLearnAvaliableW_CheckedChanged(object sender, EventArgs e)
            => continueButton.Text = "Вивчати!";

        #endregion

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (panelIndex > 0)
                panelList[--panelIndex].BringToFront();
            if (panelIndex == 0)
                previousButton.Enabled = false;
            continueButton.Enabled = true;
            ContinueButton_ChangeText();
        }

        //*************************************************************

        private void SetUpForm_Load(object sender, EventArgs e)
        {
            panelList.Add(panel1);
            panelList.Add(panel2);
            panelList.Add(null);

            panelList[panelIndex].BringToFront();
        }

        #region Додавання нових слів
        private void AddWButton_Click(object sender, EventArgs e)
        {
            string engWord = EngTextBox.Text;
            string uaTrans = UaTextBox.Text;

            if (!db.TryAdd_Word_ToAllWords(engWord, uaTrans))
            {
                MessageBox.Show("Таке ж слово вже існує в БД", "Х'юстон, проблемка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                addedWords++;
            }
            else
            {
                EngTextBox.Text = "";
                UaTextBox.Text = "";
                AddWButton.Enabled = false;
                CancelPrevButton.Enabled = true;
            }
        }

        private void CancelPrevButton_Click(object sender, EventArgs e)
        {
            db.Remove_LastWords_FromAllWords(1);
            addedWords--;
            if (addedWords == 0)
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
