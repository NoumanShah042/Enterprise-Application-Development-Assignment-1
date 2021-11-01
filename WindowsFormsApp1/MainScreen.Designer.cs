
namespace WindowsFormsApp1
{
    partial class MainScreen
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
            this.newUserBtn = new System.Windows.Forms.Button();
            this.ExistingUserBtn = new System.Windows.Forms.Button();
            this.AdminBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newUserBtn
            // 
            this.newUserBtn.Location = new System.Drawing.Point(221, 106);
            this.newUserBtn.Name = "newUserBtn";
            this.newUserBtn.Size = new System.Drawing.Size(150, 50);
            this.newUserBtn.TabIndex = 0;
            this.newUserBtn.Text = "New User";
            this.newUserBtn.UseVisualStyleBackColor = true;
            this.newUserBtn.Click += new System.EventHandler(this.newUserBtn_Click);
            // 
            // ExistingUserBtn
            // 
            this.ExistingUserBtn.Location = new System.Drawing.Point(221, 178);
            this.ExistingUserBtn.Name = "ExistingUserBtn";
            this.ExistingUserBtn.Size = new System.Drawing.Size(150, 50);
            this.ExistingUserBtn.TabIndex = 1;
            this.ExistingUserBtn.Text = "Existing User";
            this.ExistingUserBtn.UseVisualStyleBackColor = true;
            this.ExistingUserBtn.Click += new System.EventHandler(this.ExistingUserBtn_Click);
            // 
            // AdminBtn
            // 
            this.AdminBtn.Location = new System.Drawing.Point(221, 248);
            this.AdminBtn.Name = "AdminBtn";
            this.AdminBtn.Size = new System.Drawing.Size(150, 50);
            this.AdminBtn.TabIndex = 2;
            this.AdminBtn.Text = "Admin";
            this.AdminBtn.UseVisualStyleBackColor = true;
            this.AdminBtn.Click += new System.EventHandler(this.AdminBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(221, 321);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(150, 50);
            this.ExitBtn.TabIndex = 3;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 496);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.AdminBtn);
            this.Controls.Add(this.ExistingUserBtn);
            this.Controls.Add(this.newUserBtn);
            this.Name = "MainScreen";
            this.Text = "Main Screen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newUserBtn;
        private System.Windows.Forms.Button ExistingUserBtn;
        private System.Windows.Forms.Button AdminBtn;
        private System.Windows.Forms.Button ExitBtn;
    }
}

