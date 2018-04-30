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
using ProjectOverviewManager.GUI.Card;

namespace ProjectOverviewManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            winContent.Content = new DynamicGrid();
        }


        private void ProjectListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void newProject_Click(object sender, RoutedEventArgs e)
        {
            CardWindow cardWindow = new CardWindow();
            cardWindow.Show();
        }
    }
}
