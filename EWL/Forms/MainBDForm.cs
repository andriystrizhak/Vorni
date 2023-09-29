﻿using EWL.EF_SQLite;
using EWL.NOT_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EWL
{
    public partial class MainBDForm : Form
    {
        //Pay attention on:
        //- "//CHANGE"
        //- "//TODO"
        //- "//CHECK"

        /// <summary>
        /// Розташування TopPanel (для переміщення вікна мишкою)
        /// </summary>
        Point lastPoint;

        /// <summary>
        /// Кількість слів доданих за один раз
        /// </summary>
        int addedWords = 0; //CHANGE
        /// <summary>
        /// Список слів для вивчення
        /// </summary>
        List<Word> words = new();
        //List<DB_Word> words = new();
        /// <summary>
        /// Індекс поточного слова для вивчення зі списку words
        /// </summary>
        int wordIndex = 0;
        /// <summary>
        /// Оцінки поточних слів
        /// </summary>
        int[] wordRatings = { 0, 0, 0, 0, 0, 0 }; //CHANGE

        //List<DB_WordCategory> wordCategories = null;
        List<Category> categories = null; //TODO
        int curentCategoryID;             //TODO

        public MainBDForm()
        {
            InitializeComponent();
            MenuPanel.BringToFront();

            this.KeyPreview = true;
            this.KeyDown += MainBDForm_KeyDown;

            WSourceComboBox.Text = WSourceComboBox.Items[0].ToString();

            SetCategoriesList();
        }

        //TODO
        #region [ Category ]

        void SetCategoriesList()
        {
            categories = SQLs.Get_Categories();
            //TODO
        }

        #endregion

        #region [ TopPanel ]

        private void CloseButton_Click(object sender, EventArgs e)
            => this.Close();

        private void MinimizeButton_Click(object sender, EventArgs e)
            => this.WindowState = FormWindowState.Minimized;

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

        #region [[ Головне меню ]]

        #region [ Вивчати слова ]

        private void LearnWButton_Click(object sender, EventArgs e)
        {
            NumberOfWordsNumericUpDown.Value = SQLs.Get_NumberOfWordsToLearn();
            words = SQLs
                .Get_Words_FromCategory(SQLs.Get_CurrentCategory(), SQLs.Get_NumberOfWordsToLearn())
                .Select(w => w.Item1)
                .ToList();
            StartLearning();
        }

        private void StartLearning()
        {
            EngWLabel1.Text = words[wordIndex].EngWord;
            EngWLabel2.Text = words[wordIndex].EngWord;
            ShowPanel(LearningEngPanel);
        }

        #region Властивості контролів LearningWPanel

        private void SeeTransButton_Click(object sender, EventArgs e)
        {
            TranslationLabel.Text = words[wordIndex].UaTranslation;
            LearningUaPanel.BringToFront();

            SQLs.Increment_WordRepetition(words[wordIndex].WordId);
        }

        private void Button1_Click(object sender, EventArgs e)
            => RateWord(1);
        private void Button2_Click(object sender, EventArgs e)
            => RateWord(2);
        private void Button3_Click(object sender, EventArgs e)
            => RateWord(3);
        private void Button4_Click(object sender, EventArgs e)
            => RateWord(4);
        private void Button5_Click(object sender, EventArgs e)
            => RateWord(5);

        /// <summary>
        /// Змінює значення оцінки слова в БД
        /// </summary>
        /// <param name="rating">Оцінка</param>
        void RateWord(int rating)
        {
            SQLs.Rate_Word(words[wordIndex].WordId, rating);
            wordRatings[rating]++;

            if (++wordIndex != words.Count)
            {
                EngWLabel1.Text = words[wordIndex].EngWord;
                EngWLabel2.Text = words[wordIndex].EngWord;
                LearningEngPanel.BringToFront();
            }
            else
            {
                LearningStatPanel.BringToFront();
                wordIndex = 0;
                OutputLearningStatistic();
            }
        }
        #endregion

        #region Властивості контролів LearningStatPanel
        void OutputLearningStatistic()
        {
            //int learnedWordsCount = wordRatings[1] + wordRatings[2] + wordRatings[3] + wordRatings[4] + wordRatings[5];
            LearningStatLabel.Text =
                $"Було вивчено слів: {words.Count} " +
                $"\n\nОцінки " +
                $"\n5 - {wordRatings[5]} слів ({((float)wordRatings[5] / words.Count):P1})" +
                $"\n4 - {wordRatings[4]} слів ({((float)wordRatings[4] / words.Count):P1})" +
                $"\n3 - {wordRatings[3]} слів ({((float)wordRatings[3] / words.Count):P1})" +
                $"\n2 - {wordRatings[2]} слів ({((float)wordRatings[2] / words.Count):P1})" +
                $"\n1 - {wordRatings[1]} слів ({((float)wordRatings[1] / words.Count):P1})\n\n";

            double learningRating = ((double)(wordRatings[5] * 5
                + wordRatings[4] * 4 + wordRatings[3] * 3
                + wordRatings[2] * 2 + wordRatings[1] * 1)
                / (words.Count * 5)) * 100;

            LearningRatingLabel.Text = $"Твоя успішність: {learningRating:f0}/100";
            if (learningRating > 90)
                LearningRatingLabel.ForeColor = Color.FromArgb(117, 222, 42);
            else if (learningRating > 75)
                LearningRatingLabel.ForeColor = Color.FromArgb(222, 204, 42);
            else if (learningRating > 60)
                LearningRatingLabel.ForeColor = Color.FromArgb(222, 150, 42);
            else
                LearningRatingLabel.ForeColor = Color.FromArgb(222, 69, 42);

            wordRatings = new int[] { 0, 0, 0, 0, 0, 0 };
        }

        private void RetryButton_Click(object sender, EventArgs e)
            => StartLearning();

        #endregion

        #endregion

        #region [ Додати слова ]

        private void SeeAddingWPanelButton_Click(object sender, EventArgs e)
        {
            addedWords = 0;
            int wAddingMode = SQLs.Get_WordAddingMode();

            NullEngUaTextBoxes();
            EngUaStringTextBox.Text = "";
            TxtFilePathTextBox.Text = "";

            if (wAddingMode == 0)
                AddingWPanel1.BringToFront();
            if (wAddingMode == 1)
                AddingWPanel2.BringToFront();
            if (wAddingMode == 2)
                AddingWPanel3.BringToFront();
        }

        #region Властивості контролів AddingWPanel

        #region AddingWPanel1
        private void AddWButton1_Click(object sender, EventArgs e)
        {
            string engWord = AddEngWTextBox.Text;
            string uaTrans = AddUaTTextBox.Text;

            if (!SQLs.TryAdd_Word_ToAllWords(engWord, uaTrans))
                MessageBox.Show(
                    "Таке ж слово вже існує в БД",
                    "Не сіпайся, все добре",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            else
            {
                addedWords++;
                CancelPrevButton1.Enabled = true;
                NullEngUaTextBoxes();
            }
        }

        /// <summary>
        /// Скидає AddingWPanel до початкового стану
        /// </summary>
        void NullEngUaTextBoxes()
        {
            AddEngWTextBox.Text = "";
            AddUaTTextBox.Text = "";
            AddWButton1.Enabled = false;
        }

        private void CancelPrevButton_Click(object sender, EventArgs e)
        {
            SQLs.Remove_LastWords_Permanently(1);
            addedWords--;
            if (addedWords == 0)
            {
                CancelPrevButton1.Enabled = false;
                CancelPrevButton2.Enabled = false;
            }
        }

        #region Властивості текстових полів AddingWPanel1
        private void EngUaTextBox_TextChanged(object sender, EventArgs e)
        {
            if (AddEngWTextBox.Text != "" && AddUaTTextBox.Text != "")
                AddWButton1.Enabled = true;
        }

        private void EngTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int charCode = e.KeyChar;
            if (!(charCode >= 65 && charCode <= 90)   // Великі латинські букви A-Z
                && !(charCode >= 97 && charCode <= 122)   // Малі латинські букви a-z
                && charCode != 8 && charCode != 32         // Backspace (8) та пробіл (32)
                && charCode != '(' && charCode != ')'
                && charCode != '-')
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

        #region AddingWPanel2

        private void EngUaStringTextBox_TextChanged(object sender, EventArgs e)
            => AddWButton2.Enabled = true;

        private void AddWButton2_Click(object sender, EventArgs e)
        {
            var word = Txt_FileHandler.SplitSpecialLine(EngUaStringTextBox.Text);

            if (!SQLs.TryAdd_Word_ToAllWords(word.Eng, word.Ua))
                MessageBox.Show(
                    "Таке ж слово вже існує в БД",
                    "Не сіпайся, все добре",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            else
            {
                addedWords++;
                CancelPrevButton2.Enabled = true;
                EngUaStringTextBox.Text = "";
            }
        }

        //див. CancelPrevButton_Click() - для обох панелей (1 і 2)
        #endregion

        #region AddingWPanel3

        private void TxtFilePathTextBox_TextChanged(object sender, EventArgs e)
            => AddWButton3.Enabled = true;

        private void AddWButton3_Click(object sender, EventArgs e)
        {
            var report = Txt_FileHandler.AddWordsFromTxtFile(TxtFilePathTextBox.Text);
            MessageBox.Show(
                $"Всього слів в файлі: {report.Item1}\nБуло додано: {report.Item2}",
                "Звіт про додавання слів",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            addedWords = report.Item2;
            TxtFilePathTextBox.Text = "";
            CancelAddingButton.Enabled = true;
        }

        private void CancelAddingButton_Click(object sender, EventArgs e)
        {
            SQLs.Remove_LastWords_Permanently(addedWords);
            addedWords = 0;
            CancelAddingButton.Enabled = false;
        }

        #endregion

        #endregion

        #endregion

        #region [ Налаштування ]

        private void SettingButton_Click(object sender, EventArgs e)
        {
            NumberOfWordsNumericUpDown.Value = SQLs.Get_NumberOfWordsToLearn();
            WSourceComboBox.SelectedIndex = SQLs.Get_WordAddingMode();
            SaveSettingsButton.Enabled = false;
            DefaultSettingsButton.Enabled = true;
            SettingPanel.BringToFront();
        }

        #region Властивості контролів SettingPanel

        private void WordCountNumericUpDown_ValueChanged(object sender, EventArgs e)
            => SaveSettingsButton.Enabled = true;

        private void WSourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
            => SaveSettingsButton.Enabled = true;


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

            NumberOfWordsNumericUpDown.Value = 10;
            WSourceComboBox.SelectedIndex = 0;
        }
        #endregion

        #endregion

        #region [ Переглянути статистику ]

        private void SeeStatButton_Click(object sender, EventArgs e)
        {
            var stat = SQLs.Get_Statistic();
            int count = stat.AllWordCount;
            var ratings = stat.AllRatings;
            StatLabel.Text =
                $"Всього слів в БД — {stat.AllWordCount} " +
                $"\n\nОцінки: " +
                $"\n5 — {ratings[5]} слів ({((float)ratings[5] / count):P1})" +
                $"\n4 — {ratings[4]} слів ({((float)ratings[4] / count):P1})" +
                $"\n3 — {ratings[3]} слів ({((float)ratings[3] / count):P1})" +
                $"\n2 — {ratings[2]} слів ({((float)ratings[2] / count):P1})" +
                $"\n1 — {ratings[1]} слів ({((float)ratings[1] / count):P1})" +
                $"\n\nЩе не вивчалися — {ratings[0]} слів ({((float)ratings[0] / count):P1})";

            StatPanel.BringToFront();
        }

        #endregion

        //*******

        #region  Х( Поки не реалізовано )Х
        private void FullScreenButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) // Якщо вікно не в повноекранному режимі
            {
                this.WindowState = FormWindowState.Maximized; // Встановлюємо повноекранний режим
                TopPanel.Visible = false;
                FullScreenButton.ImageIndex = 0;
            }
            else // Якщо вікно в повноекранному режимі
            {
                this.WindowState = FormWindowState.Normal; // Відновлюємо нормальний режим вікна
                TopPanel.Visible = true;
                FullScreenButton.ImageIndex = 1;
            }
        }
        #endregion

        #endregion

        #region [ Назад, до меню ]

        private void GoBackButton_Click(object sender, EventArgs e)
            => MenuPanel.BringToFront();

        private void MainBDForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                GoBackButton_Click(sender, e); //CHECK
                                               //MenuPanel.BringToFront();
        }

        #endregion


        #region { OTHER }

        private void ShowPanel(Panel panelToShow)
        {
            foreach (Control panel in this.Controls)
                if (panel is Panel && panel != TopPanel)
                    panel.Visible = false;

            panelToShow.Visible = true;

            /*
            if (panelToShow == panel1)
            {
                // Встановити функцію для кнопки на panel1
            }
            else if (panelToShow == panel2)
            {
                // Встановити іншу функцію для кнопки на panel2
            }
            */
        }

        #endregion





        //TODOTODO 
        // - додати в правий верхній куток (всіх панелей додавання слів в БД) кнопку для перемикання режимів додавання слів до БД
        // - додати кнопку зі справкою щодо:
        //      - правил введення спеціального рядка зі словом
        //      - суть "Вивчення" слів у відповідному розділі
        // - додати вкладку "Мої словники"
        //      - можливість створювати власні словники, керувати ними та їх вмістом
        //      -  


        /*
        private void LearningUaPanel_Enter(object sender, EventArgs e)
            => isLearningUaPanelActive = true;
        private void LearningUaPanel_Leave(object sender, EventArgs e)
            => isLearningUaPanelActive = true;
        */
    }
}
