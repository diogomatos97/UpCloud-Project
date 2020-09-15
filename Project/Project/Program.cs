using System;
using System.Linq;
namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ProjectContext())
            {
                var independentCheck = from m in db.Manager.AsQueryable()
                                       join a in db.Artist on m.Name equals a.Name
                                       select new { m.ManagerId, a.ArtistId };

            }
        }
    }
}
