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
    /// 
    public partial class Card : UserControl
    {
        public Rectangle rectangle = new Rectangle();
        
        protected String title;
        protected String description;
        protected String date;
        protected int statusId;

        public Card(String title, String date,int statusId, String description)
        {
            this.title = title;
            this.date = date;
            this.statusId = statusId;
            this.description = description;
        }

        #region Get-Methods
        public int GetStatusId()
        {
            return statusId;
        }

        public string GetDate()
        {
            return date;
        }

        public string GetTitle()
        {
            return title;
        }

        public string GetDescription()
        {
            return description;
        }

        public Rectangle GetCardRectangle()
        {   
            rectangle.Fill = new SolidColorBrush(System.Windows.Media.Colors.LightSteelBlue);
            rectangle.RadiusX = 9;
            rectangle.RadiusY = 9;
            rectangle.Margin = new Thickness(10);
            return rectangle;
        }
        #endregion
    }
}
