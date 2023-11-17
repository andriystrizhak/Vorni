using System.Data;

using EWL.EF_SQLite;
using EWL.NOT_Forms;
using DevExpress.XtraSplashScreen;
using Eng_Flash_Cards_Learner.Forms.UserControls;
using Eng_Flash_Cards_Learner.Forms.ChildForms;
using Eng_Flash_Cards_Learner.NOT_Forms;
using Eng_Flash_Cards_Learner.NOT_Forms.GPT;
using static EWL.NOT_Forms.Txt_FileHandler;
using Eng_Flash_Cards_Learner.NOT_Forms.LearningItems;
using DevExpress.XtraReports;

namespace EWL
{
    public partial class MainForm : Form
    {
        //Pay attention on:
        //- "//CHANGE"
        //- "//TODO"
        //- "//CHECK"
        //- "//ADD"

        //- "//TODO DIFFICULTY"
        //- "//TODO CATEGORY"

        /// <summary>
        /// Розташування <see cref="TopPanel"/> (для переміщення вікна мишкою)
        /// </summary>
        Point lastPoint;
        /// <summary>
        /// Розташування <see cref="EngUaStringTextBox"/> (для розширення EngUaStringTextBox мишкою)
        /// </summary>
        Point lastResizeBoxPoint;


        /// <summary>
        /// Кількість слів доданих за один раз в розділі "Додати слова"
        /// </summary>
        int addedWordsCount = 0;

        /// <summary>
        /// Список слів для вивчення
        /// </summary>
        List<Word> Words { get; set; } = new();
        /// <summary>
        /// Індекс поточного слова для вивчення зі списку <see cref="Words"/>
        /// </summary>
        int CurrentWIndex { get; set; } = 0;
        /// <summary>
        /// Оцінки поточних слів
        /// </summary>
        int[] wordRatings { get; set; } = { 0, 0, 0, 0, 0, 0 }; //CHANGE

        List<Category> categories = null!; //TODO CATEGORY
        int curentCategoryID;             //TODO CATEGORY

        public MainForm()
        {
            KeyDown += Enter_KeyDown!;
            KeyDown += Escape_KeyDown!;
            //KeyDown += RateW_KeyDown!;
            KeyDown += CtrlS_KeyDown!;
            KeyDown += CtrlZ_KeyDown!;

            InitializeComponent();
            ShowPanel(MenuPanel);

            SetCategoriesList();
        }

        //TODO CATEGORY - Імплементувати
        #region [ Category ]

        void SetCategoriesList()
        {
            categories = SQLs.Get_Categories();
            CategoriesComboBox.DataSource = categories.Select(c => c.Name).ToList();
        }

        #endregion

        #region [[ Other Panels ]]

        #region [ TopPanel ]

        private void CloseButton_Click(object sender, EventArgs e)
        {
            var handler = ShowProgressPanel(this);

            DialogResult closeForm = MessageBox.Show(
                "Ти точно хочеш вийти?", "Па-па?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (closeForm == DialogResult.Yes) Close();
            handler.Close();
        }

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

        #region [ SidebarPanel ]

        //TODO - SIDEBAR

        #endregion

        #region [ BackgroundPanel ]

        private void MainForm_Activated(object sender, EventArgs e)
            => BackgroundPanel.BorderColor = Color.FromArgb(170, 101, 254);

        private void MainForm_Deactivate(object sender, EventArgs e)
            => BackgroundPanel.BorderColor = Color.FromArgb(74, 84, 93);

        #endregion

        #endregion

        #region [[ Головне меню ]]

        #region [ Вивчати слова ]

        private void LearnWButton_Click(object sender, EventArgs e)
        {
            FCMethodButton.Checked = false;
            TestMethodButton.Checked = false;
            StartLearningButton.Enabled = false;

            GPTToggleSwitch.Checked = true;

            CategoriesComboBox.SelectedIndex = SQLs.Get_CurrentCategory() - 1;
            NumberOfWordsNumericUpDown.Value = SQLs.Get_NumberOfWordsToLearn();
            DifficultyComboBox.SelectedIndex = SQLs.Get_CurrentDifficulty();
            NumberOfWordsNumericUpDown.UpDownButtonForeColor = Color.White;

            ShowPanel(LearningPanel);
        }

        #region ( LearningPanel )

        bool IsGPTChecked { get; set; } = true;

        private void StartLearningButton_Click(object sender, EventArgs e)
        {
            SQLs.Set_NumberOfWordsToLearn((int)NumberOfWordsNumericUpDown.Value);
            SQLs.Set_CurrentCategory(CategoriesComboBox.SelectedIndex + 1);
            SQLs.Set_CurrentDifficulty(DifficultyComboBox.SelectedIndex);

            Words = SQLs
                .Get_Words_FromCategory(SQLs.Get_CurrentCategory(),
                SQLs.Get_NumberOfWordsToLearn(), SQLs.Get_CurrentDifficulty())
                .Select(w => w.Item1)
                .ToList();

            var purpose = GptPurpose.FlashCards;
            if (FCMethodButton.Checked)
                purpose = GptPurpose.FlashCards;
            else if (TestMethodButton.Checked)
                purpose = GptPurpose.Test;

            if (IsGPTChecked)
                AskGPT(purpose);
            else
                PrepareLearnigPanels();
        }

        private void PrepareLearnigPanels()
        {
            if (FCMethodButton.Checked)
            {
                List<string> sentenses = new List<string>();
                if (IsGPTChecked)
                    //TODO - врахувати всі виключення
                    sentenses = GPTResponseHandler.Handle_FCGPTResponse(GPTResponse);
                else
                    for (int i = 0; i < Words.Count; i++)
                        sentenses.Add("");

                FCItems = FCItem.CreateFCItems(Words, sentenses);

                PrepareFCLPanel();
                ShowPanel(FCLearingPanel);
            }
            else if (TestMethodButton.Checked)
            {
                //TODO - implement TestLearningPanel
                MessageBox.Show(
                    "Цей режим покищо не реалізований, зачекай",
                    "Розробник і так мало спить!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                //PrepareTLPanel();                      //НАЛАШТУВАННЯ панелі
                //ShowPanel(TestLearingPanel);
            }
        }

        #region LearningPanel events

        private void LearingMethod_CheckedChanged(object sender, EventArgs e)
        {
            if (FCMethodButton.Checked || TestMethodButton.Checked)
                StartLearningButton.Enabled = true;
            else StartLearningButton.Enabled = false;
        }

        private void GPTToggleSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (GPTToggleSwitch.Checked == false)
            {
                IsGPTChecked = false;
                TestMethodButton.Enabled = false;
                TestMethodButton.Checked = false;
                CheckGPTPanel.BorderColor = Color.FromArgb(74, 84, 93);
            }
            else
            {
                IsGPTChecked = true;
                TestMethodButton.Enabled = true;
                CheckGPTPanel.BorderColor = Color.FromArgb(21, 220, 173);
            }
        }

        #region NumberOfWordsNumericUpDown

        private void NumberOfWordsNumericUpDown_MouseHover(object sender, EventArgs e)
            => NumberOfWordsNumericUpDown.BorderColor = Color.FromArgb(170, 101, 254);

        private void NumberOfWordsNumericUpDown_MouseMove(object sender, MouseEventArgs e)
            => NumberOfWordsNumericUpDown.BorderColor = Color.FromArgb(170, 101, 254);

        private void NumberOfWordsNumericUpDown_MouseEnter(object sender, EventArgs e)
            => NumberOfWordsNumericUpDown.BorderColor = Color.FromArgb(170, 101, 254);

        private void NumberOfWordsNumericUpDown_MouseLeave(object sender, EventArgs e)
            => NumberOfWordsNumericUpDown.BorderColor = Color.FromArgb(74, 84, 93);

        #endregion

        #endregion

        #endregion

        #region { GPT Response }

        string GPTResponse { get; set; } = null;

        private void AskGPT(GptPurpose purpose)
        {
            var windowOptions = new OverlayWindowOptions(backColor: Color.Black, disableInput: true);
            var handler = ShowProgressPanel(CurrentPanel, windowOptions);

            var words = this.Words.Select(w => w.EngWord).ToArray();

            GptAPI.GPTResponseHandler += GPTResponse_GPTResponseHandler;
            GptAPI.GPTErrorHandler += GPTError_GPTErrorHandler;

            Task.Run(() => GptAPI.GetResponse(words, purpose, handler));
        }

        #region FC GPT events

        void GPTResponse_GPTResponseHandler(string response, IOverlaySplashScreenHandle handler)
        {
            GPTResponse = response;
            FCLearingPanel.Invoke(PrepareLearnigPanels);
            handler.Close();

            Clear_FCGPTEventsHandlers();
        }

        void GPTError_GPTErrorHandler(string response, IOverlaySplashScreenHandle handler)
        {
            handler.Close();
            var errorText = HandleGPTErrorResponse(response.Split('\n')[0]);
            MessageBox.Show(
                errorText,
                "Щось пішло шкереберть!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Hand);

            Clear_FCGPTEventsHandlers();
        }

        string HandleGPTErrorResponse(string errorResponse)
            => errorResponse switch
            {
                "No connection" => "Схоже, в тебе проблеми зі з'єднанням :(",
                "invalid_api_key:" => "Вказаний API-ключ невірний",
                //ADD
                _ => "Не вдається отримати відповіді від GPT Х(\n" +
                "Спробуй навчатися з GPT пізніше"
            };

        void Clear_FCGPTEventsHandlers()
        {
            GptAPI.GPTResponseHandler -= GPTResponse_GPTResponseHandler;
            GptAPI.GPTErrorHandler -= GPTError_GPTErrorHandler;
        }

        #endregion

        #endregion

        #region ( FCLearningPanel )

        List<FCItem> FCItems { get; set; } = null;
        bool CurrentWFailed { get; set; } = false;

        /// <summary>
        /// Підготовлює й показує <see cref="FCLearingPanel"/>
        /// </summary>
        private void PrepareFCLPanel()
        {
            WCounterLabel.Text = $"{CurrentWIndex + 1} / {FCItems.Count}";
            FCSentenceLabel.Text = FCItems[CurrentWIndex].Sentence;
            FCUaTransLabel.Text = FCItems[CurrentWIndex].UaT;

            FCAnswerTextBox.Focus();
        }

        #region FCLearningPanel controls events

        private void FCGoBackButton_Click(object sender, EventArgs e)
        {
            var handler = ShowProgressPanel(this);

            var dialogResult = MessageBox.Show(
                "Ти точно хочеш перервати вивчення?\r\nРезультати всеодно збережуться",
                "Е, ти куди?..",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                Null_FCLPanel();
                LearnWButton_Click(sender, e);
            }

            handler.Close();
        }

        private void FCSentenceLabel_Resize(object sender, EventArgs e)
        {
            FCAnswerTextBox.Location = new Point(FCAnswerTextBox.Left, FCSentenceLabel.Bottom + 23);
            FCUaTransLabel.Location = new Point(FCUaTransLabel.Left, FCAnswerTextBox.Bottom + 23);
        }

        private void FCAnswerTextBox_TextChanged(object sender, EventArgs e)
        {
            FCAnswerTextBox.PlaceholderText = "";
            FCAnswerTextBox.BorderColor = Color.FromArgb(74, 84, 93);
            FCAnswerTextBox.FocusedState.BorderColor = Color.FromArgb(170, 101, 254);
        }

        private void FCCheckAnswerButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FCCheckAnswerButton.PerformClick();
        }

        #region FCCheckAnswer button event

        private void FCCheckAnswerButton_Click(object sender, EventArgs e)
        {
            if (CheckFCAnswer())
                Set_FCPanelCorrectAnswer();
            else
                Set_FCPanelWrongAnswer();
        }

        bool CheckFCAnswer()
            => FCAnswerTextBox.Text == FCItems[CurrentWIndex].EngW;

        void Set_FCPanelCorrectAnswer()
        {
            if (!CurrentWFailed)
                Set_FCWord_RatingAndRepetition(true);
            CurrentWFailed = false;

            if (++CurrentWIndex != Words.Count)
                PrepareFCLPanel();
            else
            {
                CurrentWIndex = 0;
                OutputLearningStatistic();
                ShowPanel(LearningStatPanel);
                RetryButton.Focus();
            }

            FCAnswerTextBox.Text = "";
            FCAnswerTextBox.BorderColor = Color.FromArgb(20, 190, 75);
            FCAnswerTextBox.FocusedState.BorderColor = Color.FromArgb(30, 214, 95);
            Task.Run(() =>
            {
                Thread.Sleep(700);
                FCAnswerTextBox.BorderColor = Color.FromArgb(74, 84, 93);
                FCAnswerTextBox.FocusedState.BorderColor = Color.FromArgb(170, 101, 254);
            });
        }

        void Set_FCPanelWrongAnswer()
        {
            if (!CurrentWFailed)
                Set_FCWord_RatingAndRepetition(false);
            CurrentWFailed = true;

            FCAnswerTextBox.Text = "";
            FCAnswerTextBox.PlaceholderText = FCItems[CurrentWIndex].EngW;
            FCAnswerTextBox.BorderColor = Color.FromArgb(210, 47, 47);
            FCAnswerTextBox.FocusedState.BorderColor = Color.FromArgb(245, 67, 67);
        }

        /// <summary>
        /// Increments (dectements) rating and repetition of current <see cref="FCItem"/>
        /// </summary>
        /// <param name="increment">Чи інкрементувати, чи декрементувати <paramref name="rating"/></param>
        void Set_FCWord_RatingAndRepetition(bool increment)
        {
            int rating = FCItems[CurrentWIndex].Rating;
            SQLs.Rate_Word(FCItems[CurrentWIndex].WordId, increment
                ? ((rating < 5) ? ++rating : rating)
                : ((rating > 1) ? --rating : rating));
            wordRatings[rating]++;
            SQLs.Increment_WordRepetition(FCItems[CurrentWIndex].WordId);
        }

        void Null_FCLPanel()
        {
            CurrentWIndex = 0;
            Words = null;
            FCItems = null;
            CurrentWFailed = false;
        }

        #endregion

        #endregion

        #endregion

        #region ( TLearningPanel )


        #endregion

        #region ( LearningStatPanel )

        void OutputLearningStatistic()
        {
            LearningStatLabel.Text =
                $"Було вивчено слів: {Words.Count} " +
                $"\n\nОцінки " +
                $"\n5 - {wordRatings[5]} слів ({((float)wordRatings[5] / Words.Count):P1})" +
                $"\n4 - {wordRatings[4]} слів ({((float)wordRatings[4] / Words.Count):P1})" +
                $"\n3 - {wordRatings[3]} слів ({((float)wordRatings[3] / Words.Count):P1})" +
                $"\n2 - {wordRatings[2]} слів ({((float)wordRatings[2] / Words.Count):P1})" +
                $"\n1 - {wordRatings[1]} слів ({((float)wordRatings[1] / Words.Count):P1})\n\n";

            double learningRating = ((double)(wordRatings[5] * 5
                + wordRatings[4] * 4 + wordRatings[3] * 3
                + wordRatings[2] * 2 + wordRatings[1] * 1)
                / (Words.Count * 5)) * 100;

            LearningRatingLabel.Text = $"Твоя успішність: {learningRating:f0}/100";
            if (learningRating > 85)
                LearningRatingLabel.ForeColor = Color.FromArgb(117, 222, 42);
            else if (learningRating > 70)
                LearningRatingLabel.ForeColor = Color.FromArgb(222, 204, 42);
            else if (learningRating > 50)
                LearningRatingLabel.ForeColor = Color.FromArgb(222, 150, 42);
            else
                LearningRatingLabel.ForeColor = Color.FromArgb(222, 69, 42);

            wordRatings = new int[] { 0, 0, 0, 0, 0, 0 };
        }

        private void RetryButton_Click(object sender, EventArgs e)
            => PrepareFCLPanel();

        #endregion

        #endregion

        #region [ Додати слова ]

        //TODO CATEGORY - Додати перемикач категорії для додавання слів
        private void SeeAddingWPanelButton_Click(object sender, EventArgs e)
        {
            addedWordsCount = 0;
            int wAddingMode = SQLs.Get_WordAddingMode();

            Null_EngUaTextBoxes();
            AddWTabControl.SelectedIndex = wAddingMode;
            ShowPanel(AddingWPanel);

            switch (wAddingMode)
            {
                case 0:
                    AddEngWTextBox.Focus();
                    break;
                case 1:
                    EngUaStringTextBox.Focus();
                    break;
                case 2:
                    ChooseFileButton.Focus();
                    break;
            }
        }

        /// <summary>
        /// Скидає <see cref="AddingWPanel"/> до початкового стану
        /// </summary>
        void Null_EngUaTextBoxes()
        {
            AddEngWTextBox.Text = "";
            AddUaTTextBox.Text = "";

            EngUaStringTextBox.Text = "";
            TxtFilesPathsTextBox.Text = "";
            Null_AddingWPanel3();

            AddWButton.Enabled = false;
            CancelAddingButton.Enabled = false;
        }

        #region AddingWPanel1

        private void AddWButton1_DoClick()
        {
            string engWord = AddEngWTextBox.Text;
            string uaTrans = AddUaTTextBox.Text;

            if (!SQLs.TryAdd_Word_ToAllWords(engWord, uaTrans))
                WordIsRepeatedPopup.Popup();
            else
            {
                WAddingReportPopup1.Popup();
                addedWordsCount++;
                Null_EngUaTextBoxes();
                CancelAddingButton.Enabled = true;
            }
        }

        private void CancelAddingButton1_DoClick()
        {
            SQLs.Remove_LastWords_Permanently(1);
            CancelWAddingPopup1.Popup();
            addedWordsCount--;
            if (addedWordsCount == 0)
                CancelAddingButton.Enabled = false;
        }

        #region ( Властивості текстових полів AddingWPanel1 )

        private void EngUaTextBox_TextChanged(object sender, EventArgs e)
        {
            if (AddEngWTextBox.Text != "" && AddUaTTextBox.Text != "")
                AddWButton.Enabled = true;
            else
                AddWButton.Enabled = false;
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
                && charCode != '-' && charCode != '/')
                e.Handled = true;
        }
        #endregion

        #endregion

        #region AddingWPanel2

        /// <summary>
        /// Виводить підходящий Popup
        /// </summary>
        /// <param name="isAnyInvalidLineThere">Чи були серед всіх рядків ті, які в хибному форматі</param>
        /// <param name="isAnyRepeatedWordThere">Чи були серед всіх слів ті, які вже додавалися раніше</param>
        void ShowAddingWPanel2_Popup(bool isAnyInvalidLineThere, bool isAnyRepeatedWordThere)
        {
            if (addedWordsCount <= 0)
                AllLinesAreInvalidOrRepeatedPopup.Popup();
            else if (isAnyInvalidLineThere && isAnyRepeatedWordThere)
                InvalidLinesAndRepeatedWordsopup.Popup();
            else if (isAnyInvalidLineThere)
                InvalidLinesFormatPopup.Popup();
            else if (isAnyRepeatedWordThere)
                WordsAreRepeatedPopup.Popup();

            if (addedWordsCount > 0)
            {
                WAddingReportPopup2.ContentText = $"Було успішно додано слів: {addedWordsCount}";
                WAddingReportPopup2.Popup();
                CancelAddingButton.Enabled = true;
                EngUaStringTextBox.Text = "";
            }
        }

        #region Focus events

        private void EngUaStringTextBox_TextChanged(object sender, EventArgs e)
        {
            if (EngUaStringTextBox.Text != "")
                AddWButton.Enabled = true;
            else
                AddWButton.Enabled = false;
        }

        private void AddWButton2_DoClick()
        {
            var lines = EngUaStringTextBox.Lines;
            addedWordsCount = 0;

            bool isAnyInvalidLineThere = false;
            bool isAnyRepeatedWordThere = false;

            foreach (var line in lines)
            {
                var word = GetWordFromLine(line);
                if (word == null)
                    isAnyInvalidLineThere = true;
                else if (!SQLs.TryAdd_Word_ToAllWords(word.Eng, word.Ua, word.Difficulty))
                    isAnyRepeatedWordThere = true;
                else
                    addedWordsCount++;
            }
            ShowAddingWPanel2_Popup(isAnyInvalidLineThere, isAnyRepeatedWordThere);
        }

        private void EngUaStringTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int charCode = e.KeyChar;
            if (!(charCode >= 65 && charCode <= 90)   // Великі латинські букви A-Z
                && !(charCode >= 97 && charCode <= 122)
                && !(charCode >= 1040 && charCode <= 1103)
                && charCode != 8 && charCode != 32
                && charCode != '(' && charCode != ')'
                && charCode != 13 && charCode != 'і'
                && charCode != '-' && charCode != '/'
                && charCode != '[' && charCode != ']')
                e.Handled = true;
        }

        private void EngUaStringTextBox_SizeChanged(object sender, EventArgs e)
        {
            EngUaStringTextBox.Width = 833;
            if (EngUaStringTextBox.Height < 35)
                EngUaStringTextBox.Height = 35;
            else if (EngUaStringTextBox.Height > 336)
                EngUaStringTextBox.Height = 336;

            var point = new Point((EngUaStringTextBox.Location.X + EngUaStringTextBox.Width) - 25, (EngUaStringTextBox.Location.Y + EngUaStringTextBox.Height) - 25);
            TextBox2ResizeBox.Location = point;
            EngUaStringTextBox.TextOffset = new Point(0, 0);
        }

        #endregion

        #endregion

        #region AddingWPanel3

        #region Files Adding

        #region Drag Drop

        /// <summary>
        /// Вказує на те чи курсор з файлом знаходиться над <see cref="DragAndDropPanel"/>
        /// </summary>
        bool isMouseOverDDP { get; set; } = false;
        /// <summary>
        /// Вказує на те чи якісь файли вже поміщені в <see cref="DragAndDropPanel"/>
        /// </summary>
        bool fileIsAdded { get => TxtFilesPathsTextBox.Text != ""; } //AddWButton3.Enabled; }
        /// <summary>
        /// Список доданих в <see cref="DragAndDropPanel"/> файлів
        /// </summary>
        List<string> files = new();

        private void DragAndDropPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;

            label13.Visible = false;
            TxtFilesPathsTextBox.Visible = false;
            ChooseFileButton.Visible = false;
            label12.Visible = false;
            label6.Visible = true;
            isMouseOverDDP = true;

            DragAndDropPanel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            DragAndDropPanel.BorderColor = Color.White;
        }

        private void DragAndDropPanel_DragLeave(object sender, EventArgs e)
            => Null_AddingWPanel3();

        /// <summary>
        /// Скидає <see cref="AddingWPanel"/> до початкового стану
        /// </summary>
        private void Null_AddingWPanel3()
        {
            if (fileIsAdded)
            {
                label13.Visible = true;
                TxtFilesPathsTextBox.Visible = true;
            }
            else
            {
                label13.Visible = false;
                TxtFilesPathsTextBox.Visible = false;
            }
            ChooseFileButton.Visible = true;
            label12.Visible = true;
            label6.Visible = false;
            isMouseOverDDP = false;

            DragAndDropPanel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            DragAndDropPanel.BorderColor = Color.FromArgb(74, 84, 93);
        }

        private void DragAndDropPanel_DragDrop(object sender, DragEventArgs e)
        {
            var filesToAdd = ((string[])e.Data.GetData(DataFormats.FileDrop));
            files.AddRange(filesToAdd
                .Where(x => x.Contains(".txt", StringComparison.OrdinalIgnoreCase))
                .ToList());
            files = files.Distinct().ToList();

            bool isInvalidFilesThere = false;
            foreach (var file in filesToAdd)
                if (!file.Contains(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    isInvalidFilesThere = true;
                    break;
                }
            if (isInvalidFilesThere)
                WrongFileFormatPopup.Popup();

            TxtFilesPathsTextBox.Text = string.Join("\r\n", files);

            if (files.Count > 0)
            {
                label13.Visible = true;
                TxtFilesPathsTextBox.Visible = true;
                label6.Visible = false;
                isMouseOverDDP = false;

                DragAndDropPanel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                DragAndDropPanel.BorderColor = Color.FromArgb(74, 84, 93);
            }
            else
                DragAndDropPanel_DragLeave(sender, e);
        }

        #endregion

        #region Files Dialog

        private void ChooseFileButton_Click(object sender, EventArgs e)
        {
            OpenTxtFilesDialog.ShowDialog();
            if (OpenTxtFilesDialog.FileName.Contains(".txt", StringComparison.OrdinalIgnoreCase))
            {
                TxtFilesPathsTextBox.Text = string.Join("\r\n", OpenTxtFilesDialog.FileNames);
                TxtFilesPathsTextBox.Visible = true;
            }
            else
                TxtFilesPathsTextBox.Text = "";
        }

        #endregion

        #endregion

        private void TxtFilePathTextBox_TextChanged(object sender, EventArgs e)
        {
            if (TxtFilesPathsTextBox.Text != "")
            {
                AddWButton.Enabled = true;
                files = TxtFilesPathsTextBox.Text
                    .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
            }
            else
            {
                files.Clear();
                AddWButton.Enabled = false;
                Null_AddingWPanel3();
            }
        }

        private async void AddWButton3_DoClick()
        {
            CloseButton.Enabled = false;
            var windowOptions = new OverlayWindowOptions(backColor: Color.Black, disableInput: true);
            var handle = ShowProgressPanel(DragAndDropPanel, windowOptions);

            (int, int, int) report = (0, 0, 0);
            await Task.Run(() => report = Txt_FileHandler.AddWordsFromTxtFiles(files));

            handle.Close();
            CloseButton.Enabled = true;

            WAddingReportPopup3.ContentText =
                $"Всього оброблених файлів: {report.Item3}\n" +
                $"Всього слів в файлах знайдено: {report.Item1}\n" +
                $"З них було додано: {report.Item2}";
            WAddingReportPopup3.Popup();

            label13.Visible = false;
            TxtFilesPathsTextBox.Text = "";

            addedWordsCount = report.Item2;
            if (addedWordsCount > 0)
                CancelAddingButton.Enabled = true;
        }

        private async void CancelAddingButton23_DoClick()
        {
            IOverlaySplashScreenHandle handle = null;
            if (AddWTabControl.SelectedIndex == 2)
            {
                CloseButton.Enabled = false;
                var windowOptions = new OverlayWindowOptions(backColor: Color.Black, disableInput: true);
                handle = ShowProgressPanel(DragAndDropPanel, windowOptions);
            }

            await Task.Run(() => SQLs.Remove_LastWords_Permanently(addedWordsCount));
            CancelWAddingPopup2.Popup();

            handle?.Close();
            CloseButton.Enabled = true;

            addedWordsCount = 0;
            CancelAddingButton.Enabled = false;
        }

        #endregion

        #region Add/Cancel buttons

        private void AddWButton_Click(object sender, EventArgs e)
        {
            switch (AddWTabControl.SelectedIndex)
            {
                case 0:
                    AddWButton1_DoClick();
                    break;
                case 1:
                    AddWButton2_DoClick();
                    break;
                case 2:
                    AddWButton3_DoClick();
                    break;
            }
        }

        private void CancelAddingButton_Click(object sender, EventArgs e)
        {
            switch (AddWTabControl.SelectedIndex)
            {
                case 0:
                    CancelAddingButton1_DoClick();
                    break;
                case 1:
                case 2:
                    CancelAddingButton23_DoClick();
                    break;
            }
        }

        private void AddWTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            addedWordsCount = 0;
            CancelAddingButton.Enabled = false;

            switch (AddWTabControl.SelectedIndex)
            {
                case 0:
                    EngUaTextBox_TextChanged(sender, e);
                    AddWButton.Text = "Додати слово";
                    break;
                case 1:
                    EngUaStringTextBox_TextChanged(sender, e);
                    AddWButton.Text = "Додати слова";
                    break;
                case 2:
                    TxtFilePathTextBox_TextChanged(sender, e);
                    AddWButton.Text = "Додати слова";
                    break;
            }
        }

        #region Focus

        private void CancelAddingButton_Enter(object sender, EventArgs e)
            => CancelAddingButton.BorderColor = Color.FromArgb(170, 101, 254);

        private void CancelAddingButton_Leave(object sender, EventArgs e)
            => CancelAddingButton.BorderColor = Color.FromArgb(33, 38, 42);

        private void AddWButton_Enter(object sender, EventArgs e)
            => AddWButton.BorderColor = Color.FromArgb(190, 131, 254);

        private void AddWButton_Leave(object sender, EventArgs e)
            => AddWButton.BorderColor = Color.FromArgb(138, 44, 254);

        #endregion

        #endregion

        #endregion

        #region [ Налаштування ]

        private void SettingButton_Click(object sender, EventArgs e)
        {
            var handler = ShowProgressPanel(this);
            new SettingsForm(this, handler).ShowDialog();
        }

        #endregion

        #region [ Переглянути статистику ]

        //TODO - Додати перемикач категорії для статистики
        //TODO - Додати можливість перегляду графіків

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
                (ratings[0] > 0
                ? $"\n\nЩе не вивчалися — {ratings[0]} слів ({((float)ratings[0] / count):P1})"
                : "\n\nВсі слова вже вивчалися тобою");

            ShowPanel(StatPanel);
        }

        #endregion

        //*******

        #region [ Назад, до Меню ]

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            ShowPanel(MenuPanel);
            LearnWButton.Focus();
        }

        #endregion

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

        #region < Гарячі клавіші >

        private void Escape_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (CurrentPanel != MenuPanel)
                {
                    if (CurrentPanel == FCLearingPanel)
                        FCGoBackButton.PerformClick();
                    else
                        GoBackButton_Click(sender, e);
                }
                else
                    CloseButton.PerformClick();
            }
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button7.PerformClick(); //CATEGORY
            }
        }

        private void CtrlS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
                AddWButton.PerformClick();
        }

        private void CtrlZ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                CancelAddingButton.PerformClick();

                button6.PerformClick(); //CATEGORY
            }
        }

        /* RATING WHITH 1-2-3-4-5
        private void RateW_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                    Button1.PerformClick();
                    break;
                case Keys.D2:
                    Button2.PerformClick();
                    break;
                case Keys.D3:
                    Button3.PerformClick();
                    break;
                case Keys.D4:
                    Button4.PerformClick();
                    break;
                case Keys.D5:
                    Button5.PerformClick();
                    break;
            }
        }
        */

        #endregion

        #region { OTHER }

        /// <summary>
        /// Панель, яка на поточний момент демонструється
        /// </summary>
        Panel CurrentPanel { get; set; }

        /// <summary>
        /// Показує <paramref name="panelToShow"/>, а всі інші приховує
        /// </summary>
        /// <param name="panelToShow">Панель, яка повинна бути показана</param>
        private void ShowPanel(Panel panelToShow)
        {
            /*
            if (CurrentPanel != null)
            {
                CurrentPanel.Enabled = false;
                CurrentPanel.Visible = false;
            }

            CurrentPanel = panelToShow;

            panelToShow.Enabled = true;
            panelToShow.Visible = true;
            */

            CurrentPanel = panelToShow;
            panelToShow.Enabled = true;
            panelToShow.Visible = true;
            panelToShow.BringToFront();

            foreach (Control panel in BackgroundPanel.Controls)
                if (panel is Panel
                    && panel != panelToShow)
                //&& panel != BackgroundPanel
                //&& panel != TopPanel
                //&& panel != SidebarPanel)
                {
                    panel.Enabled = false;
                    panel.Visible = false;
                }
        }

        /// <summary>
        /// Накладає напівпрозору панель на <paramref name="owner"/>, обмежуючи до неї доступ
        /// </summary>
        /// <param name="owner"><see cref="Control"/> на який буде накладена ProgressPanel</param>
        /// <param name="windowOptions">Опції вигляду ProgressPanel</param>
        /// <returns>Повертає <see cref="IOverlaySplashScreenHandle"/> з допомогою якого можна керувати ProgressPanel</returns>
        IOverlaySplashScreenHandle ShowProgressPanel(Control owner, OverlayWindowOptions windowOptions = null)
        {
            if (windowOptions == null) windowOptions = new OverlayWindowOptions(backColor: Color.Black, customPainter: new MyCustomOverlayPainter(), disableInput: true);
            IOverlaySplashScreenHandle _handle = null;
            try
            {
                _handle = SplashScreenManager.ShowOverlayForm(owner, windowOptions);
            }
            catch
            {
            }
            return _handle;
        }
        #endregion

        #region ₴( Сюди автоматично додаються нові методи )₴



        #endregion




        #region <{ GPT REF }>

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var handler = ShowProgressPanel(CurrentPanel);

            label22.Text = "";
            GptAPI.GPTResponseHandler += Label22_GPTResponseHandler;
            GptAPI.GPTErrorHandler += Label22_GPTErrorHandler;
            Task.Run(() => GptAPI.GetResponse(new string[] { "table", "pillow" }, GptPurpose.FlashCards, handler));
        }

        void Label22_GPTResponseHandler(string response, IOverlaySplashScreenHandle handler)
        {
            label22.Text = response;
            handler.Close();
        }

        void Label22_GPTErrorHandler(string response, IOverlaySplashScreenHandle handler)
        {
            label22.Text = response;
            handler.Close();
        }

        #endregion







        //TODOTODO 
        // - додати кнопку зі справкою щодо:
        //      - суть "Вивчення" слів у відповідному розділі
        // - додати вкладку "Мої словники"
        //      - можливість створювати власні словники, керувати ними та їх вмістом
        //      -  
    }
}
