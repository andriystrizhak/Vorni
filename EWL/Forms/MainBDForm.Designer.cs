using Tulpep.NotificationWindow;

namespace EWL
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            CloseButton = new Button();
            TopPanel = new Panel();
            MinimizeButton = new Button();
            TitleIcoPictureBox = new PictureBox();
            TitleLabel = new Label();
            fullScreenImageList = new ImageList(components);
            MenuPanel = new Panel();
            SettingButton = new Button();
            FullScreenButton = new Button();
            LearnWButton = new Button();
            SeeAddingWPanelButton = new Button();
            SeeStatButton = new Button();
            EWLPictureBox = new PictureBox();
            LearningUaPanel = new Panel();
            GoBackButton2 = new Button();
            TranslationLabel = new Label();
            RateTableLayoutPanel = new TableLayoutPanel();
            Button5 = new Button();
            Button4 = new Button();
            Button3 = new Button();
            Button2 = new Button();
            Button1 = new Button();
            EngWLabel2 = new Label();
            LearningEngPanel = new Panel();
            EngWLabel1 = new Label();
            GoBackButton1 = new Button();
            SeeTransButton = new Button();
            LearningStatPanel = new Panel();
            LearningRatingLabel = new Label();
            RetryButton = new Button();
            StatLabel1 = new Label();
            GoMenuButton = new Button();
            LearningStatLabel = new Label();
            StatPanel = new Panel();
            GoBackButton3 = new Button();
            StatHeaderLabel = new Label();
            StatLabel = new Label();
            AddingWPanel1 = new Panel();
            CancelPrevButton1 = new Button();
            AddWButton1 = new Button();
            AddWLabel4 = new Label();
            AddUaTTextBox = new TextBox();
            AddWLabel3 = new Label();
            AddEngWTextBox = new TextBox();
            AddWLabel2 = new Label();
            GoBackButton4 = new Button();
            AddWLabel1 = new Label();
            SettingPanel = new Panel();
            label1 = new Label();
            WSourceComboBox = new ComboBox();
            NumberOfWordsNumericUpDown = new NumericUpDown();
            DefaultSettingsButton = new Button();
            SaveSettingsButton = new Button();
            label3 = new Label();
            GoBackButton5 = new Button();
            label4 = new Label();
            AddingWPanel3 = new Panel();
            DragAndDropPanel = new Panel();
            label13 = new Label();
            label6 = new Label();
            ChooseFileButton = new Button();
            label12 = new Label();
            TxtFilePathTextBox = new TextBox();
            SpecialFormatInfoBox2 = new PictureBox();
            CancelAddingButton = new Button();
            AddWButton3 = new Button();
            GoBackButton6 = new Button();
            label7 = new Label();
            AddingWPanel2 = new Panel();
            GoBackButton7 = new Button();
            SpecialFormatInfoBox1 = new PictureBox();
            CancelPrevButton2 = new Button();
            AddWButton2 = new Button();
            EngUaStringTextBox = new TextBox();
            label2 = new Label();
            label5 = new Label();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            WordID = new DataGridViewTextBoxColumn();
            EngWord = new DataGridViewTextBoxColumn();
            UaTranslation = new DataGridViewTextBoxColumn();
            Rating = new DataGridViewTextBoxColumn();
            button6 = new Button();
            button7 = new Button();
            label8 = new Label();
            textBox1 = new TextBox();
            label9 = new Label();
            textBox2 = new TextBox();
            label10 = new Label();
            button8 = new Button();
            label11 = new Label();
            SpecialFormatLineTip = new ToolTip(components);
            WrongFileFormatPopup = new PopupNotifier();
            TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TitleIcoPictureBox).BeginInit();
            MenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)EWLPictureBox).BeginInit();
            LearningUaPanel.SuspendLayout();
            RateTableLayoutPanel.SuspendLayout();
            LearningEngPanel.SuspendLayout();
            LearningStatPanel.SuspendLayout();
            StatPanel.SuspendLayout();
            AddingWPanel1.SuspendLayout();
            SettingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumberOfWordsNumericUpDown).BeginInit();
            AddingWPanel3.SuspendLayout();
            DragAndDropPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpecialFormatInfoBox2).BeginInit();
            AddingWPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpecialFormatInfoBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.FromArgb(65, 65, 65);
            CloseButton.BackgroundImageLayout = ImageLayout.None;
            CloseButton.Cursor = Cursors.Hand;
            CloseButton.FlatAppearance.BorderColor = Color.DimGray;
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.FlatAppearance.MouseDownBackColor = Color.Brown;
            CloseButton.FlatAppearance.MouseOverBackColor = Color.Red;
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.Font = new Font("Nirmala UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            CloseButton.ForeColor = Color.White;
            CloseButton.Location = new Point(927, 1);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(48, 27);
            CloseButton.TabIndex = 2;
            CloseButton.TabStop = false;
            CloseButton.Text = "x";
            CloseButton.TextAlign = ContentAlignment.TopCenter;
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += CloseButton_Click;
            // 
            // TopPanel
            // 
            TopPanel.BackColor = Color.FromArgb(65, 65, 65);
            TopPanel.BorderStyle = BorderStyle.FixedSingle;
            TopPanel.Controls.Add(MinimizeButton);
            TopPanel.Controls.Add(TitleIcoPictureBox);
            TopPanel.Controls.Add(CloseButton);
            TopPanel.Controls.Add(TitleLabel);
            TopPanel.Cursor = Cursors.SizeAll;
            TopPanel.Location = new Point(0, -18);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new Size(978, 31);
            TopPanel.TabIndex = 0;
            TopPanel.MouseDown += TopPanel_MouseDown;
            TopPanel.MouseMove += TopPanel_MouseMove;
            // 
            // MinimizeButton
            // 
            MinimizeButton.BackColor = Color.FromArgb(65, 65, 65);
            MinimizeButton.BackgroundImageLayout = ImageLayout.None;
            MinimizeButton.Cursor = Cursors.Hand;
            MinimizeButton.FlatAppearance.BorderColor = Color.DimGray;
            MinimizeButton.FlatAppearance.BorderSize = 0;
            MinimizeButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(90, 90, 90);
            MinimizeButton.FlatAppearance.MouseOverBackColor = SystemColors.WindowFrame;
            MinimizeButton.FlatStyle = FlatStyle.Flat;
            MinimizeButton.Font = new Font("Nirmala UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            MinimizeButton.ForeColor = Color.White;
            MinimizeButton.Location = new Point(877, 1);
            MinimizeButton.Name = "MinimizeButton";
            MinimizeButton.Size = new Size(48, 27);
            MinimizeButton.TabIndex = 0;
            MinimizeButton.TabStop = false;
            MinimizeButton.Text = "–";
            MinimizeButton.TextAlign = ContentAlignment.TopCenter;
            MinimizeButton.UseVisualStyleBackColor = false;
            MinimizeButton.Click += MinimizeButton_Click;
            // 
            // TitleIcoPictureBox
            // 
            TitleIcoPictureBox.BackgroundImage = Eng_Flash_Cards_Learner.Resource1.Untitled_3_1;
            TitleIcoPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            TitleIcoPictureBox.Location = new Point(6, 5);
            TitleIcoPictureBox.Name = "TitleIcoPictureBox";
            TitleIcoPictureBox.Size = new Size(48, 21);
            TitleIcoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            TitleIcoPictureBox.TabIndex = 1;
            TitleIcoPictureBox.TabStop = false;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Segoe UI", 8.75F, FontStyle.Regular, GraphicsUnit.Point);
            TitleLabel.ForeColor = Color.White;
            TitleLabel.Location = new Point(58, 7);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(193, 15);
            TitleLabel.TabIndex = 3;
            TitleLabel.Text = "English Words Learner (flash-cards)";
            // 
            // fullScreenImageList
            // 
            fullScreenImageList.ColorDepth = ColorDepth.Depth32Bit;
            fullScreenImageList.ImageSize = new Size(16, 16);
            fullScreenImageList.TransparentColor = Color.Transparent;
            // 
            // MenuPanel
            // 
            MenuPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MenuPanel.BorderStyle = BorderStyle.FixedSingle;
            MenuPanel.Controls.Add(SettingButton);
            MenuPanel.Controls.Add(FullScreenButton);
            MenuPanel.Controls.Add(LearnWButton);
            MenuPanel.Controls.Add(SeeAddingWPanelButton);
            MenuPanel.Controls.Add(SeeStatButton);
            MenuPanel.Controls.Add(EWLPictureBox);
            MenuPanel.ImeMode = ImeMode.Hangul;
            MenuPanel.Location = new Point(0, 31);
            MenuPanel.Name = "MenuPanel";
            MenuPanel.Size = new Size(978, 519);
            MenuPanel.TabIndex = 9;
            // 
            // SettingButton
            // 
            SettingButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SettingButton.BackColor = SystemColors.WindowFrame;
            SettingButton.CausesValidation = false;
            SettingButton.Cursor = Cursors.Hand;
            SettingButton.FlatAppearance.BorderColor = Color.Gray;
            SettingButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            SettingButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            SettingButton.FlatStyle = FlatStyle.Flat;
            SettingButton.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            SettingButton.ForeColor = Color.White;
            SettingButton.Location = new Point(316, 335);
            SettingButton.Margin = new Padding(10, 10, 10, 100);
            SettingButton.MinimumSize = new Size(350, 50);
            SettingButton.Name = "SettingButton";
            SettingButton.Size = new Size(350, 50);
            SettingButton.TabIndex = 3;
            SettingButton.Text = "Налаштування";
            SettingButton.UseVisualStyleBackColor = false;
            SettingButton.Click += SettingButton_Click;
            // 
            // FullScreenButton
            // 
            FullScreenButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FullScreenButton.BackColor = Color.FromArgb(50, 50, 50);
            FullScreenButton.Cursor = Cursors.Hand;
            FullScreenButton.Enabled = false;
            FullScreenButton.FlatAppearance.BorderColor = Color.Gray;
            FullScreenButton.FlatAppearance.BorderSize = 0;
            FullScreenButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 50, 50);
            FullScreenButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            FullScreenButton.FlatStyle = FlatStyle.Flat;
            FullScreenButton.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            FullScreenButton.ForeColor = Color.White;
            FullScreenButton.ImageList = fullScreenImageList;
            FullScreenButton.Location = new Point(915, 1);
            FullScreenButton.Name = "FullScreenButton";
            FullScreenButton.Size = new Size(60, 60);
            FullScreenButton.TabIndex = 4;
            FullScreenButton.TabStop = false;
            FullScreenButton.UseVisualStyleBackColor = false;
            FullScreenButton.Visible = false;
            FullScreenButton.Click += FullScreenButton_Click;
            // 
            // LearnWButton
            // 
            LearnWButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LearnWButton.BackColor = SystemColors.WindowFrame;
            LearnWButton.CausesValidation = false;
            LearnWButton.Cursor = Cursors.Hand;
            LearnWButton.FlatAppearance.BorderColor = Color.Gray;
            LearnWButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            LearnWButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            LearnWButton.FlatStyle = FlatStyle.Flat;
            LearnWButton.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            LearnWButton.ForeColor = Color.White;
            LearnWButton.Location = new Point(316, 200);
            LearnWButton.Margin = new Padding(10, 10, 10, 100);
            LearnWButton.MinimumSize = new Size(350, 50);
            LearnWButton.Name = "LearnWButton";
            LearnWButton.Size = new Size(350, 50);
            LearnWButton.TabIndex = 1;
            LearnWButton.Text = "Вивчати слова";
            LearnWButton.UseVisualStyleBackColor = false;
            LearnWButton.Click += LearnWButton_Click;
            // 
            // SeeAddingWPanelButton
            // 
            SeeAddingWPanelButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SeeAddingWPanelButton.BackColor = SystemColors.WindowFrame;
            SeeAddingWPanelButton.CausesValidation = false;
            SeeAddingWPanelButton.Cursor = Cursors.Hand;
            SeeAddingWPanelButton.FlatAppearance.BorderColor = Color.Gray;
            SeeAddingWPanelButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            SeeAddingWPanelButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            SeeAddingWPanelButton.FlatStyle = FlatStyle.Flat;
            SeeAddingWPanelButton.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            SeeAddingWPanelButton.ForeColor = Color.White;
            SeeAddingWPanelButton.Location = new Point(316, 267);
            SeeAddingWPanelButton.Margin = new Padding(10, 10, 10, 100);
            SeeAddingWPanelButton.MinimumSize = new Size(350, 50);
            SeeAddingWPanelButton.Name = "SeeAddingWPanelButton";
            SeeAddingWPanelButton.Size = new Size(350, 50);
            SeeAddingWPanelButton.TabIndex = 2;
            SeeAddingWPanelButton.Text = "Додати слова";
            SeeAddingWPanelButton.UseVisualStyleBackColor = false;
            SeeAddingWPanelButton.Click += SeeAddingWPanelButton_Click;
            // 
            // SeeStatButton
            // 
            SeeStatButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SeeStatButton.BackColor = SystemColors.WindowFrame;
            SeeStatButton.CausesValidation = false;
            SeeStatButton.Cursor = Cursors.Hand;
            SeeStatButton.FlatAppearance.BorderColor = Color.Gray;
            SeeStatButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            SeeStatButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            SeeStatButton.FlatStyle = FlatStyle.Flat;
            SeeStatButton.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            SeeStatButton.ForeColor = Color.White;
            SeeStatButton.Location = new Point(316, 403);
            SeeStatButton.Margin = new Padding(10, 10, 10, 100);
            SeeStatButton.MinimumSize = new Size(350, 50);
            SeeStatButton.Name = "SeeStatButton";
            SeeStatButton.Size = new Size(350, 50);
            SeeStatButton.TabIndex = 4;
            SeeStatButton.Text = "Переглянути статистику";
            SeeStatButton.UseVisualStyleBackColor = false;
            SeeStatButton.Click += SeeStatButton_Click;
            // 
            // EWLPictureBox
            // 
            EWLPictureBox.BackgroundImage = Eng_Flash_Cards_Learner.Resource1.Logo11;
            EWLPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            EWLPictureBox.Location = new Point(190, 16);
            EWLPictureBox.MinimumSize = new Size(550, 100);
            EWLPictureBox.Name = "EWLPictureBox";
            EWLPictureBox.Size = new Size(586, 150);
            EWLPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            EWLPictureBox.TabIndex = 5;
            EWLPictureBox.TabStop = false;
            // 
            // LearningUaPanel
            // 
            LearningUaPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LearningUaPanel.BorderStyle = BorderStyle.FixedSingle;
            LearningUaPanel.Controls.Add(GoBackButton2);
            LearningUaPanel.Controls.Add(TranslationLabel);
            LearningUaPanel.Controls.Add(RateTableLayoutPanel);
            LearningUaPanel.Controls.Add(EngWLabel2);
            LearningUaPanel.ImeMode = ImeMode.Hangul;
            LearningUaPanel.Location = new Point(0, 31);
            LearningUaPanel.Name = "LearningUaPanel";
            LearningUaPanel.Size = new Size(978, 519);
            LearningUaPanel.TabIndex = 1;
            // 
            // GoBackButton2
            // 
            GoBackButton2.BackColor = Color.FromArgb(50, 50, 50);
            GoBackButton2.BackgroundImage = Eng_Flash_Cards_Learner.Resource1.icons8_налево_96;
            GoBackButton2.BackgroundImageLayout = ImageLayout.Zoom;
            GoBackButton2.Cursor = Cursors.Hand;
            GoBackButton2.FlatAppearance.BorderColor = Color.Gray;
            GoBackButton2.FlatAppearance.BorderSize = 0;
            GoBackButton2.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 50, 50);
            GoBackButton2.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            GoBackButton2.FlatStyle = FlatStyle.Flat;
            GoBackButton2.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            GoBackButton2.ForeColor = Color.White;
            GoBackButton2.Location = new Point(3, 3);
            GoBackButton2.Name = "GoBackButton2";
            GoBackButton2.Size = new Size(60, 60);
            GoBackButton2.TabIndex = 0;
            GoBackButton2.TabStop = false;
            GoBackButton2.UseVisualStyleBackColor = false;
            GoBackButton2.Click += GoBackButton_Click;
            // 
            // TranslationLabel
            // 
            TranslationLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TranslationLabel.BackColor = Color.FromArgb(60, 60, 60);
            TranslationLabel.BorderStyle = BorderStyle.FixedSingle;
            TranslationLabel.Font = new Font("Roboto Condensed", 18F, FontStyle.Bold, GraphicsUnit.Point);
            TranslationLabel.ForeColor = Color.White;
            TranslationLabel.Location = new Point(208, 182);
            TranslationLabel.Name = "TranslationLabel";
            TranslationLabel.Size = new Size(575, 152);
            TranslationLabel.TabIndex = 1;
            TranslationLabel.Text = "ХХХ";
            TranslationLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RateTableLayoutPanel
            // 
            RateTableLayoutPanel.ColumnCount = 5;
            RateTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            RateTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            RateTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            RateTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            RateTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            RateTableLayoutPanel.Controls.Add(Button5, 4, 0);
            RateTableLayoutPanel.Controls.Add(Button4, 3, 0);
            RateTableLayoutPanel.Controls.Add(Button3, 2, 0);
            RateTableLayoutPanel.Controls.Add(Button2, 1, 0);
            RateTableLayoutPanel.Controls.Add(Button1, 0, 0);
            RateTableLayoutPanel.Location = new Point(221, 361);
            RateTableLayoutPanel.Name = "RateTableLayoutPanel";
            RateTableLayoutPanel.RowCount = 1;
            RateTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            RateTableLayoutPanel.Size = new Size(542, 101);
            RateTableLayoutPanel.TabIndex = 2;
            // 
            // Button5
            // 
            Button5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Button5.BackColor = Color.FromArgb(50, 50, 50);
            Button5.BackgroundImageLayout = ImageLayout.Zoom;
            Button5.CausesValidation = false;
            Button5.Cursor = Cursors.Hand;
            Button5.FlatAppearance.BorderColor = Color.Gray;
            Button5.FlatAppearance.BorderSize = 0;
            Button5.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 70, 70);
            Button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            Button5.FlatStyle = FlatStyle.Flat;
            Button5.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Button5.ForeColor = Color.White;
            Button5.Location = new Point(436, 4);
            Button5.Margin = new Padding(4);
            Button5.Name = "Button5";
            Button5.Size = new Size(102, 93);
            Button5.TabIndex = 0;
            Button5.TabStop = false;
            Button5.UseVisualStyleBackColor = false;
            Button5.Click += Button5_Click;
            // 
            // Button4
            // 
            Button4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Button4.BackColor = Color.FromArgb(50, 50, 50);
            Button4.BackgroundImageLayout = ImageLayout.Zoom;
            Button4.CausesValidation = false;
            Button4.Cursor = Cursors.Hand;
            Button4.FlatAppearance.BorderColor = Color.Gray;
            Button4.FlatAppearance.BorderSize = 0;
            Button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 70, 70);
            Button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            Button4.FlatStyle = FlatStyle.Flat;
            Button4.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Button4.ForeColor = Color.White;
            Button4.Location = new Point(328, 4);
            Button4.Margin = new Padding(4);
            Button4.Name = "Button4";
            Button4.Size = new Size(100, 93);
            Button4.TabIndex = 1;
            Button4.TabStop = false;
            Button4.UseVisualStyleBackColor = false;
            Button4.Click += Button4_Click;
            // 
            // Button3
            // 
            Button3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Button3.BackColor = Color.FromArgb(50, 50, 50);
            Button3.BackgroundImageLayout = ImageLayout.Zoom;
            Button3.CausesValidation = false;
            Button3.Cursor = Cursors.Hand;
            Button3.FlatAppearance.BorderColor = Color.Gray;
            Button3.FlatAppearance.BorderSize = 0;
            Button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 70, 70);
            Button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            Button3.FlatStyle = FlatStyle.Flat;
            Button3.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Button3.ForeColor = Color.White;
            Button3.Location = new Point(220, 4);
            Button3.Margin = new Padding(4);
            Button3.Name = "Button3";
            Button3.Size = new Size(100, 93);
            Button3.TabIndex = 2;
            Button3.TabStop = false;
            Button3.UseVisualStyleBackColor = false;
            Button3.Click += Button3_Click;
            // 
            // Button2
            // 
            Button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Button2.BackColor = Color.FromArgb(50, 50, 50);
            Button2.BackgroundImageLayout = ImageLayout.Zoom;
            Button2.CausesValidation = false;
            Button2.Cursor = Cursors.Hand;
            Button2.FlatAppearance.BorderColor = Color.Gray;
            Button2.FlatAppearance.BorderSize = 0;
            Button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 70, 70);
            Button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            Button2.FlatStyle = FlatStyle.Flat;
            Button2.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Button2.ForeColor = Color.White;
            Button2.Location = new Point(112, 4);
            Button2.Margin = new Padding(4);
            Button2.Name = "Button2";
            Button2.Size = new Size(100, 93);
            Button2.TabIndex = 3;
            Button2.TabStop = false;
            Button2.UseVisualStyleBackColor = false;
            Button2.Click += Button2_Click;
            // 
            // Button1
            // 
            Button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Button1.BackColor = Color.FromArgb(50, 50, 50);
            Button1.BackgroundImageLayout = ImageLayout.Zoom;
            Button1.CausesValidation = false;
            Button1.Cursor = Cursors.Hand;
            Button1.FlatAppearance.BorderColor = Color.Gray;
            Button1.FlatAppearance.BorderSize = 0;
            Button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 70, 70);
            Button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            Button1.FlatStyle = FlatStyle.Flat;
            Button1.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Button1.ForeColor = Color.White;
            Button1.Location = new Point(4, 4);
            Button1.Margin = new Padding(4);
            Button1.Name = "Button1";
            Button1.Size = new Size(100, 93);
            Button1.TabIndex = 4;
            Button1.TabStop = false;
            Button1.UseVisualStyleBackColor = false;
            Button1.Click += Button1_Click;
            // 
            // EngWLabel2
            // 
            EngWLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            EngWLabel2.BackColor = Color.FromArgb(75, 75, 75);
            EngWLabel2.BorderStyle = BorderStyle.FixedSingle;
            EngWLabel2.Font = new Font("Impact", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            EngWLabel2.ForeColor = Color.White;
            EngWLabel2.Location = new Point(272, 76);
            EngWLabel2.Name = "EngWLabel2";
            EngWLabel2.Size = new Size(447, 76);
            EngWLabel2.TabIndex = 3;
            EngWLabel2.Text = "ХХХ";
            EngWLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LearningEngPanel
            // 
            LearningEngPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LearningEngPanel.BorderStyle = BorderStyle.FixedSingle;
            LearningEngPanel.Controls.Add(EngWLabel1);
            LearningEngPanel.Controls.Add(GoBackButton1);
            LearningEngPanel.Controls.Add(SeeTransButton);
            LearningEngPanel.ImeMode = ImeMode.Hangul;
            LearningEngPanel.Location = new Point(0, 31);
            LearningEngPanel.Name = "LearningEngPanel";
            LearningEngPanel.Size = new Size(978, 519);
            LearningEngPanel.TabIndex = 10;
            // 
            // EngWLabel1
            // 
            EngWLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            EngWLabel1.BackColor = Color.FromArgb(75, 75, 75);
            EngWLabel1.BorderStyle = BorderStyle.FixedSingle;
            EngWLabel1.Font = new Font("Impact", 36F, FontStyle.Regular, GraphicsUnit.Point);
            EngWLabel1.ForeColor = Color.White;
            EngWLabel1.Location = new Point(250, 176);
            EngWLabel1.Name = "EngWLabel1";
            EngWLabel1.Size = new Size(469, 95);
            EngWLabel1.TabIndex = 0;
            EngWLabel1.Text = "ХХХ";
            EngWLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GoBackButton1
            // 
            GoBackButton1.BackColor = Color.FromArgb(50, 50, 50);
            GoBackButton1.BackgroundImage = Eng_Flash_Cards_Learner.Resource1.icons8_налево_96;
            GoBackButton1.BackgroundImageLayout = ImageLayout.Zoom;
            GoBackButton1.Cursor = Cursors.Hand;
            GoBackButton1.FlatAppearance.BorderColor = Color.Gray;
            GoBackButton1.FlatAppearance.BorderSize = 0;
            GoBackButton1.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 50, 50);
            GoBackButton1.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            GoBackButton1.FlatStyle = FlatStyle.Flat;
            GoBackButton1.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            GoBackButton1.ForeColor = Color.White;
            GoBackButton1.Location = new Point(3, 3);
            GoBackButton1.Name = "GoBackButton1";
            GoBackButton1.Size = new Size(60, 60);
            GoBackButton1.TabIndex = 2;
            GoBackButton1.TabStop = false;
            GoBackButton1.UseVisualStyleBackColor = false;
            GoBackButton1.Click += GoBackButton_Click;
            // 
            // SeeTransButton
            // 
            SeeTransButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SeeTransButton.BackColor = SystemColors.WindowFrame;
            SeeTransButton.CausesValidation = false;
            SeeTransButton.Cursor = Cursors.Hand;
            SeeTransButton.FlatAppearance.BorderColor = Color.FromArgb(130, 130, 130);
            SeeTransButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            SeeTransButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            SeeTransButton.FlatStyle = FlatStyle.Flat;
            SeeTransButton.Font = new Font("Roboto Condensed", 18F, FontStyle.Bold, GraphicsUnit.Point);
            SeeTransButton.ForeColor = Color.White;
            SeeTransButton.Location = new Point(330, 388);
            SeeTransButton.Margin = new Padding(10);
            SeeTransButton.MaximumSize = new Size(350, 70);
            SeeTransButton.MinimumSize = new Size(300, 50);
            SeeTransButton.Name = "SeeTransButton";
            SeeTransButton.Size = new Size(320, 60);
            SeeTransButton.TabIndex = 1;
            SeeTransButton.TabStop = false;
            SeeTransButton.Text = "Побачити переклад";
            SeeTransButton.UseVisualStyleBackColor = false;
            SeeTransButton.Click += SeeTransButton_Click;
            SeeTransButton.KeyDown += SeeTransButton_KeyDown;
            // 
            // LearningStatPanel
            // 
            LearningStatPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LearningStatPanel.BorderStyle = BorderStyle.FixedSingle;
            LearningStatPanel.Controls.Add(LearningRatingLabel);
            LearningStatPanel.Controls.Add(RetryButton);
            LearningStatPanel.Controls.Add(StatLabel1);
            LearningStatPanel.Controls.Add(GoMenuButton);
            LearningStatPanel.Controls.Add(LearningStatLabel);
            LearningStatPanel.ImeMode = ImeMode.Hangul;
            LearningStatPanel.Location = new Point(0, 31);
            LearningStatPanel.Name = "LearningStatPanel";
            LearningStatPanel.Size = new Size(978, 519);
            LearningStatPanel.TabIndex = 2;
            // 
            // LearningRatingLabel
            // 
            LearningRatingLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LearningRatingLabel.BackColor = Color.FromArgb(60, 60, 60);
            LearningRatingLabel.BorderStyle = BorderStyle.FixedSingle;
            LearningRatingLabel.Font = new Font("Roboto Condensed", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            LearningRatingLabel.ForeColor = Color.White;
            LearningRatingLabel.Location = new Point(291, 329);
            LearningRatingLabel.Name = "LearningRatingLabel";
            LearningRatingLabel.Size = new Size(422, 37);
            LearningRatingLabel.TabIndex = 0;
            LearningRatingLabel.Text = "XXX";
            LearningRatingLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RetryButton
            // 
            RetryButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RetryButton.BackColor = SystemColors.WindowFrame;
            RetryButton.CausesValidation = false;
            RetryButton.Cursor = Cursors.Hand;
            RetryButton.FlatAppearance.BorderColor = Color.FromArgb(130, 130, 130);
            RetryButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            RetryButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            RetryButton.FlatStyle = FlatStyle.Flat;
            RetryButton.Font = new Font("Roboto Condensed", 18F, FontStyle.Bold, GraphicsUnit.Point);
            RetryButton.ForeColor = Color.White;
            RetryButton.Location = new Point(533, 405);
            RetryButton.Margin = new Padding(10);
            RetryButton.MaximumSize = new Size(350, 70);
            RetryButton.MinimumSize = new Size(150, 50);
            RetryButton.Name = "RetryButton";
            RetryButton.Size = new Size(250, 70);
            RetryButton.TabIndex = 1;
            RetryButton.TabStop = false;
            RetryButton.Text = "Тренуватись ще";
            RetryButton.UseVisualStyleBackColor = false;
            RetryButton.Click += RetryButton_Click;
            // 
            // StatLabel1
            // 
            StatLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StatLabel1.AutoSize = true;
            StatLabel1.BackColor = Color.FromArgb(50, 50, 50);
            StatLabel1.BorderStyle = BorderStyle.FixedSingle;
            StatLabel1.Font = new Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            StatLabel1.ForeColor = Color.White;
            StatLabel1.Location = new Point(304, 46);
            StatLabel1.Name = "StatLabel1";
            StatLabel1.Size = new Size(411, 47);
            StatLabel1.TabIndex = 2;
            StatLabel1.Text = "Результати Тренування:";
            StatLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GoMenuButton
            // 
            GoMenuButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GoMenuButton.BackColor = SystemColors.WindowFrame;
            GoMenuButton.CausesValidation = false;
            GoMenuButton.Cursor = Cursors.Hand;
            GoMenuButton.FlatAppearance.BorderColor = Color.FromArgb(130, 130, 130);
            GoMenuButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            GoMenuButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            GoMenuButton.FlatStyle = FlatStyle.Flat;
            GoMenuButton.Font = new Font("Roboto Condensed", 18F, FontStyle.Bold, GraphicsUnit.Point);
            GoMenuButton.ForeColor = Color.White;
            GoMenuButton.Location = new Point(225, 405);
            GoMenuButton.Margin = new Padding(10);
            GoMenuButton.MaximumSize = new Size(350, 70);
            GoMenuButton.MinimumSize = new Size(150, 50);
            GoMenuButton.Name = "GoMenuButton";
            GoMenuButton.Size = new Size(250, 70);
            GoMenuButton.TabIndex = 3;
            GoMenuButton.TabStop = false;
            GoMenuButton.Text = "Завершити";
            GoMenuButton.UseVisualStyleBackColor = false;
            GoMenuButton.Click += GoBackButton_Click;
            // 
            // LearningStatLabel
            // 
            LearningStatLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LearningStatLabel.BackColor = Color.FromArgb(60, 60, 60);
            LearningStatLabel.BorderStyle = BorderStyle.FixedSingle;
            LearningStatLabel.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            LearningStatLabel.ForeColor = Color.White;
            LearningStatLabel.Location = new Point(215, 110);
            LearningStatLabel.Name = "LearningStatLabel";
            LearningStatLabel.Size = new Size(575, 266);
            LearningStatLabel.TabIndex = 4;
            LearningStatLabel.Text = "ХХХ";
            LearningStatLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StatPanel
            // 
            StatPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StatPanel.BorderStyle = BorderStyle.FixedSingle;
            StatPanel.Controls.Add(GoBackButton3);
            StatPanel.Controls.Add(StatHeaderLabel);
            StatPanel.Controls.Add(StatLabel);
            StatPanel.ImeMode = ImeMode.Hangul;
            StatPanel.Location = new Point(0, 31);
            StatPanel.Name = "StatPanel";
            StatPanel.Size = new Size(978, 519);
            StatPanel.TabIndex = 3;
            // 
            // GoBackButton3
            // 
            GoBackButton3.BackColor = Color.FromArgb(50, 50, 50);
            GoBackButton3.BackgroundImage = Eng_Flash_Cards_Learner.Resource1.icons8_налево_96;
            GoBackButton3.BackgroundImageLayout = ImageLayout.Zoom;
            GoBackButton3.Cursor = Cursors.Hand;
            GoBackButton3.FlatAppearance.BorderColor = Color.Gray;
            GoBackButton3.FlatAppearance.BorderSize = 0;
            GoBackButton3.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 50, 50);
            GoBackButton3.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            GoBackButton3.FlatStyle = FlatStyle.Flat;
            GoBackButton3.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            GoBackButton3.ForeColor = Color.White;
            GoBackButton3.Location = new Point(3, 3);
            GoBackButton3.Name = "GoBackButton3";
            GoBackButton3.Size = new Size(60, 60);
            GoBackButton3.TabIndex = 0;
            GoBackButton3.TabStop = false;
            GoBackButton3.UseVisualStyleBackColor = false;
            GoBackButton3.Click += GoBackButton_Click;
            // 
            // StatHeaderLabel
            // 
            StatHeaderLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StatHeaderLabel.AutoSize = true;
            StatHeaderLabel.BackColor = Color.FromArgb(50, 50, 50);
            StatHeaderLabel.BorderStyle = BorderStyle.FixedSingle;
            StatHeaderLabel.Font = new Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            StatHeaderLabel.ForeColor = Color.White;
            StatHeaderLabel.Location = new Point(313, 51);
            StatHeaderLabel.Name = "StatHeaderLabel";
            StatHeaderLabel.Size = new Size(371, 47);
            StatHeaderLabel.TabIndex = 1;
            StatHeaderLabel.Text = "Загальна Статистика:";
            StatHeaderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StatLabel
            // 
            StatLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StatLabel.BackColor = Color.FromArgb(60, 60, 60);
            StatLabel.BorderStyle = BorderStyle.FixedSingle;
            StatLabel.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            StatLabel.ForeColor = Color.White;
            StatLabel.Location = new Point(203, 122);
            StatLabel.Name = "StatLabel";
            StatLabel.Size = new Size(586, 333);
            StatLabel.TabIndex = 2;
            StatLabel.Text = "ХХХ";
            StatLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AddingWPanel1
            // 
            AddingWPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AddingWPanel1.BorderStyle = BorderStyle.FixedSingle;
            AddingWPanel1.Controls.Add(CancelPrevButton1);
            AddingWPanel1.Controls.Add(AddWButton1);
            AddingWPanel1.Controls.Add(AddWLabel4);
            AddingWPanel1.Controls.Add(AddUaTTextBox);
            AddingWPanel1.Controls.Add(AddWLabel3);
            AddingWPanel1.Controls.Add(AddEngWTextBox);
            AddingWPanel1.Controls.Add(AddWLabel2);
            AddingWPanel1.Controls.Add(GoBackButton4);
            AddingWPanel1.Controls.Add(AddWLabel1);
            AddingWPanel1.ImeMode = ImeMode.Hangul;
            AddingWPanel1.Location = new Point(0, 31);
            AddingWPanel1.Name = "AddingWPanel1";
            AddingWPanel1.Size = new Size(978, 519);
            AddingWPanel1.TabIndex = 7;
            // 
            // CancelPrevButton1
            // 
            CancelPrevButton1.BackColor = SystemColors.WindowFrame;
            CancelPrevButton1.Cursor = Cursors.Hand;
            CancelPrevButton1.Enabled = false;
            CancelPrevButton1.FlatAppearance.BorderColor = Color.Gray;
            CancelPrevButton1.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            CancelPrevButton1.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            CancelPrevButton1.FlatStyle = FlatStyle.Flat;
            CancelPrevButton1.Font = new Font("Roboto Condensed", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            CancelPrevButton1.ForeColor = Color.White;
            CancelPrevButton1.Location = new Point(286, 420);
            CancelPrevButton1.Name = "CancelPrevButton1";
            CancelPrevButton1.Size = new Size(195, 53);
            CancelPrevButton1.TabIndex = 0;
            CancelPrevButton1.TabStop = false;
            CancelPrevButton1.Text = "Скасувати попереднє";
            CancelPrevButton1.UseVisualStyleBackColor = false;
            CancelPrevButton1.Click += CancelPrevButton_Click;
            // 
            // AddWButton1
            // 
            AddWButton1.BackColor = SystemColors.WindowFrame;
            AddWButton1.Cursor = Cursors.Hand;
            AddWButton1.Enabled = false;
            AddWButton1.FlatAppearance.BorderColor = Color.Gray;
            AddWButton1.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            AddWButton1.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            AddWButton1.FlatStyle = FlatStyle.Flat;
            AddWButton1.Font = new Font("Roboto Condensed", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            AddWButton1.ForeColor = Color.White;
            AddWButton1.Location = new Point(519, 420);
            AddWButton1.Name = "AddWButton1";
            AddWButton1.Size = new Size(195, 53);
            AddWButton1.TabIndex = 1;
            AddWButton1.TabStop = false;
            AddWButton1.Text = "Додати слово";
            AddWButton1.UseVisualStyleBackColor = false;
            AddWButton1.Click += AddWButton1_Click;
            // 
            // AddWLabel4
            // 
            AddWLabel4.AutoSize = true;
            AddWLabel4.Font = new Font("Roboto Condensed", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            AddWLabel4.ForeColor = Color.White;
            AddWLabel4.Location = new Point(322, 377);
            AddWLabel4.Name = "AddWLabel4";
            AddWLabel4.Size = new Size(169, 18);
            AddWLabel4.TabIndex = 2;
            AddWLabel4.Text = "*кожен в окремому рядку";
            AddWLabel4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AddUaTTextBox
            // 
            AddUaTTextBox.AcceptsReturn = true;
            AddUaTTextBox.BackColor = Color.FromArgb(90, 90, 90);
            AddUaTTextBox.Cursor = Cursors.IBeam;
            AddUaTTextBox.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            AddUaTTextBox.ForeColor = Color.White;
            AddUaTTextBox.Location = new Point(307, 224);
            AddUaTTextBox.Multiline = true;
            AddUaTTextBox.Name = "AddUaTTextBox";
            AddUaTTextBox.ScrollBars = ScrollBars.Vertical;
            AddUaTTextBox.Size = new Size(382, 152);
            AddUaTTextBox.TabIndex = 3;
            AddUaTTextBox.TabStop = false;
            AddUaTTextBox.TextChanged += EngUaTextBox_TextChanged;
            AddUaTTextBox.KeyPress += UaTextBox_KeyPress;
            // 
            // AddWLabel3
            // 
            AddWLabel3.AutoSize = true;
            AddWLabel3.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            AddWLabel3.ForeColor = Color.White;
            AddWLabel3.Location = new Point(396, 197);
            AddWLabel3.Name = "AddWLabel3";
            AddWLabel3.Size = new Size(208, 25);
            AddWLabel3.TabIndex = 4;
            AddWLabel3.Text = "Введи його переклади";
            AddWLabel3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AddEngWTextBox
            // 
            AddEngWTextBox.BackColor = Color.FromArgb(90, 90, 90);
            AddEngWTextBox.Cursor = Cursors.IBeam;
            AddEngWTextBox.Font = new Font("Roboto Condensed", 18F, FontStyle.Bold, GraphicsUnit.Point);
            AddEngWTextBox.ForeColor = Color.White;
            AddEngWTextBox.Location = new Point(346, 151);
            AddEngWTextBox.Name = "AddEngWTextBox";
            AddEngWTextBox.Size = new Size(308, 36);
            AddEngWTextBox.TabIndex = 5;
            AddEngWTextBox.TabStop = false;
            AddEngWTextBox.TextAlign = HorizontalAlignment.Center;
            AddEngWTextBox.TextChanged += EngUaTextBox_TextChanged;
            AddEngWTextBox.KeyPress += EngTextBox_KeyPress;
            // 
            // AddWLabel2
            // 
            AddWLabel2.AutoSize = true;
            AddWLabel2.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            AddWLabel2.ForeColor = Color.White;
            AddWLabel2.Location = new Point(388, 124);
            AddWLabel2.Name = "AddWLabel2";
            AddWLabel2.Size = new Size(222, 25);
            AddWLabel2.TabIndex = 6;
            AddWLabel2.Text = "Введи англійське слово";
            AddWLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GoBackButton4
            // 
            GoBackButton4.BackColor = Color.FromArgb(50, 50, 50);
            GoBackButton4.BackgroundImage = Eng_Flash_Cards_Learner.Resource1.icons8_налево_96;
            GoBackButton4.BackgroundImageLayout = ImageLayout.Zoom;
            GoBackButton4.Cursor = Cursors.Hand;
            GoBackButton4.FlatAppearance.BorderColor = Color.Gray;
            GoBackButton4.FlatAppearance.BorderSize = 0;
            GoBackButton4.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 50, 50);
            GoBackButton4.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            GoBackButton4.FlatStyle = FlatStyle.Flat;
            GoBackButton4.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            GoBackButton4.ForeColor = Color.White;
            GoBackButton4.Location = new Point(3, 3);
            GoBackButton4.Name = "GoBackButton4";
            GoBackButton4.Size = new Size(60, 60);
            GoBackButton4.TabIndex = 7;
            GoBackButton4.TabStop = false;
            GoBackButton4.UseVisualStyleBackColor = false;
            GoBackButton4.Click += GoBackButton_Click;
            // 
            // AddWLabel1
            // 
            AddWLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AddWLabel1.AutoSize = true;
            AddWLabel1.BackColor = Color.FromArgb(50, 50, 50);
            AddWLabel1.BorderStyle = BorderStyle.FixedSingle;
            AddWLabel1.Font = new Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            AddWLabel1.ForeColor = Color.White;
            AddWLabel1.Location = new Point(313, 49);
            AddWLabel1.Name = "AddWLabel1";
            AddWLabel1.Size = new Size(381, 47);
            AddWLabel1.TabIndex = 8;
            AddWLabel1.Text = "Додавання нових слів";
            AddWLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SettingPanel
            // 
            SettingPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SettingPanel.BorderStyle = BorderStyle.FixedSingle;
            SettingPanel.Controls.Add(label1);
            SettingPanel.Controls.Add(WSourceComboBox);
            SettingPanel.Controls.Add(NumberOfWordsNumericUpDown);
            SettingPanel.Controls.Add(DefaultSettingsButton);
            SettingPanel.Controls.Add(SaveSettingsButton);
            SettingPanel.Controls.Add(label3);
            SettingPanel.Controls.Add(GoBackButton5);
            SettingPanel.Controls.Add(label4);
            SettingPanel.ImeMode = ImeMode.Hangul;
            SettingPanel.Location = new Point(0, 31);
            SettingPanel.Name = "SettingPanel";
            SettingPanel.Size = new Size(978, 519);
            SettingPanel.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(360, 259);
            label1.Name = "label1";
            label1.Size = new Size(278, 25);
            label1.TabIndex = 0;
            label1.Text = "Додавати нові слова у вигляді";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WSourceComboBox
            // 
            WSourceComboBox.BackColor = Color.FromArgb(80, 80, 80);
            WSourceComboBox.Cursor = Cursors.Hand;
            WSourceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            WSourceComboBox.FlatStyle = FlatStyle.Popup;
            WSourceComboBox.Font = new Font("Roboto Condensed", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            WSourceComboBox.ForeColor = Color.White;
            WSourceComboBox.Items.AddRange(new object[] { "слово - переклад", "рядок в спец. форматі", "текстовий файл зі словами" });
            WSourceComboBox.Location = new Point(363, 299);
            WSourceComboBox.Name = "WSourceComboBox";
            WSourceComboBox.Size = new Size(273, 31);
            WSourceComboBox.TabIndex = 1;
            WSourceComboBox.TabStop = false;
            WSourceComboBox.SelectedIndexChanged += WSourceComboBox_SelectedIndexChanged;
            // 
            // NumberOfWordsNumericUpDown
            // 
            NumberOfWordsNumericUpDown.BackColor = Color.FromArgb(80, 80, 80);
            NumberOfWordsNumericUpDown.BorderStyle = BorderStyle.FixedSingle;
            NumberOfWordsNumericUpDown.Font = new Font("Roboto Condensed", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            NumberOfWordsNumericUpDown.ForeColor = Color.White;
            NumberOfWordsNumericUpDown.Location = new Point(419, 193);
            NumberOfWordsNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumberOfWordsNumericUpDown.Name = "NumberOfWordsNumericUpDown";
            NumberOfWordsNumericUpDown.Size = new Size(159, 30);
            NumberOfWordsNumericUpDown.TabIndex = 2;
            NumberOfWordsNumericUpDown.TextAlign = HorizontalAlignment.Center;
            NumberOfWordsNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            NumberOfWordsNumericUpDown.ValueChanged += WordCountNumericUpDown_ValueChanged;
            // 
            // DefaultSettingsButton
            // 
            DefaultSettingsButton.BackColor = SystemColors.WindowFrame;
            DefaultSettingsButton.Cursor = Cursors.Hand;
            DefaultSettingsButton.FlatAppearance.BorderColor = Color.Gray;
            DefaultSettingsButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            DefaultSettingsButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            DefaultSettingsButton.FlatStyle = FlatStyle.Flat;
            DefaultSettingsButton.Font = new Font("Roboto Condensed", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            DefaultSettingsButton.ForeColor = Color.White;
            DefaultSettingsButton.Location = new Point(286, 389);
            DefaultSettingsButton.Name = "DefaultSettingsButton";
            DefaultSettingsButton.Size = new Size(195, 53);
            DefaultSettingsButton.TabIndex = 3;
            DefaultSettingsButton.TabStop = false;
            DefaultSettingsButton.Text = "За замовчуванням";
            DefaultSettingsButton.UseVisualStyleBackColor = false;
            DefaultSettingsButton.Click += DefaultSettingsButton_Click;
            // 
            // SaveSettingsButton
            // 
            SaveSettingsButton.BackColor = SystemColors.WindowFrame;
            SaveSettingsButton.Cursor = Cursors.Hand;
            SaveSettingsButton.Enabled = false;
            SaveSettingsButton.FlatAppearance.BorderColor = Color.Gray;
            SaveSettingsButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            SaveSettingsButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            SaveSettingsButton.FlatStyle = FlatStyle.Flat;
            SaveSettingsButton.Font = new Font("Roboto Condensed", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            SaveSettingsButton.ForeColor = Color.White;
            SaveSettingsButton.Location = new Point(519, 389);
            SaveSettingsButton.Name = "SaveSettingsButton";
            SaveSettingsButton.Size = new Size(195, 53);
            SaveSettingsButton.TabIndex = 4;
            SaveSettingsButton.TabStop = false;
            SaveSettingsButton.Text = "Зберегти";
            SaveSettingsButton.UseVisualStyleBackColor = false;
            SaveSettingsButton.Click += SaveSettingsButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(366, 154);
            label3.Name = "label3";
            label3.Size = new Size(260, 25);
            label3.TabIndex = 5;
            label3.Text = "Кількість слів для вивчення";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GoBackButton5
            // 
            GoBackButton5.BackColor = Color.FromArgb(50, 50, 50);
            GoBackButton5.BackgroundImage = Eng_Flash_Cards_Learner.Resource1.icons8_налево_96;
            GoBackButton5.BackgroundImageLayout = ImageLayout.Zoom;
            GoBackButton5.Cursor = Cursors.Hand;
            GoBackButton5.FlatAppearance.BorderColor = Color.Gray;
            GoBackButton5.FlatAppearance.BorderSize = 0;
            GoBackButton5.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 50, 50);
            GoBackButton5.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            GoBackButton5.FlatStyle = FlatStyle.Flat;
            GoBackButton5.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            GoBackButton5.ForeColor = Color.White;
            GoBackButton5.Location = new Point(3, 3);
            GoBackButton5.Name = "GoBackButton5";
            GoBackButton5.Size = new Size(60, 60);
            GoBackButton5.TabIndex = 6;
            GoBackButton5.TabStop = false;
            GoBackButton5.UseVisualStyleBackColor = false;
            GoBackButton5.Click += GoBackButton_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(50, 50, 50);
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(364, 63);
            label4.Name = "label4";
            label4.Size = new Size(262, 47);
            label4.TabIndex = 7;
            label4.Text = "Налаштування";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AddingWPanel3
            // 
            AddingWPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AddingWPanel3.BorderStyle = BorderStyle.FixedSingle;
            AddingWPanel3.Controls.Add(DragAndDropPanel);
            AddingWPanel3.Controls.Add(SpecialFormatInfoBox2);
            AddingWPanel3.Controls.Add(CancelAddingButton);
            AddingWPanel3.Controls.Add(AddWButton3);
            AddingWPanel3.Controls.Add(GoBackButton6);
            AddingWPanel3.Controls.Add(label7);
            AddingWPanel3.ImeMode = ImeMode.Hangul;
            AddingWPanel3.Location = new Point(0, 31);
            AddingWPanel3.Name = "AddingWPanel3";
            AddingWPanel3.Size = new Size(978, 519);
            AddingWPanel3.TabIndex = 4;
            // 
            // DragAndDropPanel
            // 
            DragAndDropPanel.AllowDrop = true;
            DragAndDropPanel.BackColor = Color.FromArgb(60, 60, 60);
            DragAndDropPanel.Controls.Add(TxtFilePathTextBox);
            DragAndDropPanel.Controls.Add(label13);
            DragAndDropPanel.Controls.Add(label6);
            DragAndDropPanel.Controls.Add(ChooseFileButton);
            DragAndDropPanel.Controls.Add(label12);
            DragAndDropPanel.Location = new Point(100, 129);
            DragAndDropPanel.Name = "DragAndDropPanel";
            DragAndDropPanel.Size = new Size(768, 250);
            DragAndDropPanel.TabIndex = 10;
            DragAndDropPanel.DragDrop += DragAndDropPanel_DragDrop;
            DragAndDropPanel.DragEnter += DragAndDropPanel_DragEnter;
            DragAndDropPanel.DragLeave += DragAndDropPanel_DragLeave;
            DragAndDropPanel.Paint += DragAndDropPanel_Paint;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Roboto Condensed", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.White;
            label13.Location = new Point(275, 23);
            label13.Name = "label13";
            label13.Size = new Size(251, 29);
            label13.TabIndex = 11;
            label13.Text = "Список доданих файлів";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            label13.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Roboto Condensed", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(300, 99);
            label6.Name = "label6";
            label6.Size = new Size(204, 33);
            label6.TabIndex = 3;
            label6.Text = "Тягни його сюди!";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            label6.Visible = false;
            // 
            // ChooseFileButton
            // 
            ChooseFileButton.BackColor = SystemColors.WindowFrame;
            ChooseFileButton.Cursor = Cursors.Hand;
            ChooseFileButton.FlatAppearance.BorderColor = Color.Gray;
            ChooseFileButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            ChooseFileButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            ChooseFileButton.FlatStyle = FlatStyle.Flat;
            ChooseFileButton.Font = new Font("Roboto Condensed", 18F, FontStyle.Bold, GraphicsUnit.Point);
            ChooseFileButton.ForeColor = Color.White;
            ChooseFileButton.Location = new Point(291, 59);
            ChooseFileButton.Name = "ChooseFileButton";
            ChooseFileButton.Size = new Size(221, 65);
            ChooseFileButton.TabIndex = 10;
            ChooseFileButton.TabStop = false;
            ChooseFileButton.Text = "Вибери .txt-файл";
            ChooseFileButton.UseVisualStyleBackColor = false;
            ChooseFileButton.Click += ChooseFileButton_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(268, 152);
            label12.Name = "label12";
            label12.Size = new Size(260, 25);
            label12.TabIndex = 9;
            label12.Text = "... або перетягни файл сюди";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TxtFilePathTextBox
            // 
            TxtFilePathTextBox.AcceptsReturn = true;
            TxtFilePathTextBox.BackColor = Color.FromArgb(90, 90, 90);
            TxtFilePathTextBox.BorderStyle = BorderStyle.FixedSingle;
            TxtFilePathTextBox.Cursor = Cursors.IBeam;
            TxtFilePathTextBox.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            TxtFilePathTextBox.ForeColor = Color.White;
            TxtFilePathTextBox.Location = new Point(55, 59);
            TxtFilePathTextBox.Multiline = true;
            TxtFilePathTextBox.Name = "TxtFilePathTextBox";
            TxtFilePathTextBox.ScrollBars = ScrollBars.Both;
            TxtFilePathTextBox.Size = new Size(665, 151);
            TxtFilePathTextBox.TabIndex = 2;
            TxtFilePathTextBox.TabStop = false;
            TxtFilePathTextBox.TextAlign = HorizontalAlignment.Center;
            TxtFilePathTextBox.Visible = false;
            TxtFilePathTextBox.TextChanged += TxtFilePathTextBox_TextChanged;
            // 
            // SpecialFormatInfoBox2
            // 
            SpecialFormatInfoBox2.AccessibleRole = AccessibleRole.HelpBalloon;
            SpecialFormatInfoBox2.BackgroundImage = Eng_Flash_Cards_Learner.Resource1.icons8_вопрос_48;
            SpecialFormatInfoBox2.BackgroundImageLayout = ImageLayout.Zoom;
            SpecialFormatInfoBox2.Cursor = Cursors.Help;
            SpecialFormatInfoBox2.Location = new Point(928, 15);
            SpecialFormatInfoBox2.Name = "SpecialFormatInfoBox2";
            SpecialFormatInfoBox2.Size = new Size(35, 35);
            SpecialFormatInfoBox2.TabIndex = 8;
            SpecialFormatInfoBox2.TabStop = false;
            SpecialFormatLineTip.SetToolTip(SpecialFormatInfoBox2, resources.GetString("SpecialFormatInfoBox2.ToolTip"));
            // 
            // CancelAddingButton
            // 
            CancelAddingButton.BackColor = SystemColors.WindowFrame;
            CancelAddingButton.Cursor = Cursors.Hand;
            CancelAddingButton.Enabled = false;
            CancelAddingButton.FlatAppearance.BorderColor = Color.Gray;
            CancelAddingButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            CancelAddingButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            CancelAddingButton.FlatStyle = FlatStyle.Flat;
            CancelAddingButton.Font = new Font("Roboto Condensed", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            CancelAddingButton.ForeColor = Color.White;
            CancelAddingButton.Location = new Point(272, 412);
            CancelAddingButton.Name = "CancelAddingButton";
            CancelAddingButton.Size = new Size(195, 53);
            CancelAddingButton.TabIndex = 0;
            CancelAddingButton.TabStop = false;
            CancelAddingButton.Text = "Скасувати додавання";
            CancelAddingButton.UseVisualStyleBackColor = false;
            CancelAddingButton.Click += CancelAddingButton_Click;
            // 
            // AddWButton3
            // 
            AddWButton3.BackColor = SystemColors.WindowFrame;
            AddWButton3.Cursor = Cursors.Hand;
            AddWButton3.Enabled = false;
            AddWButton3.FlatAppearance.BorderColor = Color.Gray;
            AddWButton3.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            AddWButton3.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            AddWButton3.FlatStyle = FlatStyle.Flat;
            AddWButton3.Font = new Font("Roboto Condensed", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            AddWButton3.ForeColor = Color.White;
            AddWButton3.Location = new Point(535, 412);
            AddWButton3.Name = "AddWButton3";
            AddWButton3.Size = new Size(195, 53);
            AddWButton3.TabIndex = 1;
            AddWButton3.TabStop = false;
            AddWButton3.Text = "Додати слова з файлу";
            AddWButton3.UseVisualStyleBackColor = false;
            AddWButton3.Click += AddWButton3_Click;
            // 
            // GoBackButton6
            // 
            GoBackButton6.BackColor = Color.FromArgb(50, 50, 50);
            GoBackButton6.BackgroundImage = Eng_Flash_Cards_Learner.Resource1.icons8_налево_96;
            GoBackButton6.BackgroundImageLayout = ImageLayout.Zoom;
            GoBackButton6.Cursor = Cursors.Hand;
            GoBackButton6.FlatAppearance.BorderColor = Color.Gray;
            GoBackButton6.FlatAppearance.BorderSize = 0;
            GoBackButton6.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 50, 50);
            GoBackButton6.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            GoBackButton6.FlatStyle = FlatStyle.Flat;
            GoBackButton6.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            GoBackButton6.ForeColor = Color.White;
            GoBackButton6.Location = new Point(3, 3);
            GoBackButton6.Name = "GoBackButton6";
            GoBackButton6.Size = new Size(60, 60);
            GoBackButton6.TabIndex = 4;
            GoBackButton6.TabStop = false;
            GoBackButton6.UseVisualStyleBackColor = false;
            GoBackButton6.Click += GoBackButton_Click;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(50, 50, 50);
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Font = new Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(313, 48);
            label7.Name = "label7";
            label7.Size = new Size(381, 47);
            label7.TabIndex = 5;
            label7.Text = "Додавання нових слів";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AddingWPanel2
            // 
            AddingWPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AddingWPanel2.BorderStyle = BorderStyle.FixedSingle;
            AddingWPanel2.Controls.Add(GoBackButton7);
            AddingWPanel2.Controls.Add(SpecialFormatInfoBox1);
            AddingWPanel2.Controls.Add(CancelPrevButton2);
            AddingWPanel2.Controls.Add(AddWButton2);
            AddingWPanel2.Controls.Add(EngUaStringTextBox);
            AddingWPanel2.Controls.Add(label2);
            AddingWPanel2.Controls.Add(label5);
            AddingWPanel2.ImeMode = ImeMode.Hangul;
            AddingWPanel2.Location = new Point(0, 31);
            AddingWPanel2.Name = "AddingWPanel2";
            AddingWPanel2.Size = new Size(978, 519);
            AddingWPanel2.TabIndex = 5;
            // 
            // GoBackButton7
            // 
            GoBackButton7.BackColor = Color.FromArgb(50, 50, 50);
            GoBackButton7.BackgroundImage = Eng_Flash_Cards_Learner.Resource1.icons8_налево_96;
            GoBackButton7.BackgroundImageLayout = ImageLayout.Zoom;
            GoBackButton7.Cursor = Cursors.Hand;
            GoBackButton7.FlatAppearance.BorderColor = Color.Gray;
            GoBackButton7.FlatAppearance.BorderSize = 0;
            GoBackButton7.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 50, 50);
            GoBackButton7.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            GoBackButton7.FlatStyle = FlatStyle.Flat;
            GoBackButton7.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            GoBackButton7.ForeColor = Color.White;
            GoBackButton7.Location = new Point(3, 3);
            GoBackButton7.Name = "GoBackButton7";
            GoBackButton7.Size = new Size(60, 60);
            GoBackButton7.TabIndex = 4;
            GoBackButton7.TabStop = false;
            GoBackButton7.UseVisualStyleBackColor = false;
            GoBackButton7.Click += GoBackButton_Click;
            // 
            // SpecialFormatInfoBox1
            // 
            SpecialFormatInfoBox1.AccessibleRole = AccessibleRole.HelpBalloon;
            SpecialFormatInfoBox1.BackgroundImage = Eng_Flash_Cards_Learner.Resource1.icons8_вопрос_48;
            SpecialFormatInfoBox1.BackgroundImageLayout = ImageLayout.Zoom;
            SpecialFormatInfoBox1.Cursor = Cursors.Help;
            SpecialFormatInfoBox1.Location = new Point(930, 12);
            SpecialFormatInfoBox1.Name = "SpecialFormatInfoBox1";
            SpecialFormatInfoBox1.Size = new Size(35, 35);
            SpecialFormatInfoBox1.TabIndex = 7;
            SpecialFormatInfoBox1.TabStop = false;
            SpecialFormatLineTip.SetToolTip(SpecialFormatInfoBox1, resources.GetString("SpecialFormatInfoBox1.ToolTip"));
            // 
            // CancelPrevButton2
            // 
            CancelPrevButton2.BackColor = SystemColors.WindowFrame;
            CancelPrevButton2.Cursor = Cursors.Hand;
            CancelPrevButton2.Enabled = false;
            CancelPrevButton2.FlatAppearance.BorderColor = Color.Gray;
            CancelPrevButton2.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            CancelPrevButton2.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            CancelPrevButton2.FlatStyle = FlatStyle.Flat;
            CancelPrevButton2.Font = new Font("Roboto Condensed", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            CancelPrevButton2.ForeColor = Color.White;
            CancelPrevButton2.Location = new Point(270, 395);
            CancelPrevButton2.Name = "CancelPrevButton2";
            CancelPrevButton2.Size = new Size(195, 53);
            CancelPrevButton2.TabIndex = 0;
            CancelPrevButton2.TabStop = false;
            CancelPrevButton2.Text = "Скасувати додавання";
            CancelPrevButton2.UseVisualStyleBackColor = false;
            CancelPrevButton2.Click += CancelPrevButton_Click;
            // 
            // AddWButton2
            // 
            AddWButton2.BackColor = SystemColors.WindowFrame;
            AddWButton2.Cursor = Cursors.Hand;
            AddWButton2.Enabled = false;
            AddWButton2.FlatAppearance.BorderColor = Color.Gray;
            AddWButton2.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            AddWButton2.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            AddWButton2.FlatStyle = FlatStyle.Flat;
            AddWButton2.Font = new Font("Roboto Condensed", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            AddWButton2.ForeColor = Color.White;
            AddWButton2.Location = new Point(528, 395);
            AddWButton2.Name = "AddWButton2";
            AddWButton2.Size = new Size(195, 53);
            AddWButton2.TabIndex = 1;
            AddWButton2.TabStop = false;
            AddWButton2.Text = "Додати слово";
            AddWButton2.UseVisualStyleBackColor = false;
            AddWButton2.Click += AddWButton2_Click;
            // 
            // EngUaStringTextBox
            // 
            EngUaStringTextBox.BackColor = Color.FromArgb(90, 90, 90);
            EngUaStringTextBox.Cursor = Cursors.IBeam;
            EngUaStringTextBox.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            EngUaStringTextBox.ForeColor = Color.White;
            EngUaStringTextBox.Location = new Point(185, 250);
            EngUaStringTextBox.Name = "EngUaStringTextBox";
            EngUaStringTextBox.ScrollBars = ScrollBars.Horizontal;
            EngUaStringTextBox.Size = new Size(635, 33);
            EngUaStringTextBox.TabIndex = 2;
            EngUaStringTextBox.TabStop = false;
            EngUaStringTextBox.TextAlign = HorizontalAlignment.Center;
            EngUaStringTextBox.TextChanged += EngUaStringTextBox_TextChanged;
            EngUaStringTextBox.KeyPress += EngUaStringTextBox_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(292, 211);
            label2.Name = "label2";
            label2.Size = new Size(431, 25);
            label2.TabIndex = 3;
            label2.Text = "Введи рядок зі словом в спеціальному форматі";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(50, 50, 50);
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Font = new Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(313, 65);
            label5.Name = "label5";
            label5.Size = new Size(381, 47);
            label5.TabIndex = 5;
            label5.Text = "Додавання нових слів";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(label11);
            panel1.ImeMode = ImeMode.Hangul;
            panel1.Location = new Point(0, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(978, 519);
            panel1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.NullValue = "-";
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.LightGray;
            dataGridViewCellStyle2.Font = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.NullValue = "-";
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlDark;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { WordID, EngWord, UaTranslation, Rating });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Gainsboro;
            dataGridViewCellStyle3.Font = new Font("Roboto Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.ControlDark;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.GridColor = Color.Gray;
            dataGridView1.Location = new Point(497, 118);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.LightGray;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.ControlDark;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(403, 270);
            dataGridView1.TabIndex = 0;
            // 
            // WordID
            // 
            WordID.HeaderText = "ID";
            WordID.Name = "WordID";
            // 
            // EngWord
            // 
            EngWord.HeaderText = "Eng";
            EngWord.Name = "EngWord";
            // 
            // UaTranslation
            // 
            UaTranslation.HeaderText = "Ua";
            UaTranslation.Name = "UaTranslation";
            // 
            // Rating
            // 
            Rating.HeaderText = "Rating";
            Rating.Name = "Rating";
            // 
            // button6
            // 
            button6.BackColor = SystemColors.WindowFrame;
            button6.Cursor = Cursors.Hand;
            button6.Enabled = false;
            button6.FlatAppearance.BorderColor = Color.Gray;
            button6.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Roboto Condensed", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button6.ForeColor = Color.White;
            button6.Location = new Point(286, 420);
            button6.Name = "button6";
            button6.Size = new Size(195, 53);
            button6.TabIndex = 1;
            button6.TabStop = false;
            button6.Text = "Скасувати попереднє";
            button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = SystemColors.WindowFrame;
            button7.Cursor = Cursors.Hand;
            button7.Enabled = false;
            button7.FlatAppearance.BorderColor = Color.Gray;
            button7.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            button7.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Roboto Condensed", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button7.ForeColor = Color.White;
            button7.Location = new Point(519, 420);
            button7.Name = "button7";
            button7.Size = new Size(195, 53);
            button7.TabIndex = 2;
            button7.TabStop = false;
            button7.Text = "Додати слово";
            button7.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Roboto Condensed", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(87, 376);
            label8.Name = "label8";
            label8.Size = new Size(169, 18);
            label8.TabIndex = 3;
            label8.Text = "*кожен в окремому рядку";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            textBox1.AcceptsReturn = true;
            textBox1.BackColor = Color.FromArgb(90, 90, 90);
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Font = new Font("Roboto Condensed", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(86, 222);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(318, 152);
            textBox1.TabIndex = 4;
            textBox1.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(141, 195);
            label9.Name = "label9";
            label9.Size = new Size(208, 25);
            label9.TabIndex = 5;
            label9.Text = "Введи його переклади";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(90, 90, 90);
            textBox2.Cursor = Cursors.IBeam;
            textBox2.Font = new Font("Roboto Condensed", 18F, FontStyle.Bold, GraphicsUnit.Point);
            textBox2.ForeColor = Color.White;
            textBox2.Location = new Point(91, 149);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(308, 36);
            textBox2.TabIndex = 6;
            textBox2.TabStop = false;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(133, 122);
            label10.Name = "label10";
            label10.Size = new Size(222, 25);
            label10.TabIndex = 7;
            label10.Text = "Введи англійське слово";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(50, 50, 50);
            button8.BackgroundImageLayout = ImageLayout.Zoom;
            button8.Cursor = Cursors.Hand;
            button8.FlatAppearance.BorderColor = Color.Gray;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 50, 50);
            button8.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button8.ForeColor = Color.White;
            button8.Location = new Point(3, 3);
            button8.Name = "button8";
            button8.Size = new Size(60, 60);
            button8.TabIndex = 8;
            button8.TabStop = false;
            button8.UseVisualStyleBackColor = false;
            button8.Click += GoBackButton_Click;
            // 
            // label11
            // 
            label11.AccessibleRole = AccessibleRole.StaticText;
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.BackColor = Color.FromArgb(50, 50, 50);
            label11.BorderStyle = BorderStyle.FixedSingle;
            label11.Font = new Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = Color.White;
            label11.Location = new Point(313, 49);
            label11.Name = "label11";
            label11.Size = new Size(381, 47);
            label11.TabIndex = 9;
            label11.Text = "Додавання нових слів";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SpecialFormatLineTip
            // 
            SpecialFormatLineTip.AutoPopDelay = 20000;
            SpecialFormatLineTip.BackColor = SystemColors.GrayText;
            SpecialFormatLineTip.ForeColor = SystemColors.ControlLight;
            SpecialFormatLineTip.InitialDelay = 300;
            SpecialFormatLineTip.IsBalloon = true;
            SpecialFormatLineTip.ReshowDelay = 100;
            SpecialFormatLineTip.ShowAlways = true;
            SpecialFormatLineTip.ToolTipIcon = ToolTipIcon.Info;
            SpecialFormatLineTip.ToolTipTitle = "Спеціальний формат";
            // 
            // WrongFileFormatPopup
            // 
            WrongFileFormatPopup.BodyColor = Color.FromArgb(65, 65, 65);
            WrongFileFormatPopup.BorderColor = Color.Gray;
            WrongFileFormatPopup.ButtonBorderColor = Color.Gray;
            WrongFileFormatPopup.ButtonHoverColor = Color.FromArgb(60, 60, 60);
            WrongFileFormatPopup.ContentColor = Color.White;
            WrongFileFormatPopup.ContentFont = new Font("Roboto Condensed", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            WrongFileFormatPopup.ContentHoverColor = SystemColors.ControlLight;
            WrongFileFormatPopup.ContentPadding = new Padding(15, 3, 0, 0);
            WrongFileFormatPopup.ContentText = "Деякі (або всі) додані файли в хибному форматі!\r\nВ списку будуть тільки ті, що мають вірний формат";
            WrongFileFormatPopup.Delay = 5000;
            WrongFileFormatPopup.GradientPower = 0;
            WrongFileFormatPopup.HeaderColor = Color.FromArgb(192, 0, 0);
            WrongFileFormatPopup.HeaderHeight = 12;
            WrongFileFormatPopup.Image = Eng_Flash_Cards_Learner.Resource1.Untitled_3_1;
            WrongFileFormatPopup.ImagePadding = new Padding(2, 12, 0, 0);
            WrongFileFormatPopup.ImageSize = new Size(125, 50);
            WrongFileFormatPopup.IsRightToLeft = false;
            WrongFileFormatPopup.OptionsMenu = null;
            WrongFileFormatPopup.Size = new Size(485, 95);
            WrongFileFormatPopup.TitleColor = Color.FromArgb(50, 50, 50);
            WrongFileFormatPopup.TitleFont = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            WrongFileFormatPopup.TitleText = "Хибний формат";
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(50, 50, 50);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(978, 550);
            Controls.Add(AddingWPanel3);
            Controls.Add(AddingWPanel2);
            Controls.Add(MenuPanel);
            Controls.Add(TopPanel);
            Controls.Add(AddingWPanel1);
            Controls.Add(SettingPanel);
            Controls.Add(LearningEngPanel);
            Controls.Add(panel1);
            Controls.Add(LearningUaPanel);
            Controls.Add(LearningStatPanel);
            Controls.Add(StatPanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "English Words Learner (flash-cards)";
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TitleIcoPictureBox).EndInit();
            MenuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)EWLPictureBox).EndInit();
            LearningUaPanel.ResumeLayout(false);
            RateTableLayoutPanel.ResumeLayout(false);
            LearningEngPanel.ResumeLayout(false);
            LearningStatPanel.ResumeLayout(false);
            LearningStatPanel.PerformLayout();
            StatPanel.ResumeLayout(false);
            StatPanel.PerformLayout();
            AddingWPanel1.ResumeLayout(false);
            AddingWPanel1.PerformLayout();
            SettingPanel.ResumeLayout(false);
            SettingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumberOfWordsNumericUpDown).EndInit();
            AddingWPanel3.ResumeLayout(false);
            AddingWPanel3.PerformLayout();
            DragAndDropPanel.ResumeLayout(false);
            DragAndDropPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SpecialFormatInfoBox2).EndInit();
            AddingWPanel2.ResumeLayout(false);
            AddingWPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SpecialFormatInfoBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button CloseButton;
        private Panel TopPanel;
        private Label TitleLabel;
        private PictureBox TitleIcoPictureBox;
        private Button MinimizeButton;
        private ImageList fullScreenImageList;
        private Panel MenuPanel;
        private Button FullScreenButton;
        private Button LearnWButton;
        private Button SeeAddingWPanelButton;
        private Button SeeStatButton;
        private PictureBox EWLPictureBox;
        private Panel LearningUaPanel;
        private Label EngWLabel2;
        private Button SettingButton;
        private Button Button1;
        private TableLayoutPanel RateTableLayoutPanel;
        private Button Button5;
        private Button Button4;
        private Button Button3;
        private Button Button2;
        private Button GoBackButton;
        private Label TranslationLabel;
        private Panel LearningEngPanel;
        private Button GoBackButton1;
        private Button SeeTransButton;
        private Label EngWLabel1;
        private Button GoBackButton2;
        private Panel LearningStatPanel;
        private Button GoMenuButton;
        private Label LearningStatLabel;
        private Label StatLabel1;
        private Button RetryButton;
        private Panel StatPanel;
        private Label StatHeaderLabel;
        private Label StatLabel;
        private Button GoBackButton3;
        private Panel AddingWPanel1;
        private Button GoBackButton4;
        private Label AddWLabel1;
        private Button AddWButton1;
        private Label AddWLabel4;
        private TextBox AddUaTTextBox;
        private Label AddWLabel3;
        private TextBox AddEngWTextBox;
        private Label AddWLabel2;
        private Button CancelPrevButton1;
        private Panel SettingPanel;
        private Button DefaultSettingsButton;
        private Button SaveSettingsButton;
        private Label label3;
        private Button GoBackButton5;
        private Label label4;
        private NumericUpDown NumberOfWordsNumericUpDown;
        private ComboBox WSourceComboBox;
        private Label label1;
        private Panel AddingWPanel3;
        private Button CancelAddingButton;
        private Button AddWButton3;
        private TextBox TxtFilePathTextBox;
        private Label label6;
        private Button GoBackButton6;
        private Label label7;
        private Panel AddingWPanel2;
        private Button CancelPrevButton2;
        private Button AddWButton2;
        private TextBox EngUaStringTextBox;
        private Label label2;
        private Button GoBackButton7;
        private Label label5;
        private Label LearningRatingLabel;
        private Panel panel1;
        private Button button6;
        private Button button7;
        private Label label8;
        private TextBox textBox1;
        private Label label9;
        private TextBox textBox2;
        private Label label10;
        private Button button8;
        private Label label11;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn WordID;
        private DataGridViewTextBoxColumn EngWord;
        private DataGridViewTextBoxColumn UaTranslation;
        private DataGridViewTextBoxColumn Rating;
        private PictureBox SpecialFormatInfoBox1;
        private ToolTip SpecialFormatLineTip;
        private PictureBox SpecialFormatInfoBox2;
        private Label label12;
        private Panel DragAndDropPanel;
        private Button ChooseFileButton;
        private PopupNotifier WrongFileFormatPopup;
        private Label label13;
    }
}