﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UpCloudLogic
{
    public class CRUDManager
    {

        //CreateManager("Diogo", "diogo97", "diogo97", "diogo97@gmail.com", "label1");
        //CreateManager("Diogo", "diogo97", "diogo97", "diogo97@gmail.com", "label1");
        //CreateArtist("Diogo", 1, "SKALL", "soundcloud.com", "Spotify.com", "@Skullcrap");
        //CreateSong("Rain", 1, "Lo-fi", "soundcloud.com/rain", "", "");

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
                        Username = username.Trim(),
                        Password = password.Trim(),
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
                        Username = username.Trim(),
                        Password = password.Trim(),
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
                    throw new Exception("Username is already taken");
                }
                else
                {
                    var newManager = new Manager()
                    {
                        Name = name.Trim(),
                        Username = username.Trim(),
                        Password = password.Trim(),
                        Email = email.Trim(),


                    };


                    db.Manager.Add(newManager);
                    db.SaveChanges();
                    var getManagerID = db.Manager.Where(m => m.Username == username.ToString()).FirstOrDefault();
                    var newArtist = new Artist()
                    {
                        Name = name.Trim(),
                        ManagerId = getManagerID.ManagerId,
                        ArtistName = artistName,
                        Soundcloud = soundcloud,
                        Spotify = spotify,
                        Socials = socials


                    };
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
                string status;
                if (spotifyURL != "" | soundcloudURL != "")
                {
                    status = "Published";
                }
                else
                {

                    status = "Not Published";
                }
                var newSong = new Song()
                {
                    Name = name,
                    ArtistId = currArtist.ArtistId,
                    Genre = genre,
                    SoundcloudUrl = soundcloudURL,
                    SpotifyUrl = spotifyURL,
                    SongFile = songFile,
                    Status = status


                };
                db.Song.Add(newSong);

                db.SaveChanges();
            }
        }
        public void UpdateArtist(int artistID, string name, string artistName, string soundcloud, string spotify, string socials)
        {
            using (var db = new ProjectContext())
            {
                //var currArtist = from a in db.Artist
                //                 where a.ArtistId == artistID
                //                 select a;

                var currArtist = db.Artist.Find(artistID);




                currArtist.Name = name.Trim();
                currArtist.ArtistName = artistName.Trim();
                currArtist.Soundcloud = soundcloud;
                currArtist.Spotify = spotify;
                currArtist.Socials = socials;

                db.SaveChanges();

            }
        }
        public void UpdateSong(int songID, string name, string genre, string soundcloudURL, string spotifyURL, string songFile)
        {
            using (var db = new ProjectContext())
            {
                var currSong = from s in db.Song
                               where s.SongId == songID
                               select s;

                foreach (var item in currSong)
                {

                    item.Name = name;
                    item.Genre = genre;
                    item.SoundcloudUrl = soundcloudURL;
                    item.SpotifyUrl = spotifyURL;
                    item.Status = spotifyURL != "" | soundcloudURL != "" ? "Published" : "Not Published";


                }

                db.SaveChanges();

            }
        }

        public void DeleteSong(int songID)
        {
            using (var db = new ProjectContext())
            {
                var currSong = db.Song.Where(s => s.SongId == songID).FirstOrDefault();

                db.Song.Remove(currSong);
                db.SaveChanges();
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
                db.SaveChanges();
                db.Artist.Remove(currArtist);
                db.SaveChanges();

            }
        }
        public bool CheckIfExists(string username)
        {
            using (var db = new ProjectContext())
            {
                var currArtist = db.Manager.Where(m => m.Username == username.ToString()).Count();
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
        public Artist SelectedArtist { get; set; }
        public void SetSelectedArtist(object selectedItem)
        {
            SelectedArtist = (Artist)selectedItem;
        }
        public Song SelectedSong { get; set; }
        public void SetSSelectedSong(object selectedItem)
        {
            SelectedSong = (Song)selectedItem;
        }
    }

}