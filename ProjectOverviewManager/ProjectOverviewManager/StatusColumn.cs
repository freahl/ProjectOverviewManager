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
        public StatusColumn(string Header,int Width)
        {
            this.Header = Header;
            this.Width = Width;
            //GetCards()
        }

     
    }
}
