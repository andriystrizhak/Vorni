namespace Eng_Flash_Cards_Learner.Forms.ChildForms
{
    partial class StartInfo
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            CloseSettingsButton = new Guna.UI2.WinForms.Guna2CircleButton();
            CloseButton = new Guna.UI2.WinForms.Guna2Button();
            FadeInTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // CloseSettingsButton
            // 
            CloseSettingsButton.BackgroundImageLayout = ImageLayout.Zoom;
            CloseSettingsButton.BorderColor = Color.FromArgb(24, 27, 32);
            CloseSettingsButton.BorderThickness = 1;
            CloseSettingsButton.CheckedState.BorderColor = Color.FromArgb(53, 60, 68);
            CloseSettingsButton.CheckedState.FillColor = Color.FromArgb(53, 60, 68);
            CloseSettingsButton.DisabledState.BorderColor = Color.DarkGray;
            CloseSettingsButton.DisabledState.CustomBorderColor = Color.DarkGray;
            CloseSettingsButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            CloseSettingsButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            CloseSettingsButton.FillColor = Color.FromArgb(24, 27, 32);
            CloseSettingsButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CloseSettingsButton.ForeColor = Color.White;
            CloseSettingsButton.HoverState.BorderColor = Color.FromArgb(24, 27, 32);
            CloseSettingsButton.HoverState.FillColor = Color.FromArgb(24, 27, 32);
            CloseSettingsButton.HoverState.Image = Resource1.icons8_удалить_2;
            CloseSettingsButton.Image = Resource1.icons8_удалить_60;
            CloseSettingsButton.ImageSize = new Size(22, 22);
            CloseSettingsButton.Location = new Point(361, 12);
            CloseSettingsButton.Name = "CloseSettingsButton";
            CloseSettingsButton.PressedColor = Color.FromArgb(57, 64, 72);
            CloseSettingsButton.ShadowDecoration.CustomizableEdges = customizableEdges1;
            CloseSettingsButton.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            CloseSettingsButton.Size = new Size(40, 38);
            CloseSettingsButton.TabIndex = 119;
            CloseSettingsButton.TabStop = false;
            CloseSettingsButton.Visible = false;
            // 
            // CloseButton
            // 
            CloseButton.BackgroundImage = Resource1.closeoutline_4;
            CloseButton.BackgroundImageLayout = ImageLayout.Center;
            CloseButton.CheckedState.FillColor = Color.FromArgb(238, 22, 40);
            CloseButton.CustomizableEdges = customizableEdges2;
            CloseButton.DisabledState.BorderColor = Color.DarkGray;
            CloseButton.DisabledState.CustomBorderColor = Color.DarkGray;
            CloseButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            CloseButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            CloseButton.FillColor = Color.FromArgb(138, 44, 254);
            CloseButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CloseButton.ForeColor = Color.White;
            CloseButton.HoverState.FillColor = Color.FromArgb(108, 34, 214);
            CloseButton.Image = Resource1.closeoutline_4;
            CloseButton.ImageSize = new Size(45, 45);
            CloseButton.Location = new Point(514, 1);
            CloseButton.Name = "CloseButton";
            CloseButton.PressedColor = Color.FromArgb(238, 22, 40);
            CloseButton.ShadowDecoration.CustomizableEdges = customizableEdges3;
            CloseButton.Size = new Size(50, 50);
            CloseButton.TabIndex = 120;
            CloseButton.Click += CloseButton_Click;
            // 
            // FadeInTimer
            // 
            FadeInTimer.Interval = 10;
            FadeInTimer.Tick += FadeInTimer_Tick;
            // 
            // StartInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.start_1_0;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(564, 620);
            Controls.Add(CloseButton);
            Controls.Add(CloseSettingsButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StartInfo";
            Opacity = 0D;
            Text = "StartInfo";
            Load += SettingForm_Load;
            Shown += StartInfoForm_Shown;
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CircleButton CloseSettingsButton;
        private Guna.UI2.WinForms.Guna2Button CloseButton;
        private System.Windows.Forms.Timer FadeInTimer;
    }
}