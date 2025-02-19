using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseEvents
{
    public partial class Form1 : Form
    {
        private Label label;

        public Form1()
        {
            InitializeComponent();

            this.runawayButton.MouseEnter += RunAway;

            label = new Label();
            label.Text = "Never Catch!";
            label.Visible = false;
            this.Controls.Add(label);

        }

        private void RunAway(object sender, EventArgs e)
        {

            Random random = new Random();

            // New random position
            runawayButton.Location = new Point(
                random.Next(this.ClientSize.Width - runawayButton.Width),
                random.Next(this.ClientSize.Height - runawayButton.Height)
            );

            runawayButton.BackColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));

            label.Visible = true;
            label.Location = new Point(
                random.Next(this.ClientSize.Width - runawayButton.Width),
                random.Next(this.ClientSize.Height - runawayButton.Height)
            );

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
