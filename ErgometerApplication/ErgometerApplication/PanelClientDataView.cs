using ErgometerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerApplication
{
    public class PanelGraphView:Panel
    {

        private List<ChartPanel> charts;
        private FlowLayoutPanel flowlayout;

        public PanelGraphView() : base()
        {
            createCharts();        

            flowlayout = new FlowLayoutPanel();

            flowlayout.Dock = DockStyle.Fill;
            flowlayout.BackColor = System.Drawing.Color.DarkGray;
            flowlayout.Location = new System.Drawing.Point(0, 0);
            flowlayout.Name = "flowlayout";
            flowlayout.Padding = new Padding(15);
            flowlayout.AutoScroll = true;
            foreach(ChartPanel chart in charts)
            {
                flowlayout.Controls.Add(chart);
            }

            List<Meting> metingen = new List<Meting>();
            metingen.Add(new Meting(23, 25, 12, 46, 13, 25, 13, 1, 32));
            metingen.Add(new Meting(23, 25, 12, 46, 13, 25, 13, 1, 32));
            metingen.Add(new Meting(23, 25, 12, 46, 13, 25, 13, 1, 32));
            metingen.Add(new Meting(23, 25, 12, 46, 13, 25, 13, 1, 32));
            metingen.Add(new Meting(23, 25, 12, 46, 13, 25, 13, 1, 32));
            metingen.Add(new Meting(23, 25, 12, 46, 13, 25, 13, 1, 32));
            metingen.Add(new Meting(23, 25, 12, 46, 13, 25, 13, 1, 32));
            metingen.Add(new Meting(23, 25, 12, 46, 13, 25, 13, 1, 32));
            metingen.Add(new Meting(23, 25, 12, 46, 13, 25, 13, 1, 32));
            metingen.Add(new Meting(23, 25, 12, 46, 13, 25, 13, 1, 32));

            updateAllCharts(metingen);
            // 
            // panelGraphView
            // 
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(flowlayout);

            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "panelGraphView";
            this.Size = new System.Drawing.Size(400, 600);
            this.TabIndex = 1;
        }

        public void createCharts()
        {
            charts = new List<ChartPanel>();
            charts.Add(new ChartPanel(ChartPanel.MetingType.HEARTBEAT));
            charts.Add(new ChartPanel(ChartPanel.MetingType.RPM));
            charts.Add(new ChartPanel(ChartPanel.MetingType.SPEED));
            charts.Add(new ChartPanel(ChartPanel.MetingType.DISTANCE));
            charts.Add(new ChartPanel(ChartPanel.MetingType.ENERGY));
            charts.Add(new ChartPanel(ChartPanel.MetingType.SECONDS));
            charts.Add(new ChartPanel(ChartPanel.MetingType.POWER));
            charts.Add(new ChartPanel(ChartPanel.MetingType.ACTUALPOWER));
        }

        public void updateAllCharts(List<Meting> metingen)
        {
            foreach(ChartPanel chart in charts)
            {
                chart.updateChart(metingen);
            }
        }
    }
}
