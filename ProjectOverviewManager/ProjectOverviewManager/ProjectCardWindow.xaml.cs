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
using System.Windows.Shapes;

namespace ProjectOverviewManager
{
    /// <summary>
    /// Interaction logic for ProjectCardWindow.xaml
    /// </summary>
    public partial class ProjectCardWindow : Window
    {
        CardDataMgr CardMgr = new CardDataMgr();
        public ProjectCardWindow()
        {
            InitializeComponent();
        }

        private void AddProjectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ProjectCard Card  = SetNewCard();
            CardMgr.InsertCardToDataBase(Card);
        }

        private ProjectCard SetNewCard()
        {
            string title = NewProjectTextBox.Text.ToString();
            string date = DeadLineDatePicker.Text.ToString();
            string description = DescriptionTextBox.Text.ToString();

            ProjectCard card = new ProjectCard(title, date, description);
            return card;
        }
    }
}
