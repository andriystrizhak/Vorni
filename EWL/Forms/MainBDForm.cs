using Guna.UI2.WinForms;

using System.Data;

using EWL.EF_SQLite;
using EWL.NOT_Forms;
using DevExpress.XtraSplashScreen;
using Eng_Flash_Cards_Learner.Forms.UserControls;
using Eng_Flash_Cards_Learner.Forms.ChildForms;
using Eng_Flash_Cards_Learner.NOT_Forms;
using static EWL.NOT_Forms.Txt_FileHandler;

using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using DevExpress.XtraPrinting.Native;
using System.Globalization;
using System.Net.Http.Headers;

using OpenAI.Managers;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;
using OpenAI;
using OpenAI.Interfaces;



namespace EWL
{
    public partial class MainForm : Form
    {
        //Pay attention on:
        //- "//CHANGE"
        //- "//TODO"
        //- "//CHECK"

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
        List<Word> words { get; set; } = new();
        /// <summary>
        /// Індекс поточного слова для вивчення зі списку <see cref="words"/>
        /// </summary>
        int wordIndex { get; set; } = 0;
        /// <summary>
        /// Оцінки поточних слів
        /// </summary>
        int[] wordRatings { get; set; } = { 0, 0, 0, 0, 0, 0 }; //CHANGE

        List<Category> categories = null!; //TODO
        int curentCategoryID;             //TODO

        public MainForm()
        {
            KeyDown += Enter_KeyDown!;
            KeyDown += Escape_KeyDown!;
            KeyDown += RateW_KeyDown!;
            KeyDown += CtrlS_KeyDown!;
            KeyDown += CtrlZ_KeyDown!;

            InitializeComponent();
            ShowPanel(MenuPanel);


            //label22.Text = callOpenAI(20, "Розкажи коротко, хто такий Ілон Маск?", "text-ada-001", 0.7, 1, 0, 0, this);


            SetCategoriesList();
        }






        static async Task API(MainForm form)
        {
            string apiKey = "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";
            string endpoint = "https://api.openai.com/v1/chat/completions";

            // Зразок тексту для передачі
            string prompt = "Розкажи коротко, хто такий Ілон Маск?";

            using (HttpClient client = new HttpClient())
            {
                // Додайте ваш ключ API до заголовків
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                // Створіть об'єкт, що містить текст, який ви хочете завершити
                var requestData = new
                {
                    prompt,
                    max_tokens = 20,  // Максимальна кількість токенів у відповіді
                    temperature = 0.7
                };

                // Відправте POST-запит до OpenAI API
                HttpResponseMessage response = await client.PostAsJsonAsync(endpoint, requestData);

                if (response.IsSuccessStatusCode)
                {
                    // Отримайте відповідь API у вигляді рядка JSON
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Розпакувати JSON в динамічний об'єкт
                    dynamic result = JsonConvert.DeserializeObject(jsonResponse);

                    // Вивести текст завершеного тексту
                    form.label22.Text = result.choices[0].text;
                }
                else
                {
                    form.label22.Text = $"Помилка: {response.StatusCode}";
                }
            }
        }


        private static string callOpenAI(int tokens, string input, string engine,
          double temperature, int topP, int frequencyPenalty, int presencePenalty, MainForm form)
        {
            var openAiKey = "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";
            var apiCall = "https://api.openai.com/v1/engines/" + engine + "/completions";
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), apiCall))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + openAiKey);
                        request.Content = new StringContent("{\n  \"prompt\": \"" + input + "\",\n  \"temperature\": " +
                                                            temperature.ToString(CultureInfo.InvariantCulture) + ",\n  \"max_tokens\": " + tokens + ",\n  \"top_p\": " + topP +
                                                            ",\n  \"frequency_penalty\": " + frequencyPenalty + ",\n  \"presence_penalty\": " + presencePenalty + "\n}");
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        var response = httpClient.SendAsync(request).Result;
                        var json = response.Content.ReadAsStringAsync().Result;
                        dynamic dynObj = JsonConvert.DeserializeObject(json);
                        if (dynObj != null)
                        {
                            return dynObj.choices[0].text.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                form.label22.Text = ex.Message;
            }
            return null;
        }


        //TODO CATEGORY - Імплементувати
        #region [ Category ]

        void SetCategoriesList()
        {
            categories = SQLs.Get_Categories();
            //TODO CATEGORY
        }

        #endregion

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

        #region [[ Головне меню ]]

        #region [ Вивчати слова ]

        //TODO CATEGORY - Додати проміжну панель чи кнопку для перемикання категорії для вивчення
        //TODO - Додати до проміжної панелі вибір СПОСОБУ вивченн (картки чи тести)

        private void LearnWButton_Click(object sender, EventArgs e)
        {
            //TODO - тут буде визначатися який спосіб вивчення розпочати

            ShowPanel(LearningPanel);
            words = SQLs
                .Get_Words_FromCategory(SQLs.Get_CurrentCategory(), SQLs.Get_NumberOfWordsToLearn())
                .Select(w => w.Item1)
                .ToList();
            //SeeEngWord();
        }

        /// <summary>
        /// Підготовлює й показує <see cref="LearningEngPanel"/>
        /// </summary>
        private void SeeEngWord()
        {
            words = words.OrderBy(w => w.Rating).ToList();

            EngWLabel1.Text = words[wordIndex].EngWord;
            EngWLabel2.Text = words[wordIndex].EngWord;

            ShowPanel(LearningEngPanel);
            SeeTransButton.Focus();
        }

        #region ( Властивості контролів LearningWPanel )

        private void SeeTransButton_Click(object sender, EventArgs e)
        {
            TranslationLabel.Text = words[wordIndex].UaTranslation;
            ShowPanel(LearningUaPanel);

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
                SeeEngWord();
            else
            {
                wordIndex = 0;
                OutputLearningStatistic();
                ShowPanel(LearningStatPanel);
                RetryButton.Focus();
            }
        }
        #endregion

        #region ( Властивості контролів LearningStatPanel )

        void OutputLearningStatistic()
        {
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
            => SeeEngWord();

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
        /// Вказує на те чи курсор з файлом знаходиться над <see cref="DragAndDropPanel1"/>
        /// </summary>
        bool isMouseOverDDP { get; set; } = false;
        /// <summary>
        /// Вказує на те чи якісь файли вже поміщені в <see cref="DragAndDropPanel1"/>
        /// </summary>
        bool fileIsAdded { get => TxtFilesPathsTextBox.Text != ""; } //AddWButton3.Enabled; }
        /// <summary>
        /// Список доданих в <see cref="DragAndDropPanel1"/> файлів
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
        /// Скидає <see cref="AddingWPanel3"/> до початкового стану
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

        //ADD TO - універсальної кнопки
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
            var handler = ShowProgressPanel(CurrentPanel);
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
            if (e.KeyCode == Keys.Escape && CurrentPanel != MenuPanel)
                GoBackButton_Click(sender, e);
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
            foreach (Control panel in this.Controls)
                if (panel is Panel && panel != TopPanel
                    && panel != SidebarPanel)
                {
                    panel.Enabled = false;
                    panel.Visible = false;
                }

            CurrentPanel = panelToShow;
            panelToShow.Enabled = true;
            panelToShow.Visible = true;
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

        private void This_Paint(object sender, PaintEventArgs e)
        {
            var pen = new Pen(Color.White, 20);
            //var bound = this.Bounds;
            //bound.X -= 10;
            //bound.Y -= 10;
            //e.Graphics.DrawRectangle(pen, 1, 1, 500, 500);

            Rectangle borderRectangle = this.ClientRectangle;
            borderRectangle.Inflate(-1, -1);

            ControlPaint.DrawBorder(e.Graphics, borderRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            label22.Text = "";
            Task.Run(() => GptAPI.PIPI(label22));
        }
        #endregion

        #region ₴( Сюди автоматично додаються нові методи )₴



        #endregion



        //TODOTODO 
        // - додати кнопку зі справкою щодо:
        //      - суть "Вивчення" слів у відповідному розділі
        // - додати вкладку "Мої словники"
        //      - можливість створювати власні словники, керувати ними та їх вмістом
        //      -  
    }
}
