using System;
using System.Windows.Forms;

namespace Productivity__
{
    static class Program
    {
        private static MainWindow MainWindow;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainWindow = new MainWindow();
            Application.Run(MainWindow);
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            MainWindow.Terminate();
        }
    }
}
