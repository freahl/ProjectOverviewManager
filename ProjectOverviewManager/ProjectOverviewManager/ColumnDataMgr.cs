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
    public class ColumnDataMgr
    {

        private SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["local_sqlite"].ConnectionString);
        private List<ColumnDefinition> columns = new List<ColumnDefinition>();
         
        //Get columns
        public List<ColumnDefinition> GetColumns()
        {
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Status";
            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    ColumnDefinition colDef = new ColumnDefinition();
                    columns.Add(colDef);
                }
            }
            return columns;
        }

    }

}
