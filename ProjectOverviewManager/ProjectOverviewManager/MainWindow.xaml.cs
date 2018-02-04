using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace ProjectOverviewManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SQLiteConnection connection;

        public MainWindow()
        {
            InitializeComponent();

            connection = new SQLiteConnection(@"Data source=C:\Users\Administrator\Documents\GitHub\ProjectOverviewManager\db\main_db_file.db");
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Status";
            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    // För varje status i svaret från databasen
                    // skapar vi kolumner dynamiskt
                    GridViewColumn column = new GridViewColumn();
                    column.Header = rdr.GetString(1);
                    column.Width = 200;
                    MyGridView.Columns.Add(column);
                }
            }
            connection.Close();
        }

        private void ProjectListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
