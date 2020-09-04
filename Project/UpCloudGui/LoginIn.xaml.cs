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
using UpCloudLogic;

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



            string username = "diogo97";
            //string username = uName.Text.Trim();
            string password = "diogo97";
            //string password = pass.SecurePassword.ToString();

            var login = new Login();

            login.Exists(username, password);
            ArtistView artistView = new ArtistView(username, password);
            this.NavigationService.Navigate(artistView);


            MessageBox.Show("Details are Incorrect!");


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }


}
