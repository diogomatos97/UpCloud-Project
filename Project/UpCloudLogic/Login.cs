using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpCloudLogic
{
    class Login
    {
        public object GetInfo(string username, string password)
        {
            using (var db = new ProjectContext())
            {
                try
                {
                    var mngID = GetID(username, password);
                    var artistID = IsIndependent(db.Manager.Where(m => m.ManagerId == mngID).FirstOrDefault().Name);
                    if (artistID != 0)
                    {
                        return Read.RetrieveSongs(artistID);
                    }
                    else
                    {
                        return Read.RetrieveArtists(mngID);
                    }
                }
                catch (Exception e)
                {
                    return e;
                }

            }
        }
        public int GetID(string username, string password)
        {
            using (var db = new ProjectContext())
            {

                bool status = LoginCheck(username, password);

                if (status == true)
                {
                    var getInfo = db.Manager.Where(c => c.Username == username.GetHashCode().ToString() && c.Password == password.GetHashCode().ToString()).FirstOrDefault();
                    return getInfo.ManagerId;
                }

                else
                {
                    throw new Exception("The details provided are not correct!");
                }


            }
        }
        public bool LoginCheck(string username, string password)
        {
            using (var db = new ProjectContext())
            {
                var login = db.Manager.Where(c => c.Username == username.GetHashCode().ToString() && c.Password == password.GetHashCode().ToString()).FirstOrDefault();
                if (login != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        public int IsIndependent(string name)
        {

            using (var db = new ProjectContext())
            {
                var independentCheck = from m in db.Manager
                                       join a in db.Artist on m.Name equals a.Name
                                       where m.Name == name
                                       select new { m.ManagerId, a.ArtistId };

                if (independentCheck.Count() == 1)
                {
                    return independentCheck.FirstOrDefault().ArtistId;
                }
                else
                {
                    return 0;
                }
            }

        }
    }


}
