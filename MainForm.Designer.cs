namespace MinecraftLauncher
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.button_Options = new System.Windows.Forms.Button();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Login = new System.Windows.Forms.TextBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_Error = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_JavaMemory = new System.Windows.Forms.TextBox();
            this.textBox_PersonalArgs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_ServerAddres = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.AllowNavigation = false;
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Top;
            this.webBrowser.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(784, 350);
            this.webBrowser.TabIndex = 10;
            this.webBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.BackgroundImage")));
            this.pictureBox.Image = global::MinecraftLauncher.Properties.Resources.logo;
            this.pictureBox.Location = new System.Drawing.Point(19, 370);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(256, 70);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.checkBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBox.BackgroundImage")));
            this.checkBox.ForeColor = System.Drawing.Color.Lime;
            this.checkBox.Location = new System.Drawing.Point(529, 434);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(121, 17);
            this.checkBox.TabIndex = 20;
            this.checkBox.Text = "Запомнить пароль";
            this.checkBox.UseVisualStyleBackColor = false;
            // 
            // button_Options
            // 
            this.button_Options.Location = new System.Drawing.Point(671, 370);
            this.button_Options.Name = "button_Options";
            this.button_Options.Size = new System.Drawing.Size(101, 23);
            this.button_Options.TabIndex = 15;
            this.button_Options.Text = "Опции";
            this.button_Options.UseVisualStyleBackColor = true;
            this.button_Options.Click += new System.EventHandler(this.button_Options_Click);
            // 
            // linkLabel
            // 
            this.linkLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkLabel.AutoSize = true;
            this.linkLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(32)))), ((int)(((byte)(22)))));
            this.linkLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkLabel.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkLabel.Location = new System.Drawing.Point(678, 435);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(91, 15);
            this.linkLabel.TabIndex = 25;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "Нужен аккаунт?";
            this.linkLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LawnGreen;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(467, 375);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "  Логин:";
            // 
            // textBox_Login
            // 
            this.textBox_Login.Location = new System.Drawing.Point(520, 372);
            this.textBox_Login.Name = "textBox_Login";
            this.textBox_Login.Size = new System.Drawing.Size(142, 20);
            this.textBox_Login.TabIndex = 1;
            this.textBox_Login.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Login_KeyDown);
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(671, 399);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(101, 23);
            this.button_Start.TabIndex = 3;
            this.button_Start.Text = "Вход";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(520, 401);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.Size = new System.Drawing.Size(142, 20);
            this.textBox_Password.TabIndex = 2;
            this.textBox_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Password_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.IndianRed;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(466, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Пароль:";
            // 
            // label_Error
            // 
            this.label_Error.BackColor = System.Drawing.SystemColors.Highlight;
            this.label_Error.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Error.Location = new System.Drawing.Point(292, 370);
            this.label_Error.Name = "label_Error";
            this.label_Error.Size = new System.Drawing.Size(167, 70);
            this.label_Error.TabIndex = 26;
            this.label_Error.Visible = false;
            this.label_Error.TextChanged += new System.EventHandler(this.label_Error_TextChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(0, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(785, 1);
            this.label3.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(184, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "               XMX (MB)";
            // 
            // textBox_JavaMemory
            // 
            this.textBox_JavaMemory.Location = new System.Drawing.Point(292, 75);
            this.textBox_JavaMemory.Name = "textBox_JavaMemory";
            this.textBox_JavaMemory.Size = new System.Drawing.Size(40, 20);
            this.textBox_JavaMemory.TabIndex = 29;
            this.textBox_JavaMemory.Text = "2048";
            this.textBox_JavaMemory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_PersonalArgs
            // 
            this.textBox_PersonalArgs.Location = new System.Drawing.Point(292, 111);
            this.textBox_PersonalArgs.Name = "textBox_PersonalArgs";
            this.textBox_PersonalArgs.Size = new System.Drawing.Size(184, 20);
            this.textBox_PersonalArgs.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(184, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "Прочие аргументы";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(710, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 15);
            this.label6.TabIndex = 32;
            this.label6.Text = "Version 1.3";
            // 
            // label_ServerAddres
            // 
            this.label_ServerAddres.AutoSize = true;
            this.label_ServerAddres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_ServerAddres.Location = new System.Drawing.Point(30, 320);
            this.label_ServerAddres.Name = "label_ServerAddres";
            this.label_ServerAddres.Size = new System.Drawing.Size(2, 15);
            this.label_ServerAddres.TabIndex = 33;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.label_Error);
            this.Controls.Add(this.label_ServerAddres);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_PersonalArgs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_JavaMemory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.textBox_Login);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.button_Options);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Minecraft Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Button button_Options;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Login;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_Error;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_JavaMemory;
        private System.Windows.Forms.TextBox textBox_PersonalArgs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_ServerAddres;

    }
}

