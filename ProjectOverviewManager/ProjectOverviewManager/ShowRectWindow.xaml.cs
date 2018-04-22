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

namespace ProjectOverviewManager
{
    /// <summary>
    /// Interaction logic for ShowRectWindow.xaml
    /// </summary>
    public partial class ShowRectWindow : Window
    {
        private int row = 3;
        private int col = 3;
        public ShowRectWindow()
        {
            Window RootWindow = new Window();             
            Grid DynamicGrid = new Grid();

            DynamicGrid.Width = 400;

            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left;

            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;

            DynamicGrid.ShowGridLines = true;

            DynamicGrid.Background = new SolidColorBrush(Colors.LightSteelBlue);
            for (int r = 0; r < row; r++)
            {
                RowDefinition rowDef = new RowDefinition();
                GridLength h = new GridLength(100);
                rowDef.Height = h;
                DynamicGrid.RowDefinitions.Add(rowDef);
            }
            for (int c = 0; c < col; c++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                GridLength w = new GridLength(100);
                colDef.Width = w;
                DynamicGrid.ColumnDefinitions.Add(colDef);
                
            }

            RootWindow.Content = DynamicGrid;
            
        }
    }
}
