using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace _01._SimpleForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void changeGreetingButton_Click(object sender, EventArgs e)
        {
            // Get the current location of the label
            Point currentLocation = greetingLabel.Location;

            Random rand = new Random();

            greetingLabel.Location = new Point(
                currentLocation.X + rand.Next(-20, 20),
                currentLocation.Y + rand.Next(-20, 20)
            );

            greetingLabel.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }
    }
}
