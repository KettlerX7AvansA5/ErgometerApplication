using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerApplication
{
    public class PanelClientData : Panel
    {
        public Label labelMetingCurrentValue;
        public ProgressBar progressBarMeting;
        public Label metingName;

        public PanelClientData(string name) : base()
        {
            this.metingName = new System.Windows.Forms.Label();
            this.progressBarMeting = new System.Windows.Forms.ProgressBar();
            this.labelMetingCurrentValue = new System.Windows.Forms.Label();
            // 
            // initialize panel
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelMetingCurrentValue);
            this.Controls.Add(this.progressBarMeting);
            this.Controls.Add(this.metingName);
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "panel1";
            this.Size = new System.Drawing.Size(284, 80);
            // 
            // metingName
            // 
            this.metingName.AutoSize = true;
            this.metingName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metingName.Location = new System.Drawing.Point(12, 9);
            this.metingName.Name = "metingName";
            this.metingName.Size = new System.Drawing.Size(105, 21);
            this.metingName.TabIndex = 0;
            this.metingName.Text = name;
            // 
            // progressBarMeting
            // 
            this.progressBarMeting.Location = new System.Drawing.Point(16, 39);
            this.progressBarMeting.Name = "progressBarMeting";
            this.progressBarMeting.Size = new System.Drawing.Size(183, 23);
            this.progressBarMeting.TabIndex = 1;
            this.progressBarMeting.Value = 50;
            // 
            // labelMetingCurrentValue
            // 
            this.labelMetingCurrentValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMetingCurrentValue.AutoSize = true;
            this.labelMetingCurrentValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMetingCurrentValue.Location = new System.Drawing.Point(215, 32);
            this.labelMetingCurrentValue.Name = "labelMetingCurrentValue";
            this.labelMetingCurrentValue.Size = new System.Drawing.Size(57, 32);
            this.labelMetingCurrentValue.TabIndex = 2;
            this.labelMetingCurrentValue.Text = "255";
        }

        public void setText(string text)
        {
            this.metingName.Text = text;
        }

        public void updateValue(int value)
        {
            this.labelMetingCurrentValue.Text = value.ToString();
            this.progressBarMeting.Value = value;
        }

        public void updateValue(double value)
        {
            this.labelMetingCurrentValue.Text = value.ToString();
            this.progressBarMeting.Value = (int)value;
        }

        public void updateValue(decimal value)
        { 
            this.labelMetingCurrentValue.Text = value.ToString();
            this.progressBarMeting.Value = (int)value;
        }
    }
}
