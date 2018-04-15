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

namespace ProjectOverviewManager.GUI.Card
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        
            private String _title;
            private String _description;
            private String _date;
            private int _statusId;

            public Card(String title, String date,int statusId, String description)
            {
                this._title = title;
                this._date = date;
                this._statusId = statusId;
                this._description = description;
            }
        

    }
}
