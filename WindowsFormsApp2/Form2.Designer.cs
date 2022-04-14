namespace WindowsFormsApp2
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
            this.label2 = new System.Windows.Forms.Label();
            this.etunimi = new System.Windows.Forms.TextBox();
            this.sukunimi = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "etunimi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "sukunimi";
            // 
            // etunimi
            // 
            this.etunimi.Location = new System.Drawing.Point(211, 108);
            this.etunimi.Name = "etunimi";
            this.etunimi.Size = new System.Drawing.Size(100, 22);
            this.etunimi.TabIndex = 2;
            this.etunimi.TextChanged += new System.EventHandler(this.etunimi_TextChanged);
            // 
            // sukunimi
            // 
            this.sukunimi.Location = new System.Drawing.Point(211, 168);
            this.sukunimi.Name = "sukunimi";
            this.sukunimi.Size = new System.Drawing.Size(100, 22);
            this.sukunimi.TabIndex = 3;
            this.sukunimi.TextChanged += new System.EventHandler(this.sukunimi_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(404, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 313);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sukunimi);
            this.Controls.Add(this.etunimi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox etunimi;
        private System.Windows.Forms.TextBox sukunimi;
        private System.Windows.Forms.Button button1;
    }
}