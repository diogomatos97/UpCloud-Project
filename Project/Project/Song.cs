using System;
using System.Collections.Generic;

namespace Project
{
    public partial class Song
    {
        public int SongId { get; set; }
        public int? ArtistId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string SoundcloudUrl { get; set; }
        public string SpotifyUrl { get; set; }
        public string Status { get; set; }
        public string SongFile { get; set; }

        public virtual Artist Artist { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Status}";
        }
    }
}
