using Microsoft.EntityFrameworkCore;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UpCloudLogic
{
    public class CRUDManager
    {
        static void Main(string[] args)
        {
            //CreateManager("Diogo", "diogo97", "diogo97", "diogo97@gmail.com", "label1");
            //CreateManager("Diogo", "diogo97", "diogo97", "diogo97@gmail.com", "label1");
            //CreateArtist("Diogo", 1, "SKALL", "soundcloud.com", "Spotify.com", "@Skullcrap");
            //CreateSong("Rain", 1, "Lo-fi", "soundcloud.com/rain", "", "");
        }
        public void CreateManager(string name, string username, string password, string email, string label)
        {

            using (var db = new ProjectContext())
            {
                bool alreadyExists = CheckIfExists(username);
                if (alreadyExists == true)
                {
                    string existMessage = "Username is already taken";
                }
                else
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
        }
        public void CreateManager(string name, string username, string password, string email)
        {

            using (var db = new ProjectContext())
            {
                bool alreadyExists = CheckIfExists(username);
                if (alreadyExists == true)
                {
                    string existMessage = "Username is already taken";
                }
                else
                {
                    var newManager = new Manager()
                    {
                        Name = name.Trim(),
                        Username = username.Trim().GetHashCode().ToString(),
                        Password = password.Trim().GetHashCode().ToString(),
                        Email = email.Trim()


                    };


                    db.Manager.Add(newManager);

                    db.SaveChanges();
                }
            }
        }
        public void CreateIndependent(string name, string username, string password, string email, string artistName, string soundcloud, string spotify, string socials)
        {
            using (var db = new ProjectContext())
            {
                bool alreadyExists = CheckIfExists(username);
                if (alreadyExists == true)
                {
                    string existMessage = "Username is already taken";
                }
                else
                {
                    var newManager = new Manager()
                    {
                        Name = name.Trim(),
                        Username = username.Trim().GetHashCode().ToString(),
                        Password = password.Trim().GetHashCode().ToString(),
                        Email = email.Trim(),


                    };
                    var newArtist = new Artist()
                    {
                        Name = name.Trim(),
                        ManagerId = newManager.ManagerId,
                        ArtistName = artistName,
                        Soundcloud = soundcloud,
                        Spotify = spotify,
                        Socials = socials


                    };

                    db.Manager.Add(newManager);
                    db.Artist.Add(newArtist);
                    db.SaveChanges();
                }
            }
        }
        public void CreateArtist(string name, int managerID, string artistName, string soundcloud, string spotify, string socials)
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
        public void CreateSong(string name, int artistID, string genre, string soundcloudURL, string spotifyURL, string songFile)
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
        public void UpdateArtist(int artistID, string name, string artistName, string soundcloud, string spotify, string socials)
        {
            using (var db = new ProjectContext())
            {
                var currArtist = db.Artist.Where(a => a.ArtistId == artistID).FirstOrDefault();

                currArtist.Name = name.Trim();
                currArtist.ArtistName = artistName;
                currArtist.Soundcloud = soundcloud;
                currArtist.Spotify = spotify;
                currArtist.Socials = socials;


                db.Artist.Update(currArtist);

                db.SaveChanges();
            }
        }
        public void UpdateSong(int songID, string name, string genre, string soundcloudURL, string spotifyURL, string songFile)
        {
            using (var db = new ProjectContext())
            {
                var currSong = db.Song.Where(s => s.SongId == songID).FirstOrDefault();

                currSong.Name = name.Trim();
                currSong.Genre = genre;
                currSong.SoundcloudUrl = soundcloudURL;
                currSong.SpotifyUrl = spotifyURL;
                currSong.Status = spotifyURL != "" | soundcloudURL != "" ? "Published" : "Not Published";


                db.Song.Update(currSong);

                db.SaveChanges();
            }
        }

        public void DeleteSong(int songID)
        {
            using (var db = new ProjectContext())
            {
                var currSong = db.Song.Where(s => s.SongId == songID).FirstOrDefault();

                db.Song.Remove(currSong);
            }
        }
        public void DeleteArtist(int artistID)
        {
            using (var db = new ProjectContext())
            {
                var currArtist = db.Artist.Where(a => a.ArtistId == artistID).FirstOrDefault();
                var songs = db.Song.Where(s => s.ArtistId == currArtist.ArtistId);
                foreach (var item in songs)
                {
                    db.Song.Remove(item);
                }
                db.Artist.Remove(currArtist);
            }
        }
        public bool CheckIfExists(string username)
        {
            using (var db = new ProjectContext())
            {
                var currArtist = db.Manager.Where(m => m.Username == username).Count();
                if (currArtist != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

    }

}