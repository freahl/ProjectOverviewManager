using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SQLite;
using System.Collections;
using System.Windows.Controls;
using ProjectOverviewManager.GUI.Card;
using System.Windows.Media;


namespace ProjectOverviewManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["local_sqlite"].ConnectionString);
        private MainWindow mainWindow = null;
      
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            mainWindow = new MainWindow();
         
            mainWindow.Show();
            
        }
        
  
    }

}


