using Project;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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
    /// Interaction logic for ArtistView.xaml
    /// </summary>
    public partial class ArtistView : Page
    {
        string user;
        string pass;
        CRUDManager crud = new CRUDManager();
        public ArtistView()
        {
            InitializeComponent();

        }
        public ArtistView(string username, string password)
        {

            InitializeComponent();
            ArtistList(username, password);
            user = username;
            pass = password;
        }
        public void ArtistList(string username, string password)
        {
            var login = new Login();
            LBArtist.ItemsSource = (List<Artist>)login.GetInfo(username, password);


        }

        private void LBArtist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBArtist.SelectedItem != null)
            {
                crud.SetSelectedArtist(LBArtist.SelectedItem);
                ArtistFields();
            }
        }
        private void ArtistFields()
        {
            if (crud.SelectedArtist != null)
            {
                TextName.Text = crud.SelectedArtist.Name;
                TextArtistName.Text = crud.SelectedArtist.ArtistName;
                TextSound.Text = crud.SelectedArtist.Soundcloud;
                TextSpo.Text = crud.SelectedArtist.Spotify;
                TextSocial.Text = crud.SelectedArtist.Socials;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mngID = crud.SelectedArtist.ArtistId;
            crud.UpdateArtist(mngID, TextName.Text, TextArtistName.Text, TextSound.Text, TextSpo.Text, TextSocial.Text);
            this.NavigationService.Navigate(new ArtistView(user, pass));


        }
    }


}
