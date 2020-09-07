using Project;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Linq;
using Microsoft.Win32;

namespace UpCloudGui
{
    /// <summary>
    /// Interaction logic for ArtistView.xaml
    /// </summary>
    public partial class ArtistView : Page
    {
        string user;
        string pass;
        int IndependentArtistID;
        CRUDManager crud = new CRUDManager();
        Read read = new Read();
        Login login = new Login();
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
        public ArtistView(string username, string password, int independent)
        {

            InitializeComponent();
            IndependentArtistID = independent;
            user = username;
            pass = password;
            LBArtist.Visibility = Visibility.Hidden;
            LBSong.Visibility = Visibility.Visible;
            LArtist.Visibility = Visibility.Hidden;
            LSongs.Visibility = Visibility.Visible;
            BtnSongs.Visibility = Visibility.Hidden;
            AFields.Visibility = Visibility.Hidden;
            SFields.Visibility = Visibility.Visible;
            BtnLogOut.Visibility = Visibility.Hidden;
            BtnHomeArtist.Visibility = Visibility.Visible;


            SongList(independent);

        }
        public void ArtistList(string username, string password)
        {


            LBArtist.ItemsSource = (List<Artist>)login.GetInfo(username, password);


        }


        private void LBArtist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBArtist.SelectedItem != null)
            {
                crud.SetSelectedArtist(LBArtist.SelectedItem);
                BtnAUpdate.Visibility = Visibility.Visible;
                ArtistFields();
            }
        }
        private void LBSong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBSong.SelectedItem != null)
            {
                BtnSUpdate.Visibility = Visibility.Visible;
                musicIcon.Visibility = Visibility.Visible;
                crud.SetSSelectedSong(LBSong.SelectedItem);
                SongFields();
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
        private void SongFields()
        {
            if (crud.SelectedSong != null)
            {
                TextSName.Text = crud.SelectedSong.Name;
                TextSGenre.Text = crud.SelectedSong.Genre;
                TextSSound.Text = crud.SelectedSong.SoundcloudUrl;
                TextSSpo.Text = crud.SelectedSong.SpotifyUrl;
                TextSFile.Text = crud.SelectedSong.SongFile;
                TextSStatus.Content = crud.SelectedSong.Status;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mngID = crud.SelectedArtist.ArtistId;
            crud.UpdateArtist(mngID, TextName.Text, TextArtistName.Text, TextSound.Text, TextSpo.Text, TextSocial.Text);
            this.NavigationService.Navigate(new ArtistView(user, pass));


        }

        private void AddArtist(object sender, RoutedEventArgs e)
        {
            var mngID = login.GetID(user, pass);
            crud.CreateArtist(TextName.Text, (int)mngID, TextArtistName.Text, TextSound.Text, TextSpo.Text, TextSocial.Text);
            this.NavigationService.Navigate(new ArtistView(user, pass));


        }
        private void DeleteArtist(object sender, RoutedEventArgs e)
        {
            var artistID = crud.SelectedArtist.ArtistId;
            // var artID = crud.SelectedSong.SongId;

            crud.DeleteArtist((int)artistID);
            this.NavigationService.Navigate(new ArtistView(user, pass));

        }
        private void UpdateSong(object sender, RoutedEventArgs e)
        {
            var artistID = crud.SelectedSong.ArtistId;
            var artID = crud.SelectedSong.SongId;
            crud.UpdateSong(artID, TextSName.Text, TextSGenre.Text, TextSSound.Text, TextSSpo.Text, TextSFile.Text);
            //this.NavigationService.Navigate(new ArtistView(user, pass));
            SongList((int)artistID);

        }
        private void AddSong(object sender, RoutedEventArgs e)
        {
            int artID;
            if (crud.SelectedArtist == null)
            {
                artID = IndependentArtistID;

            }
            else
            {
                artID = crud.SelectedArtist.ArtistId;
            }
            crud.CreateSong(TextSName.Text, (int)artID, TextSGenre.Text, TextSSound.Text, TextSSpo.Text, TextSFile.Text);
            //this.NavigationService.Navigate(new ArtistView(user, pass));
            SongList((int)artID);

        }

        private void DeleteSong(object sender, RoutedEventArgs e)
        {
            var artistID = crud.SelectedSong.ArtistId;
            var artID = crud.SelectedSong.SongId;
            crud.DeleteSong(artID);
            //this.NavigationService.Navigate(new ArtistView(user, pass));
            SongList((int)artistID);
        }
        private void SongList(int artistID)
        {
            if (artistID == IndependentArtistID)
            {
                BtnHomeArtist.Visibility = Visibility.Hidden;
                BtnLogOut.Visibility = Visibility.Visible;
            }
            LBSong.ItemsSource = (List<Song>)read.RetrieveSongs(artistID);


        }
        private void Song_Click(object sender, RoutedEventArgs e)
        {
            LBArtist.Visibility = Visibility.Hidden;
            LBSong.Visibility = Visibility.Visible;
            LArtist.Visibility = Visibility.Hidden;
            LSongs.Visibility = Visibility.Visible;
            BtnSongs.Visibility = Visibility.Hidden;
            AFields.Visibility = Visibility.Hidden;
            SFields.Visibility = Visibility.Visible;
            BtnLogOut.Visibility = Visibility.Hidden;
            BtnHomeArtist.Visibility = Visibility.Visible;

            if (crud.SelectedArtist != null)
            {
                int artistID = crud.SelectedArtist.ArtistId;
                SongList(artistID);
            }
        }

        private void BtnHomeArtist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new ArtistView(user, pass));
        }

        private void BtnLogOut_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LoginIn login = new LoginIn();
            this.NavigationService.Navigate(login);
        }

        private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (player.Source == new Uri(crud.SelectedSong.SongFile))
            {
                player.Stop();

            }
            else
            {
                player.LoadedBehavior = MediaState.Manual;
                player.Source = new Uri(crud.SelectedSong.SongFile);
                player.Play();
            }
        }

        private void TextSFile_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool? resposnse = openFileDialog.ShowDialog();

            if (resposnse == true)
            {
                string filepath = openFileDialog.FileName;
                TextSFile.Text = filepath;
            }
        }
    }


}
