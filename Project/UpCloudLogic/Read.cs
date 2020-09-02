using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UpCloudLogic
{
    class Read
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
    }
}
