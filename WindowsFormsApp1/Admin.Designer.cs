
namespace WindowsFormsApp1
{
    partial class Admin
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
            this.adminBtn = new System.Windows.Forms.Button();
            this.XML_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(155, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome Admin";
            // 
            // adminBtn
            // 
            this.adminBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminBtn.Location = new System.Drawing.Point(204, 175);
            this.adminBtn.Name = "adminBtn";
            this.adminBtn.Size = new System.Drawing.Size(135, 55);
            this.adminBtn.TabIndex = 1;
            this.adminBtn.Text = "Database";
            this.adminBtn.UseVisualStyleBackColor = true;
            this.adminBtn.Click += new System.EventHandler(this.adminBtn_Click);
            // 
            // XML_Btn
            // 
            this.XML_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.XML_Btn.Location = new System.Drawing.Point(204, 268);
            this.XML_Btn.Name = "XML_Btn";
            this.XML_Btn.Size = new System.Drawing.Size(135, 55);
            this.XML_Btn.TabIndex = 2;
            this.XML_Btn.Text = "XML File";
            this.XML_Btn.UseVisualStyleBackColor = true;
            this.XML_Btn.Click += new System.EventHandler(this.XML_Btn_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 430);
            this.Controls.Add(this.XML_Btn);
            this.Controls.Add(this.adminBtn);
            this.Controls.Add(this.label1);
            this.Name = "Admin";
            this.Text = "Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button adminBtn;
        private System.Windows.Forms.Button XML_Btn;
    }
}