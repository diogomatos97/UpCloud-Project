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



            //string username = "test1";
            string username = uName.Text.Trim();
            // string password = "test1";
            string password = pass.Password.ToString();

            var login = new Login();
            var name = login.GetName(username, password);
            var ID = login.IsIndependent(name);
            if (ID > 0)
            {
                ArtistView artistView1 = new ArtistView(username, password, ID);
                this.NavigationService.Navigate(artistView1);
            }
            else
            {
                login.Exists(username, password);
                ArtistView artistView = new ArtistView(username, password);
                this.NavigationService.Navigate(artistView);
            }

            // MessageBox.Show("Details are Incorrect!");


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegisterView register = new RegisterView();
            this.NavigationService.Navigate(register);
        }
    }


}
