using NUnit.Framework;
using UpCloudLogic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project;
using System.Collections.Generic;

namespace UpCloudLogic_Tests
{
    public class Tests
    {   //register and login tests
        CRUDManager _crud = new CRUDManager();
        Login _login = new Login();

        [SetUp]
        public void Setup()
        {

        }


        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void Test1RegisterNewManager()
        {
            using (var db = new ProjectContext())
            {
                var count = db.Manager.Count();
                _crud.CreateManager("Diogo Filipe", "Dmatos1", "Dmatos1", "dmatos@gmail.com");


                var countAfter = db.Manager.Count();
                Assert.AreEqual(count + 1, countAfter);
                var uName = "Dmatos1";

                db.Remove(db.Manager.Where(m => m.Username == uName.ToString()).FirstOrDefault());
                db.SaveChanges();
            }

        }
        [Test]
        public void Test2RegisterIndependentArtist()
        {
            using (var db = new ProjectContext())
            {
                var count = db.Manager.Count();
                _crud.CreateIndependent("Diogo Filipe2", "Dmatos2", "Dmatos1", "dmatos@gmail.com", "SKALL", "sound.com", "spot.com", "@skallMusic");
                var countAfter = db.Manager.Count();
                Assert.AreEqual(count + 1, countAfter);
                var uName = "Dmatos2";
                var manager = db.Manager.Where(m => m.Username == uName.ToString()).FirstOrDefault();
                var artist = db.Artist.Where(a => a.ManagerId == manager.ManagerId).FirstOrDefault();
                Assert.AreEqual(manager.Name, artist.Name);
                db.Remove(artist);
                db.SaveChanges();
                db.Remove(manager);
                db.SaveChanges();
            }
        }
        [Test]
        public void Test3ManagerLogin()
        {
            using (var db = new ProjectContext())
            {
                var newManager = new Manager()
                {
                    Name = "Diogo Filipe",
                    Username = "Dmatos3".ToString(),
                    Password = "Dmatos1".ToString(),
                    Email = "dmatos@gmail.com"
                };
                db.Manager.Add(newManager);

                db.SaveChanges();
                var uName = "Dmatos3";
                var managerID = db.Manager.Where(m => m.Username == uName..ToString()).FirstOrDefault();

                var list = new List<Artist>();
                list.Add(new Artist() { ArtistName = "SKALL", ManagerId = managerID.ManagerId, Name = "Diogo Matos", Soundcloud = "sound.com", Spotify = "spot.com", Socials = "@skallMusic" });

                var id = _login.GetID("Dmatos3", "Dmatos1");
                var newArtist = new Artist() { ArtistName = "SKALL", ManagerId = managerID.ManagerId, Name = "Diogo Matos", Soundcloud = "sound.com", Spotify = "spot.com", Socials = "@skallMusic" };
                db.Artist.Add(newArtist);
                db.SaveChanges();
                var message = _login.GetInfo("Dmatos3", "Dmatos1");
                Assert.AreEqual(message.GetType(), list.GetType());
                Assert.AreEqual(message.ToString(), list.ToString());
                var artist = db.Artist.Where(a => a.ManagerId == managerID.ManagerId).FirstOrDefault();
                db.Remove(artist);
                db.SaveChanges();
                db.Remove(managerID);
                db.SaveChanges();
            }

        }
        [Test]
        public void Test4IndependetArtistLogin()
        {
            using (var db = new ProjectContext())
            {
                var newManager = new Manager()
                {
                    Name = "Diogo",
                    Username = "Dmatos3".ToString(),
                    Password = "Dmatos1".ToString(),
                    Email = "dmatos@gmail.com"
                };
                db.Manager.Add(newManager);

                db.SaveChanges();
                var uName = "Dmatos3";
                var manager = db.Manager.Where(m => m.Username == uName.ToString()).FirstOrDefault();


                var id = _login.GetID("Dmatos3", "Dmatos1");
                var newArtist = new Artist() { ArtistName = "SKALL", ManagerId = manager.ManagerId, Name = "Diogo", Soundcloud = "sound.com", Spotify = "spot.com", Socials = "@skallMusic" };
                db.Artist.Add(newArtist);
                db.SaveChanges();
                var artist = db.Artist.Where(a => a.ManagerId == manager.ManagerId).FirstOrDefault();
                var newSong = new Song() { Name = "Rain", ArtistId = artist.ArtistId, Genre = "Lo-fi", SoundcloudUrl = "sound.com", SpotifyUrl = "", SongFile = "" };
                db.Song.Add(newSong);
                db.SaveChanges();

                var list = new List<Song>();
                list.Add(newSong);


                var message = _login.GetInfo("Dmatos3", "Dmatos1");
                Assert.AreEqual(message.GetType(), list.GetType());
                Assert.AreEqual(message.ToString(), list.ToString());
                var song = db.Song.Where(a => a.ArtistId == artist.ArtistId && a.Name == "Rain").FirstOrDefault();
                db.Remove(song);
                db.SaveChanges();
                db.Remove(artist);
                db.SaveChanges();
                db.Remove(manager);
                db.SaveChanges();
            }
        }
    }
}