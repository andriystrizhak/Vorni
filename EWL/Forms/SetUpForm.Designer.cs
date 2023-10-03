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
            BottomPanel = new Panel();
            goBackButton = new Button();
            continueButton = new Button();
            label3 = new Label();
            TopPanel = new Panel();
            closeButton = new Button();
            BannerPanel = new Panel();
            startingPanel1 = new Panel();
            label7 = new Label();
            label8 = new Label();
            label6 = new Label();
            label1 = new Label();
            label5 = new Label();
            dbOrTxtPanel2 = new Panel();
            sourceTypeGroupBox = new GroupBox();
            radioButtonBD = new RadioButton();
            radioButtonTF = new RadioButton();
            label4 = new Label();
            txtActionPanel4 = new Panel();
            textFileTypeGroupBox = new GroupBox();
            radioButtonNewFT = new RadioButton();
            radioButtonOldFT = new RadioButton();
            label10 = new Label();
            dbActionPanel3 = new Panel();
            BDActionGroupBox = new GroupBox();
            radioButtonAddNewW = new RadioButton();
            radioButtonLearnAvaliableW = new RadioButton();
            label11 = new Label();
            label12 = new Label();
            wAddingPanel5 = new Panel();
            EngTextBox = new TextBox();
            CancelPrevButton = new Button();
            AddWButton = new Button();
            label16 = new Label();
            UaTextBox = new TextBox();
            label15 = new Label();
            label13 = new Label();
            label14 = new Label();
            BottomPanel.SuspendLayout();
            TopPanel.SuspendLayout();
            startingPanel1.SuspendLayout();
            dbOrTxtPanel2.SuspendLayout();
            sourceTypeGroupBox.SuspendLayout();
            txtActionPanel4.SuspendLayout();
            textFileTypeGroupBox.SuspendLayout();
            dbActionPanel3.SuspendLayout();
            BDActionGroupBox.SuspendLayout();
            wAddingPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // BottomPanel
            // 
            BottomPanel.BackColor = Color.FromArgb(65, 65, 65);
            BottomPanel.BorderStyle = BorderStyle.FixedSingle;
            BottomPanel.Controls.Add(goBackButton);
            BottomPanel.Controls.Add(continueButton);
            resources.ApplyResources(BottomPanel, "BottomPanel");
            BottomPanel.Name = "BottomPanel";
            // 
            // goBackButton
            // 
            goBackButton.BackColor = SystemColors.WindowFrame;
            goBackButton.Cursor = Cursors.Hand;
            resources.ApplyResources(goBackButton, "goBackButton");
            goBackButton.FlatAppearance.BorderColor = Color.Gray;
            goBackButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            goBackButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            goBackButton.ForeColor = Color.White;
            goBackButton.Name = "goBackButton";
            goBackButton.TabStop = false;
            goBackButton.UseVisualStyleBackColor = false;
            goBackButton.Click += PreviousButton_Click;
            // 
            // continueButton
            // 
            continueButton.BackColor = SystemColors.WindowFrame;
            continueButton.Cursor = Cursors.Hand;
            continueButton.FlatAppearance.BorderColor = Color.Gray;
            continueButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            continueButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            resources.ApplyResources(continueButton, "continueButton");
            continueButton.ForeColor = Color.White;
            continueButton.Name = "continueButton";
            continueButton.TabStop = false;
            continueButton.UseVisualStyleBackColor = false;
            continueButton.Click += ContinueButton_Click;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = Color.White;
            label3.Name = "label3";
            // 
            // TopPanel
            // 
            TopPanel.BackColor = Color.FromArgb(65, 65, 65);
            TopPanel.BorderStyle = BorderStyle.FixedSingle;
            TopPanel.Controls.Add(label3);
            TopPanel.Cursor = Cursors.SizeAll;
            resources.ApplyResources(TopPanel, "TopPanel");
            TopPanel.Name = "TopPanel";
            TopPanel.MouseDown += TopPanel_MouseDown;
            TopPanel.MouseMove += TopPanel_MouseMove;
            // 
            // closeButton
            // 
            closeButton.BackColor = Color.FromArgb(65, 65, 65);
            resources.ApplyResources(closeButton, "closeButton");
            closeButton.Cursor = Cursors.Hand;
            closeButton.FlatAppearance.BorderColor = Color.DimGray;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatAppearance.MouseDownBackColor = Color.Brown;
            closeButton.FlatAppearance.MouseOverBackColor = Color.Red;
            closeButton.ForeColor = Color.White;
            closeButton.Name = "closeButton";
            closeButton.TabStop = false;
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += CloseButton_Click;
            // 
            // BannerPanel
            // 
            resources.ApplyResources(BannerPanel, "BannerPanel");
            BannerPanel.BorderStyle = BorderStyle.FixedSingle;
            BannerPanel.Name = "BannerPanel";
            // 
            // startingPanel1
            // 
            startingPanel1.BorderStyle = BorderStyle.FixedSingle;
            startingPanel1.Controls.Add(label1);
            startingPanel1.Controls.Add(label7);
            startingPanel1.Controls.Add(label8);
            startingPanel1.Controls.Add(label6);
            startingPanel1.Controls.Add(label5);
            resources.ApplyResources(startingPanel1, "startingPanel1");
            startingPanel1.Name = "startingPanel1";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.ForeColor = Color.White;
            label7.Name = "label7";
            // 
            // label8
            // 
            label8.FlatStyle = FlatStyle.Flat;
            resources.ApplyResources(label8, "label8");
            label8.ForeColor = Color.White;
            label8.Name = "label8";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.ForeColor = Color.White;
            label6.Name = "label6";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.White;
            label1.Name = "label1";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.ForeColor = Color.White;
            label5.Name = "label5";
            // 
            // dbOrTxtPanel2
            // 
            dbOrTxtPanel2.BorderStyle = BorderStyle.FixedSingle;
            dbOrTxtPanel2.Controls.Add(sourceTypeGroupBox);
            dbOrTxtPanel2.Controls.Add(label4);
            resources.ApplyResources(dbOrTxtPanel2, "dbOrTxtPanel2");
            dbOrTxtPanel2.Name = "dbOrTxtPanel2";
            // 
            // sourceTypeGroupBox
            // 
            sourceTypeGroupBox.Controls.Add(radioButtonBD);
            sourceTypeGroupBox.Controls.Add(radioButtonTF);
            sourceTypeGroupBox.FlatStyle = FlatStyle.Flat;
            resources.ApplyResources(sourceTypeGroupBox, "sourceTypeGroupBox");
            sourceTypeGroupBox.ForeColor = Color.White;
            sourceTypeGroupBox.Name = "sourceTypeGroupBox";
            sourceTypeGroupBox.TabStop = false;
            sourceTypeGroupBox.Enter += SourceTypeGroupBox_Enter;
            // 
            // radioButtonBD
            // 
            resources.ApplyResources(radioButtonBD, "radioButtonBD");
            radioButtonBD.Cursor = Cursors.Hand;
            radioButtonBD.ForeColor = Color.White;
            radioButtonBD.Name = "radioButtonBD";
            radioButtonBD.TabStop = true;
            radioButtonBD.UseVisualStyleBackColor = true;
            // 
            // radioButtonTF
            // 
            resources.ApplyResources(radioButtonTF, "radioButtonTF");
            radioButtonTF.Cursor = Cursors.Hand;
            radioButtonTF.ForeColor = Color.White;
            radioButtonTF.Name = "radioButtonTF";
            radioButtonTF.TabStop = true;
            radioButtonTF.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.ForeColor = Color.White;
            label4.Name = "label4";
            // 
            // txtActionPanel4
            // 
            txtActionPanel4.BorderStyle = BorderStyle.FixedSingle;
            txtActionPanel4.Controls.Add(textFileTypeGroupBox);
            txtActionPanel4.Controls.Add(label10);
            resources.ApplyResources(txtActionPanel4, "txtActionPanel4");
            txtActionPanel4.Name = "txtActionPanel4";
            // 
            // textFileTypeGroupBox
            // 
            textFileTypeGroupBox.Controls.Add(radioButtonNewFT);
            textFileTypeGroupBox.Controls.Add(radioButtonOldFT);
            textFileTypeGroupBox.FlatStyle = FlatStyle.Flat;
            resources.ApplyResources(textFileTypeGroupBox, "textFileTypeGroupBox");
            textFileTypeGroupBox.ForeColor = Color.White;
            textFileTypeGroupBox.Name = "textFileTypeGroupBox";
            textFileTypeGroupBox.TabStop = false;
            textFileTypeGroupBox.Enter += SourceTypeGroupBox_Enter;
            // 
            // radioButtonNewFT
            // 
            resources.ApplyResources(radioButtonNewFT, "radioButtonNewFT");
            radioButtonNewFT.Cursor = Cursors.Hand;
            radioButtonNewFT.ForeColor = Color.White;
            radioButtonNewFT.Name = "radioButtonNewFT";
            radioButtonNewFT.TabStop = true;
            radioButtonNewFT.UseVisualStyleBackColor = true;
            // 
            // radioButtonOldFT
            // 
            resources.ApplyResources(radioButtonOldFT, "radioButtonOldFT");
            radioButtonOldFT.Cursor = Cursors.Hand;
            radioButtonOldFT.ForeColor = Color.White;
            radioButtonOldFT.Name = "radioButtonOldFT";
            radioButtonOldFT.TabStop = true;
            radioButtonOldFT.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.BorderStyle = BorderStyle.FixedSingle;
            label10.ForeColor = Color.White;
            label10.Name = "label10";
            // 
            // dbActionPanel3
            // 
            dbActionPanel3.BorderStyle = BorderStyle.FixedSingle;
            dbActionPanel3.Controls.Add(BDActionGroupBox);
            dbActionPanel3.Controls.Add(label11);
            dbActionPanel3.Controls.Add(label12);
            resources.ApplyResources(dbActionPanel3, "dbActionPanel3");
            dbActionPanel3.Name = "dbActionPanel3";
            // 
            // BDActionGroupBox
            // 
            BDActionGroupBox.Controls.Add(radioButtonAddNewW);
            BDActionGroupBox.Controls.Add(radioButtonLearnAvaliableW);
            BDActionGroupBox.FlatStyle = FlatStyle.Flat;
            resources.ApplyResources(BDActionGroupBox, "BDActionGroupBox");
            BDActionGroupBox.ForeColor = Color.White;
            BDActionGroupBox.Name = "BDActionGroupBox";
            BDActionGroupBox.TabStop = false;
            BDActionGroupBox.Enter += SourceTypeGroupBox_Enter;
            // 
            // radioButtonAddNewW
            // 
            resources.ApplyResources(radioButtonAddNewW, "radioButtonAddNewW");
            radioButtonAddNewW.Cursor = Cursors.Hand;
            radioButtonAddNewW.ForeColor = Color.White;
            radioButtonAddNewW.Name = "radioButtonAddNewW";
            radioButtonAddNewW.TabStop = true;
            radioButtonAddNewW.UseVisualStyleBackColor = true;
            radioButtonAddNewW.CheckedChanged += RadioButtonAddNewW_CheckedChanged;
            // 
            // radioButtonLearnAvaliableW
            // 
            resources.ApplyResources(radioButtonLearnAvaliableW, "radioButtonLearnAvaliableW");
            radioButtonLearnAvaliableW.Cursor = Cursors.Hand;
            radioButtonLearnAvaliableW.ForeColor = Color.White;
            radioButtonLearnAvaliableW.Name = "radioButtonLearnAvaliableW";
            radioButtonLearnAvaliableW.TabStop = true;
            radioButtonLearnAvaliableW.UseVisualStyleBackColor = true;
            radioButtonLearnAvaliableW.CheckedChanged += RadioButtonLearnAvaliableW_CheckedChanged;
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.ForeColor = Color.White;
            label11.Name = "label11";
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.BorderStyle = BorderStyle.FixedSingle;
            label12.ForeColor = Color.White;
            label12.Name = "label12";
            // 
            // wAddingPanel5
            // 
            wAddingPanel5.BorderStyle = BorderStyle.FixedSingle;
            wAddingPanel5.Controls.Add(EngTextBox);
            wAddingPanel5.Controls.Add(CancelPrevButton);
            wAddingPanel5.Controls.Add(AddWButton);
            wAddingPanel5.Controls.Add(label16);
            wAddingPanel5.Controls.Add(UaTextBox);
            wAddingPanel5.Controls.Add(label15);
            wAddingPanel5.Controls.Add(label13);
            wAddingPanel5.Controls.Add(label14);
            resources.ApplyResources(wAddingPanel5, "wAddingPanel5");
            wAddingPanel5.Name = "wAddingPanel5";
            // 
            // EngTextBox
            // 
            EngTextBox.BackColor = Color.FromArgb(90, 90, 90);
            EngTextBox.Cursor = Cursors.IBeam;
            resources.ApplyResources(EngTextBox, "EngTextBox");
            EngTextBox.ForeColor = Color.White;
            EngTextBox.Name = "EngTextBox";
            EngTextBox.TabStop = false;
            EngTextBox.TextChanged += EngUaTextBox_TextChanged;
            EngTextBox.KeyPress += EngTextBox_KeyPress;
            // 
            // CancelPrevButton
            // 
            CancelPrevButton.BackColor = SystemColors.WindowFrame;
            CancelPrevButton.Cursor = Cursors.Hand;
            resources.ApplyResources(CancelPrevButton, "CancelPrevButton");
            CancelPrevButton.FlatAppearance.BorderColor = Color.Gray;
            CancelPrevButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            CancelPrevButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            CancelPrevButton.ForeColor = Color.White;
            CancelPrevButton.Name = "CancelPrevButton";
            CancelPrevButton.TabStop = false;
            CancelPrevButton.UseVisualStyleBackColor = false;
            CancelPrevButton.Click += CancelPrevButton_Click;
            // 
            // AddWButton
            // 
            AddWButton.BackColor = SystemColors.WindowFrame;
            AddWButton.Cursor = Cursors.Hand;
            resources.ApplyResources(AddWButton, "AddWButton");
            AddWButton.FlatAppearance.BorderColor = Color.Gray;
            AddWButton.FlatAppearance.MouseDownBackColor = SystemColors.WindowFrame;
            AddWButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            AddWButton.ForeColor = Color.White;
            AddWButton.Name = "AddWButton";
            AddWButton.TabStop = false;
            AddWButton.UseVisualStyleBackColor = false;
            AddWButton.Click += AddWButton_Click;
            // 
            // label16
            // 
            resources.ApplyResources(label16, "label16");
            label16.ForeColor = Color.White;
            label16.Name = "label16";
            // 
            // UaTextBox
            // 
            UaTextBox.AcceptsReturn = true;
            UaTextBox.BackColor = Color.FromArgb(90, 90, 90);
            UaTextBox.Cursor = Cursors.IBeam;
            resources.ApplyResources(UaTextBox, "UaTextBox");
            UaTextBox.ForeColor = Color.White;
            UaTextBox.Name = "UaTextBox";
            UaTextBox.TabStop = false;
            UaTextBox.TextChanged += EngUaTextBox_TextChanged;
            UaTextBox.KeyPress += UaTextBox_KeyPress;
            // 
            // label15
            // 
            resources.ApplyResources(label15, "label15");
            label15.ForeColor = Color.White;
            label15.Name = "label15";
            // 
            // label13
            // 
            resources.ApplyResources(label13, "label13");
            label13.ForeColor = Color.White;
            label13.Name = "label13";
            // 
            // label14
            // 
            resources.ApplyResources(label14, "label14");
            label14.BorderStyle = BorderStyle.FixedSingle;
            label14.ForeColor = Color.White;
            label14.Name = "label14";
            // 
            // SetUpForm
            // 
            AcceptButton = continueButton;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(50, 50, 50);
            resources.ApplyResources(this, "$this");
            CancelButton = goBackButton;
            Controls.Add(BannerPanel);
            Controls.Add(closeButton);
            Controls.Add(TopPanel);
            Controls.Add(BottomPanel);
            Controls.Add(dbOrTxtPanel2);
            Controls.Add(startingPanel1);
            Controls.Add(wAddingPanel5);
            Controls.Add(dbActionPanel3);
            Controls.Add(txtActionPanel4);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "SetUpForm";
            Load += SetUpForm_Load;
            BottomPanel.ResumeLayout(false);
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            startingPanel1.ResumeLayout(false);
            startingPanel1.PerformLayout();
            dbOrTxtPanel2.ResumeLayout(false);
            dbOrTxtPanel2.PerformLayout();
            sourceTypeGroupBox.ResumeLayout(false);
            sourceTypeGroupBox.PerformLayout();
            txtActionPanel4.ResumeLayout(false);
            txtActionPanel4.PerformLayout();
            textFileTypeGroupBox.ResumeLayout(false);
            textFileTypeGroupBox.PerformLayout();
            dbActionPanel3.ResumeLayout(false);
            dbActionPanel3.PerformLayout();
            BDActionGroupBox.ResumeLayout(false);
            BDActionGroupBox.PerformLayout();
            wAddingPanel5.ResumeLayout(false);
            wAddingPanel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel BottomPanel;
        private Button continueButton;
        private Button goBackButton;
        private Label label3;
        private Panel TopPanel;
        private Button closeButton;
        private Panel BannerPanel;
        private Panel startingPanel1;
        private Label label7;
        private Label label8;
        private Label label6;
        private Label label1;
        private Label label5;
        private Panel dbOrTxtPanel2;
        private GroupBox sourceTypeGroupBox;
        private RadioButton radioButtonBD;
        private RadioButton radioButtonTF;
        private Label label4;
        private Panel txtActionPanel4;
        private GroupBox textFileTypeGroupBox;
        private RadioButton radioButtonNewFT;
        private RadioButton radioButtonOldFT;
        private Label label10;
        private Panel dbActionPanel3;
        private GroupBox BDActionGroupBox;
        private RadioButton radioButtonAddNewW;
        private RadioButton radioButtonLearnAvaliableW;
        private Label label11;
        private Label label12;
        private Panel wAddingPanel5;
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