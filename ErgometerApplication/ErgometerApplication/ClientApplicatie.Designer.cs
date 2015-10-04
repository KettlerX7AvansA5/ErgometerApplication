using System.IO.Ports;

namespace ErgometerApplication
{
    partial class ClientApplicatie
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
            this.components = new System.ComponentModel.Container();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.writeTimer = new System.Windows.Forms.Timer(this.components);
            this.panelLogin = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 1500;
            // 
            // writeTimer
            // 
            this.writeTimer.Interval = 10000;
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.lblUsername);
            this.panelLogin.Controls.Add(this.lblPassword);
            this.panelLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogin.Location = new System.Drawing.Point(0, 0);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(800, 600);
            this.panelLogin.TabIndex = 0;
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(243, 255);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(84, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Gebruikersnaam";
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(243, 291);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(68, 13);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Wachtwoord";
            // 
            // ClientApplicatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelLogin);
            this.Name = "ClientApplicatie";
            this.Text = "Client Applicatie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer writeTimer;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
    }
}
