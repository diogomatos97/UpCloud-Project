using Project;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UpCloudLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateManager("Diogo", "diogo97", "diogo97", "diogo97@gmail.com", "label1");
            //CreateManager("Diogo", "diogo97", "diogo97", "diogo97@gmail.com", "label1");
            //CreateArtist("Diogo", 1, "SKALL", "soundcloud.com", "Spotify.com", "@Skullcrap");
            CreateSong("Rain", 1, "Lo-fi", "soundcloud.com/rain", "", "");
        }
        public static void CreateManager(string name, string username, string password, string email, string label)
        {

            using (var db = new ProjectContext())
            {


                var newManager = new Manager()
                {
                    Name = name.Trim(),
                    Username = username.Trim().GetHashCode().ToString(),
                    Password = password.Trim().GetHashCode().ToString(),
                    Email = email.Trim(),
                    Label = label.Trim()

                };


                db.Manager.Add(newManager);

                db.SaveChanges();
            }

        }

        public static void CreateArtist(string name, int managerID, string artistName, string soundcloud, string spotify, string socials)
        {
            using (var db = new ProjectContext())
            {
                var currManager = db.Manager.Where(m => m.ManagerId == managerID).FirstOrDefault();
                var newArtist = new Artist()
                {
                    Name = name.Trim(),
                    ManagerId = currManager.ManagerId,
                    ArtistName = artistName,
                    Soundcloud = soundcloud,
                    Spotify = spotify,
                    Socials = socials


                };
                db.Artist.Add(newArtist);

                db.SaveChanges();
            }
        }
        public static void CreateSong(string name, int artistID, string genre, string soundcloudURL, string spotifyURL, string songFile)
        {
            using (var db = new ProjectContext())
            {
                var currArtist = db.Artist.Where(a => a.ArtistId == artistID).FirstOrDefault();
                var newSong = new Song()
                {
                    Name = name,
                    ArtistId = currArtist.ArtistId,
                    Genre = genre,
                    SoundcloudUrl = soundcloudURL,
                    SpotifyUrl = spotifyURL,
                    SongFile = songFile,
                    Status = spotifyURL != "" | soundcloudURL != "" ? "Published" : "Not Published"


                };
                db.Song.Add(newSong);

                db.SaveChanges();
            }
        }
    }
}