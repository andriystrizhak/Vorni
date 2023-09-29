namespace EWL
{
    partial class SetUpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetUpForm));
            bottomPanel = new Panel();
            previousButton = new Button();
            continueButton = new Button();
            label3 = new Label();
            topPanel = new Panel();
            closeButton = new Button();
            bannerPanel = new Panel();
            panel1 = new Panel();
            label7 = new Label();
            label8 = new Label();
            label6 = new Label();
            label1 = new Label();
            label5 = new Label();
            panel2 = new Panel();
            sourceTypeGroupBox = new GroupBox();
            radioButtonBD = new RadioButton();
            radioButtonTF = new RadioButton();
            label2 = new Label();
            label4 = new Label();
            panel4 = new Panel();
            textFileTypeGroupBox = new GroupBox();
            radioButtonNewFT = new RadioButton();
            radioButtonOldFT = new RadioButton();
            label10 = new Label();
            panel3 = new Panel();
            BDActionGroupBox = new GroupBox();
            radioButtonAddNewW = new RadioButton();
            radioButtonLearnAvaliableW = new RadioButton();
            label11 = new Label();
            label12 = new Label();
            panel5 = new Panel();
            CancelPrevButton = new Button();
            AddWButton = new Button();
            label16 = new Label();
            UaTextBox = new TextBox();
            label15 = new Label();
            EngTextBox = new TextBox();
            label13 = new Label();
            label14 = new Label();
            bottomPanel.SuspendLayout();
            topPanel.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            sourceTypeGroupBox.SuspendLayout();
            panel4.SuspendLayout();
            textFileTypeGroupBox.SuspendLayout();
            panel3.SuspendLayout();
            BDActionGroupBox.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // bottomPanel
            // 
            bottomPanel.BackColor = Color.FromArgb(65, 65, 65);
            bottomPanel.BorderStyle = BorderStyle.FixedSingle;
            bottomPanel.Controls.Add(previousButton);
            bottomPanel.Controls.Add(continueButton);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new Point(0, 367);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Size = new Size(530, 59);
            bottomPanel.TabIndex = 8;
            // 
            // previousButton
            // 
            previousButton.BackColor = SystemColors.WindowFrame;
            previousButton.Cursor = Cursors.Hand;
            previousButton.Enabled = false;
            previousButton.FlatAppearance.BorderColor = Color.Gray;
            previousButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            previousButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            previousButton.FlatStyle = FlatStyle.Flat;
            previousButton.Font = new Font("Roboto Condensed", 9F, FontStyle.Bold, GraphicsUnit.Point);
            previousButton.ForeColor = Color.White;
            previousButton.Location = new Point(303, 14);
            previousButton.Name = "previousButton";
            previousButton.Size = new Size(94, 29);
            previousButton.TabIndex = 1;
            previousButton.Text = "Назад";
            previousButton.UseVisualStyleBackColor = false;
            previousButton.Click += PreviousButton_Click;
            // 
            // continueButton
            // 
            continueButton.BackColor = SystemColors.WindowFrame;
            continueButton.Cursor = Cursors.Hand;
            continueButton.FlatAppearance.BorderColor = Color.Gray;
            continueButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            continueButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            continueButton.FlatStyle = FlatStyle.Flat;
            continueButton.Font = new Font("Roboto Condensed", 9F, FontStyle.Bold, GraphicsUnit.Point);
            continueButton.ForeColor = Color.White;
            continueButton.Location = new Point(412, 14);
            continueButton.Name = "continueButton";
            continueButton.Size = new Size(94, 29);
            continueButton.TabIndex = 0;
            continueButton.Text = "Продовжити";
            continueButton.UseVisualStyleBackColor = false;
            continueButton.Click += ContinueButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(5, 7);
            label3.Name = "label3";
            label3.Size = new Size(177, 15);
            label3.TabIndex = 10;
            label3.Text = "Налаштування роботи додатку";
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(65, 65, 65);
            topPanel.BorderStyle = BorderStyle.FixedSingle;
            topPanel.Controls.Add(label3);
            topPanel.Cursor = Cursors.SizeAll;
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(530, 31);
            topPanel.TabIndex = 7;
            topPanel.MouseDown += TopPanel_MouseDown;
            topPanel.MouseMove += TopPanel_MouseMove;
            // 
            // closeButton
            // 
            closeButton.BackColor = Color.FromArgb(65, 65, 65);
            closeButton.BackgroundImageLayout = ImageLayout.None;
            closeButton.Cursor = Cursors.Hand;
            closeButton.FlatAppearance.BorderColor = Color.DimGray;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatAppearance.MouseDownBackColor = Color.Brown;
            closeButton.FlatAppearance.MouseOverBackColor = Color.Red;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Nirmala UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            closeButton.ForeColor = Color.White;
            closeButton.Location = new Point(480, 2);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(48, 27);
            closeButton.TabIndex = 2;
            closeButton.TabStop = false;
            closeButton.Text = "x";
            closeButton.TextAlign = ContentAlignment.TopCenter;
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += CloseButton_Click;
            // 
            // bannerPanel
            // 
            bannerPanel.BackgroundImage = (Image)resources.GetObject("bannerPanel.BackgroundImage");
            bannerPanel.BackgroundImageLayout = ImageLayout.Zoom;
            bannerPanel.BorderStyle = BorderStyle.FixedSingle;
            bannerPanel.Location = new Point(0, 31);
            bannerPanel.Name = "bannerPanel";
            bannerPanel.Size = new Size(183, 336);
            bannerPanel.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label5);
            panel1.ImeMode = ImeMode.Hangul;
            panel1.Location = new Point(179, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(351, 336);
            panel1.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Font = new Font("Roboto Condensed", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(104, 176);
            label7.Name = "label7";
            label7.Size = new Size(152, 20);
            label7.TabIndex = 5;
            label7.Text = "Що цей додаток може:";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.FlatStyle = FlatStyle.Flat;
            label8.Font = new Font("Roboto Condensed", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(44, 199);
            label8.Margin = new Padding(5);
            label8.Name = "label8";
            label8.Size = new Size(263, 83);
            label8.TabIndex = 6;
            label8.Text = "- Обирати джерело слів для вивчення\r\n(перемикати моди)      \r\n- Додавати нові слова для вивчення\r\n- Відслідковувати статистику навчання";
            label8.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Roboto Condensed", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(44, 81);
            label6.Name = "label6";
            label6.Size = new Size(140, 18);
            label6.TabIndex = 4;
            label6.Text = "English Words Learner";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Roboto Condensed", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(45, 74);
            label1.Name = "label1";
            label1.Size = new Size(265, 69);
            label1.TabIndex = 3;
            label1.Text = "English Words Learner  - спеціалізований додаток для допомоги у вивченні англійських слів методом флеш-карток";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(123, 42);
            label5.Name = "label5";
            label5.Size = new Size(112, 25);
            label5.TabIndex = 1;
            label5.Text = "Вітаю в EWL!";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(sourceTypeGroupBox);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label4);
            panel2.ImeMode = ImeMode.Hangul;
            panel2.Location = new Point(179, 31);
            panel2.Name = "panel2";
            panel2.Size = new Size(351, 336);
            panel2.TabIndex = 17;
            // 
            // sourceTypeGroupBox
            // 
            sourceTypeGroupBox.Controls.Add(radioButtonBD);
            sourceTypeGroupBox.Controls.Add(radioButtonTF);
            sourceTypeGroupBox.FlatStyle = FlatStyle.Flat;
            sourceTypeGroupBox.Font = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            sourceTypeGroupBox.ForeColor = Color.White;
            sourceTypeGroupBox.Location = new Point(57, 106);
            sourceTypeGroupBox.Name = "sourceTypeGroupBox";
            sourceTypeGroupBox.Size = new Size(240, 112);
            sourceTypeGroupBox.TabIndex = 7;
            sourceTypeGroupBox.TabStop = false;
            sourceTypeGroupBox.Text = "Вивчати слова з";
            sourceTypeGroupBox.Enter += SourceTypeGroupBox_Enter;
            // 
            // radioButtonBD
            // 
            radioButtonBD.AutoSize = true;
            radioButtonBD.Cursor = Cursors.Hand;
            radioButtonBD.Font = new Font("Roboto Condensed", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButtonBD.ForeColor = Color.White;
            radioButtonBD.Location = new Point(17, 40);
            radioButtonBD.Name = "radioButtonBD";
            radioButtonBD.Size = new Size(129, 22);
            radioButtonBD.TabIndex = 5;
            radioButtonBD.TabStop = true;
            radioButtonBD.Text = "Бази Даних (БД)";
            radioButtonBD.UseVisualStyleBackColor = true;
            // 
            // radioButtonTF
            // 
            radioButtonTF.AutoSize = true;
            radioButtonTF.Cursor = Cursors.Hand;
            radioButtonTF.Font = new Font("Roboto Condensed", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButtonTF.ForeColor = Color.White;
            radioButtonTF.Location = new Point(17, 72);
            radioButtonTF.Name = "radioButtonTF";
            radioButtonTF.Size = new Size(171, 22);
            radioButtonTF.TabIndex = 6;
            radioButtonTF.TabStop = true;
            radioButtonTF.Text = "Текстових Файлів (ТФ)";
            radioButtonTF.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto Condensed", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(62, 293);
            label2.Name = "label2";
            label2.Size = new Size(214, 18);
            label2.TabIndex = 3;
            label2.Text = "Використовувати словники типу";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(62, 50);
            label4.Name = "label4";
            label4.Size = new Size(231, 25);
            label4.TabIndex = 1;
            label4.Text = "Налаштуй роботу додатку";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(textFileTypeGroupBox);
            panel4.Controls.Add(label10);
            panel4.ImeMode = ImeMode.Hangul;
            panel4.Location = new Point(179, 31);
            panel4.Name = "panel4";
            panel4.Size = new Size(351, 336);
            panel4.TabIndex = 18;
            // 
            // textFileTypeGroupBox
            // 
            textFileTypeGroupBox.Controls.Add(radioButtonNewFT);
            textFileTypeGroupBox.Controls.Add(radioButtonOldFT);
            textFileTypeGroupBox.FlatStyle = FlatStyle.Flat;
            textFileTypeGroupBox.Font = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textFileTypeGroupBox.ForeColor = Color.White;
            textFileTypeGroupBox.Location = new Point(57, 106);
            textFileTypeGroupBox.Name = "textFileTypeGroupBox";
            textFileTypeGroupBox.Size = new Size(240, 112);
            textFileTypeGroupBox.TabIndex = 7;
            textFileTypeGroupBox.TabStop = false;
            textFileTypeGroupBox.Text = "Файли типу";
            textFileTypeGroupBox.Enter += SourceTypeGroupBox_Enter;
            // 
            // radioButtonNewFT
            // 
            radioButtonNewFT.AutoSize = true;
            radioButtonNewFT.Cursor = Cursors.Hand;
            radioButtonNewFT.Font = new Font("Roboto Condensed", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButtonNewFT.ForeColor = Color.White;
            radioButtonNewFT.Location = new Point(17, 40);
            radioButtonNewFT.Name = "radioButtonNewFT";
            radioButtonNewFT.Size = new Size(99, 22);
            radioButtonNewFT.TabIndex = 5;
            radioButtonNewFT.TabStop = true;
            radioButtonNewFT.Text = "Новий (ЄВІ)";
            radioButtonNewFT.UseVisualStyleBackColor = true;
            // 
            // radioButtonOldFT
            // 
            radioButtonOldFT.AutoSize = true;
            radioButtonOldFT.Cursor = Cursors.Hand;
            radioButtonOldFT.Font = new Font("Roboto Condensed", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButtonOldFT.ForeColor = Color.White;
            radioButtonOldFT.Location = new Point(17, 72);
            radioButtonOldFT.Name = "radioButtonOldFT";
            radioButtonOldFT.Size = new Size(218, 22);
            radioButtonOldFT.TabIndex = 6;
            radioButtonOldFT.TabStop = true;
            radioButtonOldFT.Text = "Старий (фільми, статті, відео)";
            radioButtonOldFT.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BorderStyle = BorderStyle.FixedSingle;
            label10.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(107, 50);
            label10.Name = "label10";
            label10.Size = new Size(144, 25);
            label10.TabIndex = 1;
            label10.Text = "Текстові файли";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(BDActionGroupBox);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label12);
            panel3.ImeMode = ImeMode.Hangul;
            panel3.Location = new Point(179, 31);
            panel3.Name = "panel3";
            panel3.Size = new Size(351, 336);
            panel3.TabIndex = 19;
            // 
            // BDActionGroupBox
            // 
            BDActionGroupBox.Controls.Add(radioButtonAddNewW);
            BDActionGroupBox.Controls.Add(radioButtonLearnAvaliableW);
            BDActionGroupBox.FlatStyle = FlatStyle.Flat;
            BDActionGroupBox.Font = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BDActionGroupBox.ForeColor = Color.White;
            BDActionGroupBox.Location = new Point(57, 106);
            BDActionGroupBox.Name = "BDActionGroupBox";
            BDActionGroupBox.Size = new Size(240, 112);
            BDActionGroupBox.TabIndex = 7;
            BDActionGroupBox.TabStop = false;
            BDActionGroupBox.Text = "Що б ти хотів зробити?";
            BDActionGroupBox.Enter += SourceTypeGroupBox_Enter;
            // 
            // radioButtonAddNewW
            // 
            radioButtonAddNewW.AutoSize = true;
            radioButtonAddNewW.Cursor = Cursors.Hand;
            radioButtonAddNewW.Font = new Font("Roboto Condensed", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButtonAddNewW.ForeColor = Color.White;
            radioButtonAddNewW.Location = new Point(17, 40);
            radioButtonAddNewW.Name = "radioButtonAddNewW";
            radioButtonAddNewW.Size = new Size(139, 22);
            radioButtonAddNewW.TabIndex = 5;
            radioButtonAddNewW.TabStop = true;
            radioButtonAddNewW.Text = "Додати нові слова";
            radioButtonAddNewW.UseVisualStyleBackColor = true;
            radioButtonAddNewW.CheckedChanged += RadioButtonAddNewW_CheckedChanged;
            // 
            // radioButtonLearnAvaliableW
            // 
            radioButtonLearnAvaliableW.AutoSize = true;
            radioButtonLearnAvaliableW.Cursor = Cursors.Hand;
            radioButtonLearnAvaliableW.Font = new Font("Roboto Condensed", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButtonLearnAvaliableW.ForeColor = Color.White;
            radioButtonLearnAvaliableW.Location = new Point(17, 72);
            radioButtonLearnAvaliableW.Name = "radioButtonLearnAvaliableW";
            radioButtonLearnAvaliableW.Size = new Size(120, 22);
            radioButtonLearnAvaliableW.TabIndex = 6;
            radioButtonLearnAvaliableW.TabStop = true;
            radioButtonLearnAvaliableW.Text = "Вивчати наявні";
            radioButtonLearnAvaliableW.UseVisualStyleBackColor = true;
            radioButtonLearnAvaliableW.CheckedChanged += RadioButtonLearnAvaliableW_CheckedChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Roboto Condensed", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.White;
            label11.Location = new Point(62, 293);
            label11.Name = "label11";
            label11.Size = new Size(214, 18);
            label11.TabIndex = 3;
            label11.Text = "Використовувати словники типу";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            label11.Visible = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BorderStyle = BorderStyle.FixedSingle;
            label12.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(123, 50);
            label12.Name = "label12";
            label12.Size = new Size(105, 25);
            label12.TabIndex = 1;
            label12.Text = "База даних";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(CancelPrevButton);
            panel5.Controls.Add(AddWButton);
            panel5.Controls.Add(label16);
            panel5.Controls.Add(UaTextBox);
            panel5.Controls.Add(label15);
            panel5.Controls.Add(EngTextBox);
            panel5.Controls.Add(label13);
            panel5.Controls.Add(label14);
            panel5.ImeMode = ImeMode.Hangul;
            panel5.Location = new Point(179, 31);
            panel5.Name = "panel5";
            panel5.Size = new Size(351, 336);
            panel5.TabIndex = 20;
            // 
            // CancelPrevButton
            // 
            CancelPrevButton.BackColor = SystemColors.WindowFrame;
            CancelPrevButton.Cursor = Cursors.Hand;
            CancelPrevButton.Enabled = false;
            CancelPrevButton.FlatAppearance.BorderColor = Color.Gray;
            CancelPrevButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            CancelPrevButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            CancelPrevButton.FlatStyle = FlatStyle.Flat;
            CancelPrevButton.Font = new Font("Roboto Condensed", 9F, FontStyle.Bold, GraphicsUnit.Point);
            CancelPrevButton.ForeColor = Color.White;
            CancelPrevButton.Location = new Point(81, 279);
            CancelPrevButton.Name = "CancelPrevButton";
            CancelPrevButton.Size = new Size(80, 38);
            CancelPrevButton.TabIndex = 13;
            CancelPrevButton.Text = "Скасувати попереднє";
            CancelPrevButton.UseVisualStyleBackColor = false;
            CancelPrevButton.Click += CancelPrevButton_Click;
            // 
            // AddWButton
            // 
            AddWButton.BackColor = SystemColors.WindowFrame;
            AddWButton.Cursor = Cursors.Hand;
            AddWButton.Enabled = false;
            AddWButton.FlatAppearance.BorderColor = Color.Gray;
            AddWButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            AddWButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            AddWButton.FlatStyle = FlatStyle.Flat;
            AddWButton.Font = new Font("Roboto Condensed", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AddWButton.ForeColor = Color.White;
            AddWButton.Location = new Point(196, 279);
            AddWButton.Name = "AddWButton";
            AddWButton.Size = new Size(80, 38);
            AddWButton.TabIndex = 12;
            AddWButton.Text = "Додати \r\nслово";
            AddWButton.UseVisualStyleBackColor = false;
            AddWButton.Click += AddWButton_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Roboto Condensed", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label16.ForeColor = Color.White;
            label16.Location = new Point(68, 251);
            label16.Name = "label16";
            label16.Size = new Size(147, 15);
            label16.TabIndex = 11;
            label16.Text = "*кожен в окремому рядку";
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UaTextBox
            // 
            UaTextBox.AcceptsReturn = true;
            UaTextBox.BackColor = Color.FromArgb(90, 90, 90);
            UaTextBox.Cursor = Cursors.IBeam;
            UaTextBox.Font = new Font("Roboto Condensed", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            UaTextBox.ForeColor = Color.White;
            UaTextBox.Location = new Point(64, 163);
            UaTextBox.Multiline = true;
            UaTextBox.Name = "UaTextBox";
            UaTextBox.ScrollBars = ScrollBars.Vertical;
            UaTextBox.Size = new Size(227, 86);
            UaTextBox.TabIndex = 10;
            UaTextBox.TabStop = false;
            UaTextBox.TextChanged += EngUaTextBox_TextChanged;
            UaTextBox.KeyPress += UaTextBox_KeyPress;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Roboto Condensed", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = Color.White;
            label15.Location = new Point(105, 144);
            label15.Name = "label15";
            label15.Size = new Size(148, 18);
            label15.TabIndex = 9;
            label15.Text = "Введи його переклади";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EngTextBox
            // 
            EngTextBox.BackColor = Color.FromArgb(90, 90, 90);
            EngTextBox.Cursor = Cursors.IBeam;
            EngTextBox.Font = new Font("Roboto Condensed", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            EngTextBox.ForeColor = Color.White;
            EngTextBox.Location = new Point(64, 98);
            EngTextBox.Name = "EngTextBox";
            EngTextBox.Size = new Size(227, 26);
            EngTextBox.TabIndex = 8;
            EngTextBox.TabStop = false;
            EngTextBox.TextAlign = HorizontalAlignment.Center;
            EngTextBox.TextChanged += EngUaTextBox_TextChanged;
            EngTextBox.KeyPress += EngTextBox_KeyPress;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Roboto Condensed", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.White;
            label13.Location = new Point(99, 79);
            label13.Name = "label13";
            label13.Size = new Size(157, 18);
            label13.TabIndex = 3;
            label13.Text = "Введи англійське слово";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BorderStyle = BorderStyle.FixedSingle;
            label14.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label14.ForeColor = Color.White;
            label14.Location = new Point(79, 37);
            label14.Name = "label14";
            label14.Size = new Size(195, 25);
            label14.TabIndex = 1;
            label14.Text = "Додавання нових слів";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SetUpForm
            // 
            AcceptButton = continueButton;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(50, 50, 50);
            BackgroundImageLayout = ImageLayout.None;
            CancelButton = previousButton;
            ClientSize = new Size(530, 426);
            Controls.Add(bannerPanel);
            Controls.Add(closeButton);
            Controls.Add(topPanel);
            Controls.Add(bottomPanel);
            Controls.Add(panel1);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SetUpForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SetUpForm";
            Load += SetUpForm_Load;
            bottomPanel.ResumeLayout(false);
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            sourceTypeGroupBox.ResumeLayout(false);
            sourceTypeGroupBox.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            textFileTypeGroupBox.ResumeLayout(false);
            textFileTypeGroupBox.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            BDActionGroupBox.ResumeLayout(false);
            BDActionGroupBox.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel bottomPanel;
        private Button continueButton;
        private Button previousButton;
        private Label label3;
        private Panel topPanel;
        private Button closeButton;
        private Panel bannerPanel;
        private Panel panel1;
        private Label label7;
        private Label label8;
        private Label label6;
        private Label label1;
        private Label label5;
        private Panel panel2;
        private GroupBox sourceTypeGroupBox;
        private RadioButton radioButtonBD;
        private RadioButton radioButtonTF;
        private Label label2;
        private Label label4;
        private Panel panel4;
        private GroupBox textFileTypeGroupBox;
        private RadioButton radioButtonNewFT;
        private RadioButton radioButtonOldFT;
        private Label label10;
        private Panel panel3;
        private GroupBox BDActionGroupBox;
        private RadioButton radioButtonAddNewW;
        private RadioButton radioButtonLearnAvaliableW;
        private Label label11;
        private Label label12;
        private Panel panel5;
        private Label label13;
        private Label label14;
        private TextBox EngTextBox;
        private TextBox UaTextBox;
        private Label label15;
        private Label label16;
        private Button AddWButton;
        private Button CancelPrevButton;
    }
}