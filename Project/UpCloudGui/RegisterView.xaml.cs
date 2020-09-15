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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class RegisterView : Page
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            artistName.Visibility = Visibility.Visible;
            artistNameBorder.Visibility = Visibility.Visible;
            sound.Visibility = Visibility.Visible;
            soundBorder.Visibility = Visibility.Visible;
            spo.Visibility = Visibility.Visible;
            spoBorder.Visibility = Visibility.Visible;
            social.Visibility = Visibility.Visible;
            socialBorder.Visibility = Visibility.Visible;
            Thickness height = card.Margin;
            height.Bottom = 2;
            card.Margin = height;
            //card.MaxHeight = 297;
            //StackRegister.Margin = StackRegister.Margin.Left(149);
            Thickness margin = StackRegister.Margin;
            margin.Top = 194;
            StackRegister.Margin = margin;
        }

        private void RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {

            artistName.Visibility = Visibility.Hidden;
            artistNameBorder.Visibility = Visibility.Hidden;
            sound.Visibility = Visibility.Hidden;
            soundBorder.Visibility = Visibility.Hidden;
            spo.Visibility = Visibility.Hidden;
            spoBorder.Visibility = Visibility.Hidden;
            social.Visibility = Visibility.Hidden;
            socialBorder.Visibility = Visibility.Hidden;
            Thickness height = card.Margin;
            height.Bottom = 59;
            card.Margin = height;
            //card.MaxHeight = 297;
            //StackRegister.Margin = StackRegister.Margin.Left(149);
            Thickness margin = StackRegister.Margin;
            margin.Top = 0;
            StackRegister.Margin = margin;
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            CRUDManager crud = new CRUDManager();
            if (RdBtn.IsChecked == true)
            {
                crud.CreateIndependent(name.Text, uName.Text, pass.Text, email.Text, artistName.Text, sound.Text, spo.Text, social.Text);
            }
            else
            {
                crud.CreateManager(name.Text, uName.Text, pass.Text, email.Text);
            }
            LoginIn login = new LoginIn();
            this.NavigationService.Navigate(login);

        }

        private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LoginIn login = new LoginIn();
            this.NavigationService.Navigate(login);

        }
    }
}
