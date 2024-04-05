using EWL.EF_SQLite;
using EWL.NOT_Forms;
using System.Data;

namespace EWL
{
    public partial class SetUpForm : Form
    {
        /// <summary>
        /// Розташування TopPanel (для переміщення вікна мишкою)
        /// </summary>
        Point lastPoint;

        /// <summary>
        /// Список панелей в "шляху" логіки форми
        /// </summary>
        List<Panel> panelList = new();
        int currentPanelIndex = 0;

        /// <summary>
        /// Список з даними для кожного groupBox-а про те чи вносилися в нього зміни
        /// </summary>
        bool[] groupBoxesWasChanged { get; set; } = { false, false, false };
        int currentGroupBoxIndex = 0;

        /// <summary>
        /// Кількість доданих слів
        /// </summary>
        int addedWordsCount = 0;

        public SetUpForm()
        {
            InitializeComponent();
        }

        #region [ Підготовка форми ]

        private void SetUpForm_Load(object sender, EventArgs e)
        {
            panelList.Add(startingPanel1);
            panelList.Add(dbOrTxtPanel2);
            panelList.Add(null!);

            ShowPanel(panelList[currentPanelIndex]);
        }

        #endregion

        #region [[ TopPanel ]]

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Program.Mode = LearningMode.None;
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

        #region [[ BottomPanel ]]

        #region ( 'goBackButton' properties )

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (currentPanelIndex > 0)
                ShowPanel(panelList[--currentPanelIndex]);
            if (currentPanelIndex == 0)
                goBackButton.Enabled = false;
            continueButton.Enabled = true;
            ContinueButton_ChangeText();
        }

        #endregion

        #region ( 'continueButton' properties )

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            #region Перехід на нову форму
            if (continueButton.Text == "Вивчати!")
            {
                if (panelList[currentPanelIndex] == txtActionPanel4)
                {
                    MessageBox.Show(
                        "Це ще поки не реалізовано, киш-киш!",
                        "Технічні шеколадки",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    currentPanelIndex--;
                }
                else
                {
                    SQLService.Set_WasLaunched(true);
                    Program.Mode = LearningMode.DataBase;
                    this.Close();
                }
            }
            #endregion
            #region Розгалуження
            if (currentPanelIndex == 1)
                panelList[2] = radioButtonBD.Checked ? dbActionPanel3 : txtActionPanel4; //CHECK

            if (panelList[currentPanelIndex] == dbActionPanel3)
            {
                if (radioButtonAddNewW.Checked)
                    panelList.Add(wAddingPanel5);
                else panelList = panelList.Take(3).ToList();
            }
            #endregion

            if (currentPanelIndex < panelList.Count - 1)
                ShowPanel(panelList[++currentPanelIndex]);
            goBackButton.Enabled = true;
            ContinueButton_Disable();
            ContinueButton_ChangeText();
        }

        #region [ 'continueButton' Logic ]

        /// <summary>
        /// Метод для перевірки й автоматичного відключeння кнопки "Продовжити"
        /// </summary>
        private void ContinueButton_Disable()
        {
            currentGroupBoxIndex = currentPanelIndex == 1
                ? 0 : currentPanelIndex == 2 && panelList[currentPanelIndex] == dbActionPanel3
                ? 1 : 2;

            if ((currentPanelIndex == 1 || currentPanelIndex == 2)
                && !groupBoxesWasChanged[currentGroupBoxIndex])
                continueButton.Enabled = false;
        }

        /// <summary>
        /// Метод для перевірки й автоматичної зміни тексту кнопки "Продовжити"
        /// </summary>
        private void ContinueButton_ChangeText()
        {
            if (currentPanelIndex == 3
                || panelList[currentPanelIndex] == txtActionPanel4
                || (panelList[currentPanelIndex] == dbActionPanel3 && radioButtonLearnAvaliableW.Checked))
                continueButton.Text = "Вивчати!";
            else continueButton.Text = "Продовжити";
        }

        #endregion

        #endregion

        #endregion

        #region [[ Main Panels ]]

        private void SourceTypeGroupBox_Enter(object sender, EventArgs e)
        {
            continueButton.Enabled = true;
            groupBoxesWasChanged[currentGroupBoxIndex] = true;
        }

        #region ( Властивості radioButtn-ів )

        private void RadioButtonAddNewW_CheckedChanged(object sender, EventArgs e)
            => continueButton.Text = "Продовжити";
        private void RadioButtonLearnAvaliableW_CheckedChanged(object sender, EventArgs e)
            => continueButton.Text = "Вивчати!";

        #endregion

        #region [ Додавання нових слів ]
        private void AddWButton_Click(object sender, EventArgs e)
        {
            string engWord = EngTextBox.Text;
            string uaTrans = UaTextBox.Text;

            if (!SQLService.TryAdd_Word_ToAllWords(engWord, uaTrans))
                MessageBox.Show("Таке ж слово вже існує в БД", "Х'юстон, проблемка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                addedWordsCount++; //NEW
                EngTextBox.Text = "";
                UaTextBox.Text = "";
                AddWButton.Enabled = false;
                CancelPrevButton.Enabled = true;
            }
        }

        private void CancelPrevButton_Click(object sender, EventArgs e)
        {
            SQLService.Remove_LastWords_Permanently(1);
            addedWordsCount--;
            if (addedWordsCount <= 0)
                CancelPrevButton.Enabled = false;
        }

        #region ( Властивості текстових полів wAddingPanel5 )

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
                && charCode != '(' && charCode != ')'
                && charCode != 13 && charCode != 'і'
                && charCode != '-' && charCode != '\'')
                e.Handled = true;
        }

        #endregion

        #endregion

        #endregion


        #region { OTHER }

        private void ShowPanel(Panel panelToShow)
        {
            foreach (Control panel in this.Controls)
                if (panel is Panel
                    && panel != TopPanel
                    && panel != BannerPanel
                    && panel != BottomPanel)
                    panel.Visible = false;

            if (panelToShow != null)
                panelToShow.Visible = true;

            /*
            if (panelToShow == panel1)
                // Встановити функцію для кнопки на panel1
            else if (panelToShow == panel2)
                // Встановити іншу функцію для кнопки на panel2
            */
        }

        #endregion
    }
}
