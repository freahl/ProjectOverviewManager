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
            List<Card> cards = CreateCards();
            AddStatusColumns();
            mainWindow.AddCardsToColumn(cards);
            mainWindow.Show();
        }

        

        private List<Card> CreateCards()
        {
            List<Card> cardList = new List<Card>();
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Card";
            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    String title = rdr.GetString(1);
                    String date = rdr.GetString(2);
                    int statusId = rdr.GetInt32(3);
                    String description = rdr.GetString(4);
                    Card c = new Card(title, date, statusId, description);
                    cardList.Add(c);
                }
            }
            connection.Close();
            return cardList;
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
                    StatusColumn statusCol = new StatusColumn(rdr.GetString(1), 200);
                    mainWindow.AddStatusColumn(statusCol);
                }
            }
            connection.Close();
        }

    }

}
