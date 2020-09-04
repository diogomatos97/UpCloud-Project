using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UpCloudGui
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginIn : Page
    {
        public LoginIn()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = uName.Text.Trim();
            string password = pass.Text.Trim();
            ArtistView artistView = new ArtistView(username, password);
            this.NavigationService.Navigate(artistView);

        }
    }
}
