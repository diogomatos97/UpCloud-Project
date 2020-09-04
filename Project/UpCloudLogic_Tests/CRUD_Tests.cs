using NUnit.Framework;
using UpCloudLogic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                var newManager = new Manager()
                {
                    Name = "Diogo Filipe",
                    Username = "Dmatos3".GetHashCode().ToString(),
                    Password = "Dmatos1".GetHashCode().ToString(),
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
                var uName = "Dmatos3";
                var managerID = db.Manager.Where(m => m.Username == uName.GetHashCode().ToString()).FirstOrDefault();
                var artist1 = db.Artist.Where(a => a.ManagerId == managerID.ManagerId).FirstOrDefault();
                var song = db.Song.Where(s => s.Artist == artist1).FirstOrDefault();
                if (song != null)
                {
                    db.Remove(song);


                    db.SaveChanges();
                }

                db.Remove(artist1);


                db.SaveChanges();
                db.Remove(managerID);
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
                var managerID = db.Manager.Where(m => m.Username == uName.GetHashCode().ToString()).FirstOrDefault();
                _crud.CreateArtist("Diogo", managerID.ManagerId, "SKALL", "soundcloud.com", "Spotify.com", "@Skullcrap");


                var countAfter = db.Artist.Count();
                Assert.AreEqual(count + 1, countAfter);

            }
        }
        [Test]
        public void UpdateArtist()
        {
            using (var db = new ProjectContext())
            {
                var uName = "Dmatos3";
                var managerID = db.Manager.Where(m => m.Username == uName.GetHashCode().ToString()).FirstOrDefault();
                var newArtist = new Artist() { ArtistName = "SKAL3L", ManagerId = managerID.ManagerId, Name = "Diogo", Soundcloud = "sound.com", Spotify = "spot.com", Socials = "@skallMusic" };
                db.Artist.Add(newArtist);
                db.SaveChanges();
                var uName2 = "SKAL3L";
                var artistID = db.Artist.Where(m => m.ArtistName == uName2 && m.Manager == managerID).FirstOrDefault();
                _crud.UpdateArtist(artistID.ArtistId, "Diogo", "", "soundcloud.com", "Spotify.com", "@Skullcrap");

                var currArtist = db.Artist.Where(m => m.ArtistName == "").FirstOrDefault();
                Assert.AreEqual(currArtist.ArtistName, "");
            }
        }
        [Test]
        public void CreateSong()
        {
            using (var db = new ProjectContext())
            {
                var uName = "Dmatos3";
                var managerID = db.Manager.Where(m => m.Username == uName.GetHashCode().ToString()).FirstOrDefault();
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
                var managerID = db.Manager.Where(m => m.Username == uName.GetHashCode().ToString()).FirstOrDefault();
                var newArtist = new Artist() { ArtistName = "SKAL3L", ManagerId = managerID.ManagerId, Name = "Diogo", Soundcloud = "sound.com", Spotify = "spot.com", Socials = "@skallMusic" };
                db.Artist.Add(newArtist);
                db.SaveChanges();
                var uName2 = "SKAL3L";
                var artistID = db.Artist.Where(m => m.ArtistName == uName2).FirstOrDefault();
                var newSong = new Song() { Name = "Rain", ArtistId = artistID.ArtistId, Genre = "Lo-fi", SoundcloudUrl = "sound.com", SpotifyUrl = "", SongFile = "" };
                db.Add(newSong);
                db.SaveChanges();
                var song = db.Song.Where(m => m.ArtistId == artistID.ArtistId && m.Name == "Rain").FirstOrDefault();
                _crud.UpdateSong(song.SongId, "Not Rain", "Lo-fi", "", "", "");
                var currsong = db.Song.Where(m => m.ArtistId == artistID.ArtistId && m.Name == "Not Rain").FirstOrDefault();
                Assert.AreNotEqual(newSong.Name, currsong.Name);
            }
        }
    }
}
