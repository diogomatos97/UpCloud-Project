using NUnit.Framework;
using UpCloudLogic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Project;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace UpCloudLogic_Tests
{



    class CRUD_Tests
    {
        CRUDManager _crud = new CRUDManager();
        Login _login = new Login();


        [SetUp]
        public void Setup()
        {
            using (var db = new ProjectContext())
            {
                var deletes = db.Song;
                foreach (var item in deletes)
                {
                    db.Remove(item);

                }
                db.SaveChanges();
                var deletea = db.Artist;
                foreach (var item in deletea)
                {
                    db.Remove(item);

                }
                db.SaveChanges();
                var deletem = db.Manager;
                foreach (var item in deletem)
                {
                    db.Remove(item);

                }
                db.SaveChanges();
                db.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Song',RESEED,0);");
                db.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Artist',RESEED,0);");
                db.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Manager',RESEED,0);");

                var newManager = new Manager()
                {
                    Name = "Diogo Filipe",
                    Username = "Dmatos3".ToString(),
                    Password = "Dmatos1".ToString(),
                    Email = "dmatos@gmail.com"
                };
                db.Manager.Add(newManager);

                db.SaveChanges();
            }
        }
        [TearDown]

        public void TearDown()
        {
            using (var db = new ProjectContext())
            {
                //    var uName = "Dmatos3";
                //    var managerID = db.Manager.Where(m => m.Username == uName.GetHashCode().ToString()).FirstOrDefault();
                //    var artist1 = db.Artist.Where(a => a.ArtistId == 1).FirstOrDefault();
                //    var song = db.Song.Where(s => s.ArtistId == 1);
                //    if (song != null)
                //    {
                //        foreach (var item in song)
                //        {
                //            db.Remove(item);
                //        }



                //        db.SaveChanges();
                //    }

                //    db.Remove(artist1);


                //    db.SaveChanges();
                //    db.Remove(managerID);
                //    db.SaveChanges();

                var deletes = db.Song;
                foreach (var item in deletes)
                {
                    db.Remove(item);

                }
                db.SaveChanges();
                var deletea = db.Artist;
                foreach (var item in deletea)
                {
                    db.Remove(item);

                }
                db.SaveChanges();
                var deletem = db.Manager;
                foreach (var item in deletem)
                {
                    db.Remove(item);

                }
                db.SaveChanges();
            }
        }
        [Test]
        public void CreateArtist()
        {
            using (var db = new ProjectContext())
            {
                var count = db.Artist.Count();
                var uName = "Dmatos3";
                var managerID = db.Manager.Where(m => m.Username == uName.ToString()).FirstOrDefault();
                _crud.CreateArtist("Diogo", managerID.ManagerId, "SKALL", "soundcloud.com", "Spotify.com", "@Skullcrap");

                var selectedArtist = db.Artist.Find(1);

                var countAfter = db.Artist.Count();
                Assert.AreEqual(count + 1, countAfter);
                Assert.AreEqual("Diogo", selectedArtist.Name);
                Assert.AreEqual("SKALL", selectedArtist.ArtistName);
                Assert.AreEqual("soundcloud.com", selectedArtist.Soundcloud);
                Assert.AreEqual("Spotify.com", selectedArtist.Spotify);

            }
        }
        [Test]
        public void UpdateArtist()
        {
            using (var db = new ProjectContext())
            {
                //var uName = "Dmatos3";
                //var managerID = db.Manager.Where(m => m.Username == uName.GetHashCode().ToString()).FirstOrDefault();
                var newArtist = new Artist() { ArtistName = "SKAL3L", ManagerId = 1, Name = "Diogo", Soundcloud = "sound.com", Spotify = "spot.com", Socials = "@skallMusic" };
                db.Add(newArtist);
                db.SaveChanges();


                _crud.UpdateArtist(1, "Diogo", "", "soundcloud.com", "Spotify.com", "@Skullcrap");

                var currArtist = db.Artist.Find(1);
                //var currArtist = from a in db.Artist
                //                 where a.ArtistId == 1
                //                 select a;
                //foreach (var item in currArtist)
                //{   
                //    Assert.AreEqual("", item.ArtistName);
                //}

                Assert.AreEqual("", currArtist.ArtistName);
            }
        }
        [Test]
        public void CreateSong()
        {
            using (var db = new ProjectContext())
            {
                var uName = "Dmatos3";
                var managerID = db.Manager.Where(m => m.Username == uName.ToString()).FirstOrDefault();
                var newArtist = new Artist() { ArtistName = "SKAL3L", ManagerId = managerID.ManagerId, Name = "Diogo", Soundcloud = "sound.com", Spotify = "spot.com", Socials = "@skallMusic" };
                db.Artist.Add(newArtist);
                db.SaveChanges();
                var uName2 = "SKAL3L";
                var artistID = db.Artist.Where(m => m.ArtistName == uName2).FirstOrDefault();
                var count = db.Song.Count();
                _crud.CreateSong("RAIN", artistID.ArtistId, "Lo-fi", "", "", "");
                var countAfter = db.Song.Count();
                Assert.AreEqual(count + 1, countAfter);
            }
        }
        [Test]
        public void UpdateSong()
        {
            using (var db = new ProjectContext())
            {
                var uName = "Dmatos3";
                var managerID = db.Manager.Where(m => m.Username == uName.ToString()).FirstOrDefault();
                var newArtist = new Artist() { ArtistName = "SKAL2L", ManagerId = managerID.ManagerId, Name = "Diogo", Soundcloud = "sound.com", Spotify = "spot.com", Socials = "@skallMusic" };
                db.Artist.Add(newArtist);
                db.SaveChanges();

                var artistID = db.Artist.Where(m => m.ArtistName == "SKAL2L").FirstOrDefault();
                var newSong = new Song() { Name = "Rain2", ArtistId = artistID.ArtistId, Genre = "Lo-fi", SoundcloudUrl = "sound.com", SpotifyUrl = "", SongFile = "" };
                db.Add(newSong);
                db.SaveChanges();
                var song = db.Song.Where(m => m.Name == "Rain2").FirstOrDefault();
                _crud.UpdateSong(artistID.ArtistId, "Not Rain", "Lo-fi", "", "", "");
                db.SaveChanges();
                var currsong = db.Song.Where(s => s.ArtistId == 1);
                foreach (var item in currsong)
                {
                    Assert.AreEqual("Not Rain", item.Name);
                }

            }
        }
        [Test]
        public void GetUnPublished()
        {
            using (var db = new ProjectContext())
            {

                var uName = "Dmatos3";
                var managerID = db.Manager.Where(m => m.Username == uName.ToString()).FirstOrDefault();
                var newArtist = new Artist() { ArtistName = "SKAL2L", ManagerId = managerID.ManagerId, Name = "Diogo", Soundcloud = "sound.com", Spotify = "spot.com", Socials = "@skallMusic" };
                db.Artist.Add(newArtist);
                db.SaveChanges();

                var artistID = db.Artist.Where(m => m.ArtistName == "SKAL2L").FirstOrDefault();
                var newSong = new Song() { Name = "Rain2", ArtistId = artistID.ArtistId, Genre = "Lo-fi", SoundcloudUrl = "sound.com", SpotifyUrl = "", SongFile = "", Status = "Published" };
                db.Add(newSong);
                db.SaveChanges();
                var newSong2 = new Song() { Name = "Rain", ArtistId = artistID.ArtistId, Genre = "Lo-fi", SoundcloudUrl = "", SpotifyUrl = "", SongFile = "", Status = "Not Published" };
                db.Add(newSong2);
                db.SaveChanges();

                Read read = new Read();

                var list = read.UnpublishedSongs(artistID.ArtistId);
                Assert.AreEqual(list.Count, 1);


            }

        }


        [Test]
        public void GetPublished()
        {
            using (var db = new ProjectContext())
            {

                var uName = "Dmatos3";
                var managerID = db.Manager.Where(m => m.Username == uName.ToString()).FirstOrDefault();
                var newArtist = new Artist() { ArtistName = "SKAL2L", ManagerId = managerID.ManagerId, Name = "Diogo", Soundcloud = "sound.com", Spotify = "spot.com", Socials = "@skallMusic" };
                db.Artist.Add(newArtist);
                db.SaveChanges();

                var artistID = db.Artist.Where(m => m.ArtistName == "SKAL2L").FirstOrDefault();
                var newSong = new Song() { Name = "Rain2", ArtistId = artistID.ArtistId, Genre = "Lo-fi", SoundcloudUrl = "sound.com", SpotifyUrl = "", SongFile = "", Status = "Published" };
                db.Add(newSong);
                db.SaveChanges();
                var newSong2 = new Song() { Name = "Rain", ArtistId = artistID.ArtistId, Genre = "Lo-fi", SoundcloudUrl = "", SpotifyUrl = "", SongFile = "", Status = "Not Published" };
                db.Add(newSong2);
                db.SaveChanges();

                Read read = new Read();

                var list = read.PublishedSongs(1);
                Assert.AreEqual(list.Count, 1);


            }
        }

    }
}
