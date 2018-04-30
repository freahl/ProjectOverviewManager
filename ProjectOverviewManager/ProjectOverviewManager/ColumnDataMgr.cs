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
        #region Card memeber variables
        private string title;
        private string date ;
        private int statusId;
        private string description;
        #endregion

        private SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["local_sqlite"].ConnectionString);
        private List<StatusColumn> columns = new List<StatusColumn>();
        private int i = 0;

        public List<string> GetAllColumnNames()
        {
            List<string> columnName = new List<string>();
            SQLiteCommand cmd = connection.CreateCommand();
            cmd.CommandText = "PRAGMA table_info(Card);" ;
            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    string colName = (string)rdr["name"];
                    columnName.Add(colName);
                }
            }
           
            return columnName;
        }
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
            cmd.CommandText = "SELECT * " +
                "FROM Card " +
                "WHERE status = " + id + ";";
            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {

                    List<string> columnList = GetAllColumnNames();
                    foreach(string colName in columnList)
                    {
                        var value = rdr[i];
                        if (value != DBNull.Value)
                        {
                            AddToAttributes(colName, value);
                        }
                        i++;
                    }
                   
                    Card c = new Card(title, date, statusId, description);
                    results.Add(c);
                    i = 0;
                }
            }
            return results;
        }

        private void AddToAttributes(string colName, object value)
        {
            if (colName == "title")
            {
                title = (string)value;
            }
            else if (colName == "date")
            {
                date = (string)value;
            }
            else if (colName == "status")
            {
                statusId = Convert.ToInt32(value);
            }
            else if(colName == "description")
            {
                description = (string)value;
            }
        }

        private string CheckTitle(object titleName)
        {
            if (titleName != null && titleName is String)
            { title = titleName.ToString(); }
            else
            { title = ""; }
            return title;
        }

        private string CheckDate(object projectDate)
        {
            if (projectDate != null && projectDate is String)
            { date = projectDate.ToString(); }
            else
            { date = ""; }
            return date;
        }

        private string CheckDescription(object projectDescr)
        {
            if (projectDescr != null && projectDescr is String)
            { description = projectDescr.ToString(); }
            else
            { description = ""; }
            return description;
        }

    }

}
