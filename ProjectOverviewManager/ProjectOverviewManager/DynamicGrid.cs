using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace ProjectOverviewManager
{
    public class DynamicGrid:  Grid
    {
        private ColumnDataMgr ColMgr = new ColumnDataMgr();
        private RowDataMgr RowMgr = new RowDataMgr();
        public DynamicGrid()
        {
            SetGrid();
            
        }
        
        protected void SetGrid()
        {
            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            ShowGridLines = true;
            Background = new SolidColorBrush(Colors.AntiqueWhite);

            AddColumnsToGrid();
            AddRowsToGrid();
        }

        protected void AddColumnsToGrid()
        {
            foreach(ColumnDefinition c in ColMgr.GetColumns())
            {
                Border rowB = new Border();
                rowB.Margin = new Thickness(10);
                Children.Add(rowB);
                ColumnDefinitions.Add(c);
            }
        }

        protected void AddRowsToGrid()
        {
            foreach(RowDefinition r in RowMgr.GetRows())
            {
                RowDefinitions.Add(r);
            }
        }
    }
}
