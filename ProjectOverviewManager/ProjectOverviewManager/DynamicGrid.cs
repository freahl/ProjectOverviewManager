﻿using System;
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
            ShowGridLines = false;
            Background = new SolidColorBrush(Colors.LightGray);

            AddRowsToGrid();
            AddColumnsToGrid();
        }

        protected void AddColumnsToGrid()
        {
            foreach(StatusColumn sc in ColMgr.QueryAllColumns())
            {
                Border rowB = new Border();
                rowB.Margin = new Thickness(10);
                Children.Add(rowB);
                ColumnDefinitions.Add(sc.GetColumnDefinition());
                List<ProjectCard> cards = sc.GetCards();
                AddCardsToColumn(cards);
            }
        }

        protected void AddRowsToGrid()
        {
            foreach(RowDefinition r in RowMgr.GetRows())
            {
                RowDefinitions.Add(r);
            }
        }

        protected void AddCardsToColumn(List<ProjectCard> cards)
        {
           for (int i=0; i<cards.Count; i++)
            {
                 Children.Add(cards[i]);
                
                 SetRow(cards[i], i); // Här ska en metod för att kolla om första raden är kolumnen är upptagen och om den är det så lägg kortet på raden under.
                 SetColumn(cards[i], cards[i].GetStatusId());
            }
        }
    }
}
