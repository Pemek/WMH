using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WMH
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //no arguments start with main window
            if (e.Args == null || e.Args.Length == 0)
            {
                View.MainWindow mw = new View.MainWindow();
                mw.Show();
            }
            else
                Application.Current.Shutdown();

        }
        private void Application_Exit(object sender, ExitEventArgs e)
        {
        }
    }

    
}
