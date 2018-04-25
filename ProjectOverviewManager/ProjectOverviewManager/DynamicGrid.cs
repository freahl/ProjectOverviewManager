using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using ProjectOverviewManager.GUI.Card;
using System.Windows.Shapes;

namespace ProjectOverviewManager
{
    public class DynamicGrid:  Grid
    {
        private ColumnDataMgr ColMgr = new ColumnDataMgr();
        private RowDataMgr RowMgr = new RowDataMgr();
        private CardDataMgr CardMgr = new CardDataMgr();
    
        public DynamicGrid()
        {
            SetGrid();  
        }
        
        protected void SetGrid()
        {
            
            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            ShowGridLines = true;
            Background = new SolidColorBrush(Colors.White);

            AddColumnsToGrid();
            AddRowsToGrid();
            AddCardsToGrid();
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

        protected void AddCardsToGrid()
        {
           foreach(Card card in CardMgr.GetCards())
            {
                Children.Add(card.GetCard());
                SetRow(card, 1); // Här ska en metod för att kolla om första raden är kolumnen är upptagen och om den är det så lägg kortet på raden under.
                SetColumn(card, card.GetStatusId());
                
            }
        }
    }
}
