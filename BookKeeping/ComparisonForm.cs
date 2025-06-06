// Matt Deinlein[mattdeinlein@gmail.com]
// @version: 1.0 06.06.2025
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookKeeping
{
    public partial class ComparisonForm : Form
    {
        private DatabaseHelper dbHelper;
        public ComparisonForm()
        {
            InitializeComponent();
            this.Load += ComparisonForm_Load;
        }
        private void ComparisonForm_Load(object sender, EventArgs e)
        {
            // Earlier Range
            dtpStartA.Format = DateTimePickerFormat.Custom;
            dtpStartA.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            dtpEndA.Format = DateTimePickerFormat.Custom;
            dtpEndA.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            // Present Range
            dtpStartB.Format = DateTimePickerFormat.Custom;
            dtpStartB.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            dtpEndB.Format = DateTimePickerFormat.Custom;
            dtpEndB.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }
        public class ClientMetrics
        {
            public int LeadCount { get; set; }
            public int SetCount { get; set; }
            public int ShowedCount { get; set; }
            public int ClosedCount { get; set; }
            public int RescheduledCount { get; set; }
            public decimal DownPaymentTotal { get; set; }

            public double SetRate => SetCount == 0 ? 0 : (double)SetCount / LeadCount;
            public double ShowRate => SetCount == 0 ? 0 : (double)ShowedCount / SetCount;
            public double CloseRate => ShowedCount == 0 ? 0 : (double)ClosedCount / ShowedCount;
            public double RescheduleRate => SetCount == 0 ? 0 : (double)RescheduledCount / SetCount;
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            DatabaseHelper db = new DatabaseHelper();

            var metricsA = db.GetMetrics(dtpStartA.Value, dtpEndA.Value);
            var metricsB = db.GetMetrics(dtpStartB.Value, dtpEndB.Value);

            // Populates Earlier Range
            txtLeadsA.Text = metricsA.LeadCount.ToString();
            txtSetA.Text = metricsA.SetCount.ToString();
            txtShowedA.Text = metricsA.ShowedCount.ToString();
            txtClosedA.Text = metricsA.ClosedCount.ToString();
            txtRescheduledA.Text = metricsA.RescheduledCount.ToString();
            txtDownA.Text = metricsA.DownPaymentTotal.ToString("C"); 
            txtSetRateA.Text = (metricsA.SetRate * 100).ToString("F1") + "%";
            txtShowRateA.Text = (metricsA.ShowRate * 100).ToString("F1") + "%";
            txtClosedRateA.Text = (metricsA.CloseRate * 100).ToString("F1") + "%";
            txtRescheduledRateA.Text = (metricsA.RescheduleRate * 100).ToString("F1") + "%";

            // Populates Present Range
            txtLeadsB.Text = metricsB.LeadCount.ToString();
            txtSetB.Text = metricsB.SetCount.ToString();
            txtShowedB.Text = metricsB.ShowedCount.ToString();
            txtClosedB.Text = metricsB.ClosedCount.ToString();
            txtRescheduledB.Text = metricsB.RescheduledCount.ToString();
            txtDownB.Text = metricsB.DownPaymentTotal.ToString("C");
            txtSetRateB.Text = (metricsB.SetRate * 100).ToString("F1") + "%";
            txtShowRateB.Text = (metricsB.ShowRate * 100).ToString("F1") + "%";
            txtClosedRateB.Text = (metricsB.CloseRate * 100).ToString("F1") + "%";
            txtRescheduledRateB.Text = (metricsB.RescheduleRate * 100).ToString("F1") + "%";

            // Populates Percent Changes
            DisplayPercentChange(txtLeadsC, metricsA.LeadCount, metricsB.LeadCount);
            DisplayPercentChange(txtSetC, metricsA.SetCount, metricsB.SetCount);
            DisplayPercentChange(txtShowedC, metricsA.ShowedCount, metricsB.ShowedCount);
            DisplayPercentChange(txtClosedC, metricsA.ClosedCount, metricsB.ClosedCount);
            DisplayPercentChange(txtRescheduledC, metricsA.RescheduledCount, metricsB.RescheduledCount);
            DisplayPercentChange(txtDownC, (double)metricsA.DownPaymentTotal, (double)metricsB.DownPaymentTotal);
            DisplayPercentChange(txtSetRateC, metricsA.SetRate, metricsB.SetRate);
            DisplayPercentChange(txtShowRateC, metricsA.ShowRate, metricsB.ShowRate);
            DisplayPercentChange(txtClosedRateC, metricsA.CloseRate, metricsB.CloseRate);
            DisplayPercentChange(txtRescheduledRateC, metricsA.RescheduleRate, metricsB.RescheduleRate);

        }
        void DisplayPercentChange(TextBox target, double valueA, double valueB)
        {
            double percentChange = valueA == 0 ? (valueB == 0 ? 0 : 100) : ((valueB - valueA) / valueA) * 100;

            target.Text = percentChange.ToString("F1") + "%";

            if (percentChange > 0)
                target.BackColor = Color.LightGreen;
            else if (percentChange < 0)
                target.BackColor = Color.LightCoral;
            else
                target.BackColor = Color.LightYellow;
        }

    }
}
