using System;
using System.Windows.Forms;

using static Hermes.QuickUtils;

namespace Hermes
{
    static class Hermes
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // adding custom resources to the
            addResources();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new SplashScreen());
            Application.Run(new AccessForm());
            
            /* ---- Only for testing purpose ---- */
            //UserModel TestUser = new UserModel();
            //TestUser.name = "Default";
            //TestUser.profilePicture = "funny.png";
            //TestUser.userType = "Admin";
            //Application.Run(new MainForm(TestUser));ica
        }

    }
}
