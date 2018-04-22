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
using System.Windows.Shapes;
using ProjectOverviewManager.GUI.Card;

namespace ProjectOverviewManager
{
    /// <summary>
    /// Interaction logic for GridTestWindow.xaml
    /// </summary>
    public partial class GridTestWindow : Window
    {
        public GridTestWindow()
        {
            InitializeComponent();
            Setup();
            RowDefinition myRow = new RowDefinition();
            GridLength gridLength = new GridLength(50) ;
            
            myRow.Height = gridLength ;
            TestGrid.RowDefinitions.Add(myRow);
        }

        private void Setup()
        {
            int r = -1;
            foreach(RowDefinition rd in TestGrid.RowDefinitions)
            {
                r++;
                int c = -1;
                foreach(ColumnDefinition cd in TestGrid.ColumnDefinitions)
                { c++;
                    CardWindow card = new CardWindow();

                    Grid.SetColumn(card, c);
                    Grid.SetRow(card, r);
                    card.Margin = new Thickness(1);
                    TestGrid.ShowGridLines = true;
                    
                    TestGrid.Children.Add(card);
                    
                }
            }
        }
    }
}
