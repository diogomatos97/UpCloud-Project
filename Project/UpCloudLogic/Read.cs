﻿using Microsoft.EntityFrameworkCore;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace UpCloudLogic
{
    public class Read
    {
        public List<Artist> RetrieveArtists(int managerID)
        {
            using (var db = new ProjectContext())
            {
                return db.Artist.Where(a => a.ManagerId == managerID).ToList();
            }

        }

        public List<Song> RetrieveSongs(int artistID)
        {
            using (var db = new ProjectContext())
            {
                return db.Song.Where(a => a.ArtistId == artistID).ToList();
            }
        }

        public List<Song> PublishedSongs(int artistID)
        {
            using (var db = new ProjectContext())
            {
                return db.Song.Where(a => a.ArtistId == artistID && a.Status == "Published").ToList();
            }
        }
        public List<Song> UnpublishedSongs(int artistID)
        {
            using (var db = new ProjectContext())
            {
                return db.Song.Where(a => a.ArtistId == artistID && a.Status == "Not Published").ToList();
            }
        }

        public List<string> PublishedByManager(int managerID)
        {
            using (var db = new ProjectContext())
            {
                var published = from a in db.Artist
                                join s in db.Song on a.ArtistId equals s.ArtistId
                                where a.ManagerId == managerID
                                select new { a.ArtistName, s.Name, s.Status };

                var list = new List<string>();
                foreach (var item in published)
                {
                    if (item.Status == "Published")
                    {
                        list.Add(item.ToString());
                    }

                }

                return list;
            }

        }
        public List<string> UnPublishedByManager(int managerID)
        {
            using (var db = new ProjectContext())
            {
                var published = from a in db.Artist
                                join s in db.Song on a.ArtistId equals s.ArtistId
                                where a.ManagerId == managerID
                                select new { a.ArtistName, s.Name, s.Status };

                var list = new List<string>();
                foreach (var item in published)
                {
                    if (item.Status == "Not Published")
                    {
                        list.Add(item.ToString());
                    }

                }

                return list;
            }
        }

    }

}
