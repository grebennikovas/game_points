namespace Lastpoints
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.SizeX = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SizeY = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Sizers = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Размер поля";
            // 
            // SizeX
            // 
            this.SizeX.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.SizeX.Location = new System.Drawing.Point(118, 30);
            this.SizeX.Margin = new System.Windows.Forms.Padding(0);
            this.SizeX.Mask = "00";
            this.SizeX.Name = "SizeX";
            this.SizeX.Size = new System.Drawing.Size(21, 25);
            this.SizeX.TabIndex = 2;
            this.SizeX.Text = "39";
            this.SizeX.ValidatingType = typeof(int);
            this.SizeX.TextChanged += new System.EventHandler(this.SizeX_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(142, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "x";
            // 
            // SizeY
            // 
            this.SizeY.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.SizeY.Location = new System.Drawing.Point(160, 30);
            this.SizeY.Margin = new System.Windows.Forms.Padding(0);
            this.SizeY.Mask = "00";
            this.SizeY.Name = "SizeY";
            this.SizeY.Size = new System.Drawing.Size(22, 25);
            this.SizeY.TabIndex = 4;
            this.SizeY.Text = "32";
            this.SizeY.ValidatingType = typeof(int);
            this.SizeY.TextChanged += new System.EventHandler(this.SizeY_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(15, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Размеры";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(19, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "Начать игру";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Sizers
            // 
            this.Sizers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Sizers.FormattingEnabled = true;
            this.Sizers.Items.AddRange(new object[] {
            "Маленький",
            "Средний",
            "Большой"});
            this.Sizers.Location = new System.Drawing.Point(94, 66);
            this.Sizers.Name = "Sizers";
            this.Sizers.Size = new System.Drawing.Size(88, 25);
            this.Sizers.TabIndex = 8;
            this.Sizers.SelectedIndexChanged += new System.EventHandler(this.Sizers_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(204, 161);
            this.Controls.Add(this.Sizers);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SizeY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SizeX);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox SizeX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox SizeY;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox Sizers;
    }
}