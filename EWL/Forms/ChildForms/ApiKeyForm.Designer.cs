namespace Eng_Flash_Cards_Learner.Forms.ChildForms
{
    partial class ApiKeyForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            ApiKeyTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            ApiKeyPanel = new Guna.UI2.WinForms.Guna2Panel();
            CancelButton = new Guna.UI2.WinForms.Guna2Button();
            SaveApiKeyButton = new Guna.UI2.WinForms.Guna2Button();
            ApiKeyFormElipse = new Guna.UI2.WinForms.Guna2Elipse(components);
            ApiKeyAddingReportPopup = new Tulpep.NotificationWindow.PopupNotifier();
            ApiKeyPanel.SuspendLayout();
            SuspendLayout();
            // 
            // ApiKeyTextBox
            // 
            ApiKeyTextBox.BorderColor = Color.FromArgb(74, 84, 93);
            ApiKeyTextBox.BorderRadius = 14;
            ApiKeyTextBox.CustomizableEdges = customizableEdges1;
            ApiKeyTextBox.DefaultText = "";
            ApiKeyTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            ApiKeyTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            ApiKeyTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            ApiKeyTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            ApiKeyTextBox.FillColor = Color.FromArgb(24, 27, 32);
            ApiKeyTextBox.FocusedState.BorderColor = Color.FromArgb(170, 101, 254);
            ApiKeyTextBox.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ApiKeyTextBox.ForeColor = Color.White;
            ApiKeyTextBox.HoverState.BorderColor = Color.FromArgb(170, 101, 254);
            ApiKeyTextBox.Location = new Point(24, 22);
            ApiKeyTextBox.Margin = new Padding(6, 10, 6, 10);
            ApiKeyTextBox.Name = "ApiKeyTextBox";
            ApiKeyTextBox.PasswordChar = '\0';
            ApiKeyTextBox.PlaceholderForeColor = Color.FromArgb(147, 166, 181);
            ApiKeyTextBox.PlaceholderText = "Введи сюди GPT API ключ";
            ApiKeyTextBox.SelectedText = "";
            ApiKeyTextBox.ShadowDecoration.CustomizableEdges = customizableEdges2;
            ApiKeyTextBox.Size = new Size(476, 35);
            ApiKeyTextBox.TabIndex = 1;
            ApiKeyTextBox.TextAlign = HorizontalAlignment.Center;
            ApiKeyTextBox.TextOffset = new Point(0, 1);
            ApiKeyTextBox.TextChanged += ApiKeyTextBox_TextChanged;
            ApiKeyTextBox.KeyDown += Enter_KeyDown;
            // 
            // ApiKeyPanel
            // 
            ApiKeyPanel.BackColor = Color.FromArgb(24, 27, 32);
            ApiKeyPanel.BorderColor = Color.FromArgb(77, 87, 96);
            ApiKeyPanel.BorderRadius = 17;
            ApiKeyPanel.BorderThickness = 1;
            ApiKeyPanel.Controls.Add(CancelButton);
            ApiKeyPanel.Controls.Add(SaveApiKeyButton);
            ApiKeyPanel.Controls.Add(ApiKeyTextBox);
            ApiKeyPanel.CustomizableEdges = customizableEdges7;
            ApiKeyPanel.FillColor = Color.FromArgb(24, 27, 32);
            ApiKeyPanel.Location = new Point(0, 0);
            ApiKeyPanel.Name = "ApiKeyPanel";
            ApiKeyPanel.ShadowDecoration.CustomizableEdges = customizableEdges8;
            ApiKeyPanel.Size = new Size(524, 139);
            ApiKeyPanel.TabIndex = 3;
            ApiKeyPanel.Visible = false;
            // 
            // CancelButton
            // 
            CancelButton.Animated = true;
            CancelButton.BorderColor = Color.FromArgb(24, 27, 32);
            CancelButton.BorderRadius = 15;
            CancelButton.BorderThickness = 1;
            CancelButton.CheckedState.BorderColor = Color.FromArgb(170, 101, 254);
            CancelButton.CheckedState.FillColor = Color.FromArgb(30, 1, 70);
            CancelButton.CustomizableEdges = customizableEdges3;
            CancelButton.DisabledState.BorderColor = Color.FromArgb(24, 27, 32);
            CancelButton.DisabledState.CustomBorderColor = Color.FromArgb(24, 27, 32);
            CancelButton.DisabledState.FillColor = Color.FromArgb(24, 27, 32);
            CancelButton.DisabledState.ForeColor = Color.DimGray;
            CancelButton.FillColor = Color.FromArgb(24, 27, 32);
            CancelButton.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            CancelButton.ForeColor = Color.White;
            CancelButton.HoverState.BorderColor = Color.FromArgb(170, 101, 254);
            CancelButton.HoverState.FillColor = Color.FromArgb(33, 38, 42);
            CancelButton.Location = new Point(107, 78);
            CancelButton.Name = "CancelButton";
            CancelButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            CancelButton.Size = new Size(110, 40);
            CancelButton.TabIndex = 3;
            CancelButton.Text = "Скасувати";
            CancelButton.TextOffset = new Point(0, -1);
            CancelButton.Click += CancelButton_Click;
            // 
            // SaveApiKeyButton
            // 
            SaveApiKeyButton.Animated = true;
            SaveApiKeyButton.BorderColor = Color.FromArgb(138, 44, 254);
            SaveApiKeyButton.BorderRadius = 15;
            SaveApiKeyButton.BorderThickness = 1;
            SaveApiKeyButton.CustomizableEdges = customizableEdges5;
            SaveApiKeyButton.DisabledState.BorderColor = Color.FromArgb(73, 1, 116);
            SaveApiKeyButton.DisabledState.CustomBorderColor = Color.FromArgb(73, 1, 116);
            SaveApiKeyButton.DisabledState.FillColor = Color.FromArgb(73, 1, 116);
            SaveApiKeyButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            SaveApiKeyButton.Enabled = false;
            SaveApiKeyButton.FillColor = Color.FromArgb(138, 44, 254);
            SaveApiKeyButton.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SaveApiKeyButton.ForeColor = Color.White;
            SaveApiKeyButton.Location = new Point(305, 78);
            SaveApiKeyButton.Name = "SaveApiKeyButton";
            SaveApiKeyButton.ShadowDecoration.CustomizableEdges = customizableEdges6;
            SaveApiKeyButton.Size = new Size(110, 40);
            SaveApiKeyButton.TabIndex = 2;
            SaveApiKeyButton.Text = "Зберегти";
            SaveApiKeyButton.TextOffset = new Point(0, -1);
            SaveApiKeyButton.Click += SaveApiKeyButton_Click;
            // 
            // ApiKeyFormElipse
            // 
            ApiKeyFormElipse.BorderRadius = 31;
            // 
            // ApiKeyAddingReportPopup
            // 
            ApiKeyAddingReportPopup.BodyColor = Color.FromArgb(24, 27, 32);
            ApiKeyAddingReportPopup.BorderColor = Color.FromArgb(74, 84, 93);
            ApiKeyAddingReportPopup.ButtonBorderColor = Color.FromArgb(74, 84, 93);
            ApiKeyAddingReportPopup.ButtonHoverColor = Color.FromArgb(19, 22, 27);
            ApiKeyAddingReportPopup.ContentColor = Color.White;
            ApiKeyAddingReportPopup.ContentFont = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ApiKeyAddingReportPopup.ContentHoverColor = SystemColors.ControlLight;
            ApiKeyAddingReportPopup.ContentPadding = new Padding(30, 6, 0, 0);
            ApiKeyAddingReportPopup.ContentText = "API-ключ успішно доданий!";
            ApiKeyAddingReportPopup.Delay = 5000;
            ApiKeyAddingReportPopup.GradientPower = 0;
            ApiKeyAddingReportPopup.HeaderColor = Color.FromArgb(26, 180, 145);
            ApiKeyAddingReportPopup.HeaderHeight = 12;
            ApiKeyAddingReportPopup.Image = Resource1.Untitled_3_1;
            ApiKeyAddingReportPopup.ImagePadding = new Padding(2, 9, 0, 0);
            ApiKeyAddingReportPopup.ImageSize = new Size(125, 50);
            ApiKeyAddingReportPopup.IsRightToLeft = false;
            ApiKeyAddingReportPopup.OptionsMenu = null;
            ApiKeyAddingReportPopup.Size = new Size(445, 85);
            ApiKeyAddingReportPopup.TitleColor = Color.White;
            ApiKeyAddingReportPopup.TitleFont = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ApiKeyAddingReportPopup.TitleText = "";
            // 
            // ApiKeyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 27, 32);
            ClientSize = new Size(525, 140);
            Controls.Add(ApiKeyPanel);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "ApiKeyForm";
            Text = "ApiKeyForm";
            Activated += SettingForm_Activated;
            Deactivate += SettingForm_Deactivate;
            Load += SettingForm_Load;
            Shown += SettingForm_Shown;
            ApiKeyPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox ApiKeyTextBox;
        private Guna.UI2.WinForms.Guna2Panel ApiKeyPanel;
        private Guna.UI2.WinForms.Guna2Button CancelButton;
        private Guna.UI2.WinForms.Guna2Button SaveApiKeyButton;
        private Guna.UI2.WinForms.Guna2Elipse ApiKeyFormElipse;
        private Tulpep.NotificationWindow.PopupNotifier ApiKeyAddingReportPopup;
    }
}