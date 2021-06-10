namespace ClientApp
{
    partial class SubjectFrm
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
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_desc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_credits = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_hours = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_code = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_credits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hours)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(97, 30);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(195, 20);
            this.textBox_name.TabIndex = 1;
            // 
            // textBox_desc
            // 
            this.textBox_desc.Location = new System.Drawing.Point(97, 56);
            this.textBox_desc.Multiline = true;
            this.textBox_desc.Name = "textBox_desc";
            this.textBox_desc.Size = new System.Drawing.Size(195, 75);
            this.textBox_desc.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Credits:";
            // 
            // numericUpDown_credits
            // 
            this.numericUpDown_credits.Location = new System.Drawing.Point(97, 163);
            this.numericUpDown_credits.Name = "numericUpDown_credits";
            this.numericUpDown_credits.Size = new System.Drawing.Size(82, 20);
            this.numericUpDown_credits.TabIndex = 6;
            // 
            // numericUpDown_hours
            // 
            this.numericUpDown_hours.Location = new System.Drawing.Point(97, 189);
            this.numericUpDown_hours.Name = "numericUpDown_hours";
            this.numericUpDown_hours.Size = new System.Drawing.Size(82, 20);
            this.numericUpDown_hours.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Hours:";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(250, 203);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 9;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Code:";
            // 
            // textBox_code
            // 
            this.textBox_code.Location = new System.Drawing.Point(97, 137);
            this.textBox_code.Name = "textBox_code";
            this.textBox_code.Size = new System.Drawing.Size(195, 20);
            this.textBox_code.TabIndex = 5;
            // 
            // SubjectFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 258);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.numericUpDown_hours);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown_credits);
            this.Controls.Add(this.textBox_code);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_desc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label1);
            this.Name = "SubjectFrm";
            this.Text = "Add Subject";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_credits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_desc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_credits;
        private System.Windows.Forms.NumericUpDown numericUpDown_hours;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_code;
    }
}