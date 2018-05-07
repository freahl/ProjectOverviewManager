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
        private List<ProjectCard> cards;

        public StatusColumn(string Header, int columnId, List<ProjectCard> cards)
        {
            this.Header = Header; 
            this.columnId = columnId;
            this.cards = cards;
            this.Width = '*';
        }

        public ColumnDefinition GetColumnDefinition()
        {
            return this.columnDefinition;
        }

        public int GetColumnId()
        {
            return columnId;
        }

        public List<ProjectCard> GetCards()
        {
            return cards;
        }
    }
}
