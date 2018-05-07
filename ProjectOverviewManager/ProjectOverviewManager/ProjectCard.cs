using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace ProjectOverviewManager
{
    public class ProjectCard : Canvas
    {
        protected string title;
        protected string description;
        protected string date;
        protected int statusId;
        public Label ProjectTitle = new Label();
        public Label ProjectDate = new Label();
        public Rectangle ProjectBackground = new Rectangle();


        public ProjectCard(string title, string date,string description)
        {//Default constructor med status att hamna i första kolumnen.
            Background = new SolidColorBrush(Colors.LightBlue);
            Margin = new Thickness(10);
            AddChildren();

            ProjectTitle.Content = title;
            ProjectDate.Content = date;
            this.title = title;
            this.date = date;
            this.statusId = 1;
            this.description = description;

        }

        public ProjectCard(string title, string date, int statusId, string description)
        {
            Background = new SolidColorBrush(Colors.LightBlue);
            Margin = new Thickness(10);
            AddChildren();

            ProjectTitle.Content = title;
            ProjectDate.Content = date;
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
        #endregion

        private void AddChildren()
        {
            SetTop(ProjectTitle,0);
            SetBottom(ProjectDate, 10);
            Children.Add(ProjectTitle);
            Children.Add(ProjectDate);
        }
    }
}
