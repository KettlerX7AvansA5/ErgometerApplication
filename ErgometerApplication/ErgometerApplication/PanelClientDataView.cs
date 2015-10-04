using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerApplication
{
    public class PanelClientDataView:Panel
    {
        public PanelClientDataView() : base()
        {
            // 
            // panelClientDataView
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(400, 0);
            this.Name = "panelClientDataView";
            this.Size = new System.Drawing.Size(400, 600);
            this.TabIndex = 1;
        }
    }
}
