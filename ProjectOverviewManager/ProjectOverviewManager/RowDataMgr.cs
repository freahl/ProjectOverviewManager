using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Windows.Controls;
namespace ProjectOverviewManager
{
    public class RowDataMgr
    {
        private SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["local_sqlite"].ConnectionString);
        private List<RowDefinition> rows = new List<RowDefinition>();

        //Get columns
        public List<RowDefinition> GetRows()
        {
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Status;";
            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    RowDefinition colDef = new RowDefinition();
                    rows.Add(colDef);
                }
            }
            return rows;
        }

    }
}
