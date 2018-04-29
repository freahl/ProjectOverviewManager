using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Windows.Controls;
using ProjectOverviewManager.GUI.Card;

namespace ProjectOverviewManager
{
    public class ColumnDataMgr
    {

        private SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["local_sqlite"].ConnectionString);
        private List<StatusColumn> columns = new List<StatusColumn>();
         
        public List<StatusColumn> QueryAllColumns()
        {
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT s.id, s.name FROM Status s;";
            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    int id = rdr.GetInt32(0);
                    String name = rdr.GetString(1);
                    List<Card> cards = QueryCardsByStatusId(id);
                    StatusColumn col = new StatusColumn(name, 200, id, cards);
                    columns.Add(col);
                }
            }
            connection.Close();
            return columns;
        }

        private List<Card> QueryCardsByStatusId(int id)
        {
            List<Card> results = new List<Card>();
            SQLiteCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT title, deadline, status, description " +
                "FROM Card " +
                "WHERE status = " + id + ";";
            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    string title = rdr.GetString(0);
                    string date = "";//rdr.GetString(1);
                    int statusId = rdr.GetInt32(2);
                    string description = rdr.GetString(3);
                    Card c = new Card(title, date, statusId, description);
                    results.Add(c);
                }
            }
            return results;
        }

    }

}
