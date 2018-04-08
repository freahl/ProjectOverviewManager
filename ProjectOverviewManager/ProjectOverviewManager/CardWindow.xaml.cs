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
    /// Interaction logic for CardWindow.xaml
    /// </summary>
    public partial class CardWindow : Window
    {
        public CardWindow()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            HideSettings();
        }
        private void Card_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CardMenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void MenuBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void SetCardLabel(string labelName)
        {
            CardLabel.Content = labelName;
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            ShowSettings();
        }

        private void ShowSettings()
        {
            ProjectNameLabel.Visibility = Visibility.Visible;
            ProjectNameTextBox.Visibility = Visibility.Visible;
            ProjectDeadLineLabel.Visibility = Visibility.Visible;
            ProjectDatePicker.Visibility = Visibility.Visible;
            SetSettingsBtn.Visibility = Visibility.Visible;
        }

        private void HideSettings()
        {
            ProjectNameLabel.Visibility = Visibility.Hidden;
            ProjectNameTextBox.Visibility = Visibility.Hidden;
            ProjectDeadLineLabel.Visibility = Visibility.Hidden;
            ProjectDatePicker.Visibility = Visibility.Hidden;
            SetSettingsBtn.Visibility = Visibility.Hidden;
        }

        private void SetSettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            SetCardLabel(ProjectNameTextBox.Text);
            HideSettings();
            ProjectNameTextBox.Text = ""; 
        }
    }
}
