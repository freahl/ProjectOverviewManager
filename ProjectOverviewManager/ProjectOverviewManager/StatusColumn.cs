using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ProjectOverviewManager.GUI.Card;
using System.Data.SQLite;

namespace ProjectOverviewManager
{
    public class StatusColumn :  GridViewColumn
    {
        private ColumnDefinition columnDefinition = new ColumnDefinition();
        private int columnId;
        private List<Card> cards;

        public StatusColumn(string Header, double Width, int columnId, List<Card> cards)
        {
            this.Header = Header; 
            this.Width = Width;
            this.columnId = columnId;
            this.cards = cards;
        }

        public ColumnDefinition GetColumnDefinition()
        {
            return this.columnDefinition;
        }

        public int GetColumnId()
        {
            return columnId;
        }

        public List<Card> GetCards()
        {
            return cards;
        }
    }
}
