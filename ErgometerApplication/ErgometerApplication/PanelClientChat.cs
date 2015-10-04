using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerApplication
{
   public class PanelClientChat : Panel
    {
        public PanelClientChat() : base()
        {
            // 
            // panelClientChat
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Dock = System.Windows.Forms.DockStyle.Left;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "panelClientChat";
            this.Size = new System.Drawing.Size(400, 600);
            this.TabIndex = 2;

        }
    }
}
