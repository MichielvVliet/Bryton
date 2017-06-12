using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using System.Xml.Linq;

namespace Bryton
{
    public partial class Form1 : Form
    {
        List<RitSamenVatting> Ritten = new List<RitSamenVatting>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RitSamenVatting Rit = new RitSamenVatting();
            int NodeNr = 0;
            string[] filePaths = Directory.GetFiles(@"C:\Users\Michiel\Documents\Bryton\", "*.bdx");

            foreach (string naam in filePaths)
            {
                Rit = XMLLezen.LeesXMLSamenVatting(naam);
                Ritten.Add(Rit);
                AddRitToTreeview(Rit, NodeNr);
                NodeNr += 1;
            }
        }

        private void AddRitToTreeview(RitSamenVatting Rit, int NodeNr)
        {
            treeView1.Nodes.Add(Rit.StartTijd.Substring(0, 10));
            treeView1.Nodes[NodeNr].Nodes.Add("Tijd");
            treeView1.Nodes[NodeNr].Nodes.Add("Snelheid");
            treeView1.Nodes[NodeNr].Nodes.Add("Afstand");
            treeView1.Nodes[NodeNr].Nodes[0].Nodes.Add("Start: " + Rit.StartTijd.Substring(11, 8));
            treeView1.Nodes[NodeNr].Nodes[0].Nodes.Add("Eind: " + Rit.EindTijd.Substring(11, 8));
            treeView1.Nodes[NodeNr].Nodes[1].Nodes.Add("Gem.: " + (Rit.SnelheidGem / 10).ToString());
            treeView1.Nodes[NodeNr].Nodes[1].Nodes.Add("Max.: " + (Rit.SnelheidMax / 10).ToString());
            treeView1.Nodes[NodeNr].Nodes[2].Nodes.Add("Totaal: " + (Rit.Afstand / (double)1000).ToString());
            treeView1.Nodes[NodeNr].Nodes[2].Nodes.Add("Berg Op: " + (Rit.AfstandBergOp / (double)1000).ToString());
            treeView1.Nodes[NodeNr].Nodes[2].Nodes.Add("Berg Af: " + (Rit.AfstandBergAf / (double)1000).ToString());
        }

        private void TekenDeGrafieken(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;
            var pen = new Pen(Color.Gray, 0);
            var afstand = splitContainer2.Panel2.Width / (10);
            Point point1;
            Point point2;
            for (int xTeller=1; xTeller<=11;xTeller++)
            {
                point1= new Point(afstand* xTeller, 0);
                point2= new Point(afstand * xTeller, splitContainer2.Panel2.Height);
                g.DrawLine(pen, point1, point2);
            }

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            RitSamenVatting Rit = new RitSamenVatting();
            List<LogPoint> LogPoints = new List<LogPoint>();
            double xTeller = 1;

            if (e.Node.Parent == null)
            //e.Node.Parent.GetType() == typeof(TreeNode))
            {
                treeView1.CollapseAll();
                Rit = Ritten[e.Node.Index];
                treeView1.Nodes[e.Node.Index].ExpandAll();
            }
            LogPoints = XMLLezen.LeesLogPointsUitXML(Rit.BestandsNaam);

            while (chart1.Series.Count > 0) { chart1.Series.RemoveAt(0); }
            while (chart1.Legends.Count > 0) { chart1.Legends.RemoveAt(0); }
            while (chart1.Titles.Count > 0) { chart1.Titles.RemoveAt(0); }

            chart1.ChartAreas["ChartArea1"].AxisY2.Enabled = AxisEnabled.True;
            chart1.Titles.Add("bestand");
            chart1.Titles[0].Text = Rit.BestandsNaam;

            if (chart1.Series.IsUniqueName("Cadance"))
            {
                chart1.Series.Add("Cadance");
                chart1.Legends.Add(new Legend("Cadances"));
                chart1.Series[0].LegendText = "Cadance";
                chart1.Legends[0].DockedToChartArea = "ChartArea1";
                chart1.Series[0].YAxisType = AxisType.Secondary;
            }
            if (chart1.Series.IsUniqueName("HartRate"))
            {
                chart1.Series.Add("HartRate");
                chart1.Legends.Add(new Legend("HartRate"));
                chart1.Series[1].LegendText = "HartRate";
                chart1.Legends[1].DockedToChartArea = "ChartArea1";
                chart1.Series[1].YAxisType = AxisType.Secondary;
            }

            if (chart1.Series.IsUniqueName("Speed"))
            {
                chart1.Series.Add("Speed");
                chart1.Legends.Add(new Legend("Speed"));
                chart1.Series[2].LegendText = "Speed";
                chart1.Legends[2].DockedToChartArea = "ChartArea1";
            }


            foreach (LogPoint lp in LogPoints)
            {
                chart1.Series[0].Points.AddXY(xTeller, lp.Cadance);
                chart1.Series[1].Points.AddXY(xTeller, lp.Hartrate);
                chart1.Series[2].Points.AddXY(xTeller, lp.Speed);
                xTeller += 1;
            }

            chart1.Series[0].ChartType = SeriesChartType.FastLine;
            chart1.Series[0].Color = Color.Blue;
            chart1.Series[1].ChartType = SeriesChartType.FastLine;
            chart1.Series[1].Color = Color.Red;
            chart1.Series[2].ChartType = SeriesChartType.FastLine;
            chart1.Series[2].Color = Color.Cyan;
        }
    }
}
