using Microsoft.EntityFrameworkCore.Query.Internal;
using Project;
using System;
using System.Collections.Generic;
using System.Text;

namespace UpCloudLogic
{
    class Class1
    {

        static void Main(string[] args)
        {
            CRUDManager crud = new CRUDManager();
            crud.CreateManager("Diogo", "diogo97", "diogo97", "diogo97@gmail.com", "label1");
            crud.CreateArtist("Diogo2", 1, "SKALL", "soundcloud.com", "Spotify.com", "@Skullcrap");
            //crud.CreateSong("Rain", 1, "Lo-fi", "soundcloud.com/rain", "a", "");
            //crud.UpdateArtist(1, "Diogo", "", "soundcloud.com", "Spotify.com", "@Skullcrap");

            //Read read = new Read();

            //var a = read.RetrieveArtists(1);
            //var b = read.RetrieveSongs(1);
            //using (var db = new ProjectContext())
            //{


            //    foreach (var item in a)
            //    {
            //        Console.WriteLine(item.ArtistName);
            //    }
            //    foreach (var item in b)
            //    {
            //        Console.WriteLine(item.Name);
            //    }
            // }
        }
    }
}
