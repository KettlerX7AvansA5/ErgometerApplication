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
            this.panelClientContainer = new System.Windows.Forms.Panel();
            this.panelFullscreenView = new System.Windows.Forms.Panel();
            this.panelClientDataView = new ErgometerApplication.PanelClientDataView();
            this.panelClientChat = new ErgometerApplication.PanelClientChat();
            this.panelLogin = new ErgometerApplication.PanelLogin(this);
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.buttonLogOff = new System.Windows.Forms.Button();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelHallo = new System.Windows.Forms.Label();
            this.panelClientContainer.SuspendLayout();
            this.panelTopBar.SuspendLayout();
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
            // panelClientContainer
            // 
            this.panelClientContainer.Controls.Add(this.panelFullscreenView);
            this.panelClientContainer.Controls.Add(this.panelClientDataView);
            this.panelClientContainer.Controls.Add(this.panelClientChat);
            this.panelClientContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClientContainer.Location = new System.Drawing.Point(0, 0);
            this.panelClientContainer.Name = "panelClientContainer";
            this.panelClientContainer.Size = new System.Drawing.Size(800, 600);
            this.panelClientContainer.TabIndex = 0;
            // 
            // panelFullscreenView
            // 
            this.panelFullscreenView.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelFullscreenView.Location = new System.Drawing.Point(0, 0);
            this.panelFullscreenView.Name = "panelFullscreenView";
            this.panelFullscreenView.Size = new System.Drawing.Size(18, 600);
            this.panelFullscreenView.TabIndex = 3;
            this.panelFullscreenView.BackColor = System.Drawing.Color.Gray;
            // 
            // panelClientDataView
            // 
            this.panelClientDataView.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelClientDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClientDataView.Location = new System.Drawing.Point(0, 0);
            this.panelClientDataView.Name = "panelClientDataView";
            this.panelClientDataView.Size = new System.Drawing.Size(400, 600);
            this.panelClientDataView.TabIndex = 1;
            // 
            // panelClientChat
            // 
            this.panelClientChat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelClientChat.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelClientChat.Location = new System.Drawing.Point(400, 0);
            this.panelClientChat.Name = "panelClientChat";
            this.panelClientChat.Size = new System.Drawing.Size(400, 600);
            this.panelClientChat.TabIndex = 2;
            // 
            // panelTopBar
            // 
            this.panelTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelTopBar.Controls.Add(this.buttonLogOff);
            this.panelTopBar.Controls.Add(this.labelUsername);
            this.panelTopBar.Controls.Add(this.labelHallo);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(800, 30);
            this.panelTopBar.TabIndex = 1;
            this.panelTopBar.Visible = false;
            // 
            // buttonLogOff
            // 
            this.buttonLogOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonLogOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogOff.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogOff.Location = new System.Drawing.Point(722, 3);
            this.buttonLogOff.Name = "buttonLogOff";
            this.buttonLogOff.Size = new System.Drawing.Size(75, 23);
            this.buttonLogOff.TabIndex = 1;
            this.buttonLogOff.Text = "Afmelden";
            this.buttonLogOff.UseVisualStyleBackColor = false;
            this.buttonLogOff.Click += new System.EventHandler(this.buttonLogOff_Click);
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.Color.White;
            this.labelUsername.Location = new System.Drawing.Point(49, 3);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(144, 21);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "<Gebruikersnaam>";
            // 
            // labelHallo
            // 
            this.labelHallo.AutoSize = true;
            this.labelHallo.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.labelHallo.ForeColor = System.Drawing.Color.White;
            this.labelHallo.Location = new System.Drawing.Point(3, 3);
            this.labelHallo.Name = "labelHallo";
            this.labelHallo.Size = new System.Drawing.Size(54, 21);
            this.labelHallo.TabIndex = 0;
            this.labelHallo.Text = "Hallo, ";
            // 
            // ClientApplicatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelTopBar);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.panelClientContainer);
            this.Name = "ClientApplicatie";
            this.Text = "Client Applicatie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.ClientApplicatie_Resize);
            this.panelClientContainer.ResumeLayout(false);
            this.panelTopBar.ResumeLayout(false);
            this.panelTopBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer writeTimer;
        private System.Windows.Forms.Panel panelClientContainer;
        private PanelClientChat panelClientChat;
        private PanelClientDataView panelClientDataView;
        private PanelLogin panelLogin;
        private System.Windows.Forms.Panel panelFullscreenView;
        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Button buttonLogOff;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelHallo;
    }
}
