using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using static Hermes.QuickUtils;

namespace Hermes
{
    public partial class SplashScreen : Form
    {

        // List of words to be displayed
        public string[] texts = {   "Starting",
                                    "Intializing Plugins",
                                    "Importing Libraries",
                                    "Starting Database",
                                    "Testing Application",
                                    "Verifying License",
                                    "Almost Done",
                                    "Generating UI" };
        public SplashScreen()
        {
            InitializeComponent();

            // Rounding the form edges
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));

            // Adding custom font for the labels
            loadingTextLabel.Font = new Font(pfc.Families[3], 10);
            randomTextLabel.Font = new Font(pfc.Families[3], 8);
            versionLabel.Font = new Font(pfc.Families[3], 8);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            int curTextOrder = progressBarStatus.Width / 90;

            randomTextLabel.Text = texts[curTextOrder];
            loadingTextLabel.Text = "Loading" + string.Concat(Enumerable.Repeat(" .", (progressBarStatus.Width / 45) % 3));
            progressBarStatus.Width += 3;

            if (progressBarStatus.Width >= 700)
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}
