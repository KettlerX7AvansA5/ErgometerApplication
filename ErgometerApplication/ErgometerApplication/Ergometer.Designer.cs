using System.IO.Ports;

namespace ErgometerApplication
{
    partial class Ergometer
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.ComPortBox = new System.Windows.Forms.ComboBox();
            this.statusButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.timerStatus = new System.Windows.Forms.CheckBox();
            this.powerButton = new System.Windows.Forms.Button();
            this.timeButton = new System.Windows.Forms.Button();
            this.energyButton = new System.Windows.Forms.Button();
            this.distanceButton = new System.Windows.Forms.Button();
            this.writeTimer = new System.Windows.Forms.Timer(this.components);
            this.metingNextButton = new System.Windows.Forms.Button();
            this.metingBackButton = new System.Windows.Forms.Button();
            this.readButton = new System.Windows.Forms.Button();
            this.inputTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 42);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(203, 243);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(115, 290);
            this.connectButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(101, 26);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // ComPortBox
            // 
            this.ComPortBox.FormattingEnabled = true;
            this.ComPortBox.Items.AddRange(new object[] {
            "COM8",
            "COM9"});
            this.ComPortBox.Location = new System.Drawing.Point(12, 290);
            this.ComPortBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ComPortBox.Name = "ComPortBox";
            this.ComPortBox.Size = new System.Drawing.Size(97, 24);
            this.ComPortBox.TabIndex = 11;
            // 
            // statusButton
            // 
            this.statusButton.Enabled = false;
            this.statusButton.Location = new System.Drawing.Point(127, 12);
            this.statusButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statusButton.Name = "statusButton";
            this.statusButton.Size = new System.Drawing.Size(89, 26);
            this.statusButton.TabIndex = 3;
            this.statusButton.Text = "Status";
            this.statusButton.UseVisualStyleBackColor = true;
            this.statusButton.Click += new System.EventHandler(this.statusButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Enabled = false;
            this.resetButton.Location = new System.Drawing.Point(12, 12);
            this.resetButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(97, 26);
            this.resetButton.TabIndex = 4;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 1500;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // timerStatus
            // 
            this.timerStatus.AutoSize = true;
            this.timerStatus.Enabled = false;
            this.timerStatus.Location = new System.Drawing.Point(223, 12);
            this.timerStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.timerStatus.Name = "timerStatus";
            this.timerStatus.Size = new System.Drawing.Size(113, 21);
            this.timerStatus.TabIndex = 5;
            this.timerStatus.Text = "Auto Refresh";
            this.timerStatus.UseVisualStyleBackColor = true;
            this.timerStatus.CheckedChanged += new System.EventHandler(this.timerStatus_CheckedChanged);
            // 
            // powerButton
            // 
            this.powerButton.Enabled = false;
            this.powerButton.Location = new System.Drawing.Point(223, 134);
            this.powerButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.powerButton.Name = "powerButton";
            this.powerButton.Size = new System.Drawing.Size(113, 26);
            this.powerButton.TabIndex = 7;
            this.powerButton.Text = "Set Power";
            this.powerButton.UseVisualStyleBackColor = true;
            this.powerButton.Click += new System.EventHandler(this.powerButton_Click);
            // 
            // timeButton
            // 
            this.timeButton.Enabled = false;
            this.timeButton.Location = new System.Drawing.Point(223, 70);
            this.timeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.timeButton.Name = "timeButton";
            this.timeButton.Size = new System.Drawing.Size(113, 26);
            this.timeButton.TabIndex = 8;
            this.timeButton.Text = "Set Time";
            this.timeButton.UseVisualStyleBackColor = true;
            this.timeButton.Click += new System.EventHandler(this.timeButton_Click);
            // 
            // energyButton
            // 
            this.energyButton.Enabled = false;
            this.energyButton.Location = new System.Drawing.Point(223, 166);
            this.energyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.energyButton.Name = "energyButton";
            this.energyButton.Size = new System.Drawing.Size(113, 26);
            this.energyButton.TabIndex = 9;
            this.energyButton.Text = "Set Energy";
            this.energyButton.UseVisualStyleBackColor = true;
            this.energyButton.Click += new System.EventHandler(this.energyButton_Click);
            // 
            // distanceButton
            // 
            this.distanceButton.Enabled = false;
            this.distanceButton.Location = new System.Drawing.Point(223, 102);
            this.distanceButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.distanceButton.Name = "distanceButton";
            this.distanceButton.Size = new System.Drawing.Size(113, 26);
            this.distanceButton.TabIndex = 10;
            this.distanceButton.Text = "Set Distance";
            this.distanceButton.UseVisualStyleBackColor = true;
            this.distanceButton.Click += new System.EventHandler(this.distanceButton_Click);
            // 
            // writeTimer
            // 
            this.writeTimer.Interval = 10000;
            this.writeTimer.Tick += new System.EventHandler(this.writeTimer_Tick);
            // 
            // metingNextButton
            // 
            this.metingNextButton.Enabled = false;
            this.metingNextButton.Location = new System.Drawing.Point(223, 289);
            this.metingNextButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metingNextButton.Name = "metingNextButton";
            this.metingNextButton.Size = new System.Drawing.Size(113, 26);
            this.metingNextButton.TabIndex = 16;
            this.metingNextButton.Text = "Next ->";
            this.metingNextButton.UseVisualStyleBackColor = true;
            this.metingNextButton.Click += new System.EventHandler(this.metingNextButton_Click);
            // 
            // metingBackButton
            // 
            this.metingBackButton.Enabled = false;
            this.metingBackButton.Location = new System.Drawing.Point(223, 258);
            this.metingBackButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metingBackButton.Name = "metingBackButton";
            this.metingBackButton.Size = new System.Drawing.Size(113, 26);
            this.metingBackButton.TabIndex = 15;
            this.metingBackButton.Text = "<- Back";
            this.metingBackButton.UseVisualStyleBackColor = true;
            this.metingBackButton.Click += new System.EventHandler(this.metingBackButton_Click);
            // 
            // readButton
            // 
            this.readButton.Location = new System.Drawing.Point(223, 228);
            this.readButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(113, 26);
            this.readButton.TabIndex = 17;
            this.readButton.Text = "Read File";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(223, 43);
            this.inputTextBox.Mask = "0L0L0L0";
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(106, 22);
            this.inputTextBox.TabIndex = 18;
            this.inputTextBox.ValidatingType = typeof(int);
            // 
            // Ergometer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 326);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.metingNextButton);
            this.Controls.Add(this.metingBackButton);
            this.Controls.Add(this.distanceButton);
            this.Controls.Add(this.energyButton);
            this.Controls.Add(this.timeButton);
            this.Controls.Add(this.powerButton);
            this.Controls.Add(this.timerStatus);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.statusButton);
            this.Controls.Add(this.ComPortBox);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.richTextBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(369, 373);
            this.MinimumSize = new System.Drawing.Size(369, 373);
            this.Name = "Ergometer";
            this.Text = "Ergometer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ComboBox ComPortBox;
        private System.Windows.Forms.Button statusButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.CheckBox timerStatus;
        private System.Windows.Forms.Button powerButton;
        private System.Windows.Forms.Button timeButton;
        private System.Windows.Forms.Button energyButton;
        private System.Windows.Forms.Button distanceButton;
        private System.Windows.Forms.Timer writeTimer;
        private System.Windows.Forms.Button metingNextButton;
        private System.Windows.Forms.Button metingBackButton;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.MaskedTextBox inputTextBox;
    }
}
