using System;
using System.Collections.Generic;

namespace Project
{
    public partial class Manager
    {
        public Manager()
        {
            Artist = new HashSet<Artist>();
        }

        public int ManagerId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Artist> Artist { get; set; }
    }
}
