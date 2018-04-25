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
    class CardDataMgr
    {
        private SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["local_sqlite"].ConnectionString);
        List<Card> cards = new List<Card>();

        public List<Card> GetCards()
        {
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
                    cards.Add(c);
                }
            }
            connection.Close();
            return cards;
        }
    }
}
