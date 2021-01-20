namespace Lastpoints
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.Game = new System.Windows.Forms.ToolStripMenuItem();
            this.Restart = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.Info = new System.Windows.Forms.ToolStripMenuItem();
            this.Spravka = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.Menu;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Game,
            this.Spravka});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(584, 24);
            this.menu.TabIndex = 5;
            this.menu.Text = "menuStrip1";
            // 
            // Game
            // 
            this.Game.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Restart,
            this.Settings,
            this.Info});
            this.Game.Name = "Game";
            this.Game.Size = new System.Drawing.Size(46, 20);
            this.Game.Text = "Игра";
            // 
            // Restart
            // 
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(169, 22);
            this.Restart.Text = "Начать заново";
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // Settings
            // 
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(169, 22);
            this.Settings.Text = "Параметры игры";
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // Info
            // 
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(169, 22);
            this.Info.Text = "О программе";
            this.Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // Spravka
            // 
            this.Spravka.Name = "Spravka";
            this.Spravka.Size = new System.Drawing.Size(65, 20);
            this.Spravka.Text = "Справка";
            this.Spravka.Click += new System.EventHandler(this.Spravka_Click);
            // 
            // InfoLabel
            // 
            this.InfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.BackColor = System.Drawing.SystemColors.Menu;
            this.InfoLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InfoLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.InfoLabel.Location = new System.Drawing.Point(865, 3);
            this.InfoLabel.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.InfoLabel.Size = new System.Drawing.Size(44, 19);
            this.InfoLabel.TabIndex = 6;
            this.InfoLabel.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "Form1";
            this.Text = "Точки";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem Game;
        private System.Windows.Forms.ToolStripMenuItem Restart;
        private System.Windows.Forms.ToolStripMenuItem Settings;
        private System.Windows.Forms.ToolStripMenuItem Info;
        private System.Windows.Forms.ToolStripMenuItem Spravka;
        private System.Windows.Forms.Label InfoLabel;
    }
}

