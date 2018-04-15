using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ProjectOverviewManager.GUI.Card;

namespace ProjectOverviewManager
{
    public class StatusColumn :  GridViewColumn
    {
        private int _columnId;
        public StatusColumn(string Header,double Width,int columnId)
        {
            this.Header = Header; 
            this.Width = Width;
            _columnId = columnId;
        }

        public int GetColumnId()
        {
            return _columnId;
        }

     
    }
}
