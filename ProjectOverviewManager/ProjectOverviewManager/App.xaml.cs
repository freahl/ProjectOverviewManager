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

namespace ProjectOverviewManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["local_sqlite"].ConnectionString);
        private ArrayList cards = null;
        private MainWindow mainWindow = null;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            mainWindow = new MainWindow();
            cards = new ArrayList();
            AddStatusColumns();
            CreateCards();
            AddCards();
            mainWindow.Show();
        }

        private void AddCards()
        {
            foreach (Card c in cards)
            {

            }
        }

        private void CreateCards()
        {
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Card";
            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    String title = rdr.GetString(1);
                    String description = rdr.GetString(4);
                    String date = rdr.GetString(2);
                    Card c = new Card(title, description, date);
                    cards.Add(c);
                }
            }
            connection.Close();
        }

        private void AddStatusColumns()
        {
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Status";
            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    // For every status create a column
                    GridViewColumn column = new GridViewColumn();
                    column.Header = rdr.GetString(1);
                    column.Width = 200;
                    mainWindow.AddStatusColumn(column);
                }
            }
            connection.Close();
        }

    }

}
