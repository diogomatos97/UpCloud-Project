using System;
using System.Collections.Generic;

namespace Project
{
    public partial class Artist
    {
        public Artist()
        {
            Song = new HashSet<Song>();
        }

        public int ArtistId { get; set; }
        public int? ManagerId { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public string Soundcloud { get; set; }
        public string Spotify { get; set; }
        public string Socials { get; set; }

        public virtual Manager Manager { get; set; }
        public virtual ICollection<Song> Song { get; set; }
    }
}
