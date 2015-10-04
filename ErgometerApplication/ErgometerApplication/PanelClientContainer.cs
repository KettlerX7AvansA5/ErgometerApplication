using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerApplication
{
    public class PanelClientContainer:Panel
    {

        private PanelClientChat panelClientChat;
        private PanelClientDataView panelClientDataView;

        public PanelClientContainer() : base()
        {
            this.panelClientChat = new PanelClientChat();
            this.panelClientDataView = new PanelClientDataView();

            // 
            // panelClientContainer
            // 
            this.Controls.Add(this.panelClientDataView);
            this.Controls.Add(this.panelClientChat);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "panelClientContainer";
            this.Size = new System.Drawing.Size(800, 600);
            this.TabIndex = 0;

        }

    }
}
