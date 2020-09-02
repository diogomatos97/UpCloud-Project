using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpCloudLogic
{
    class Login
    {
        public int GetInfo(string username, string password)
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
        public bool IsIndependent(string name)
        {

            using (var db = new ProjectContext())
            {
                var independentCheck = from m in db.Manager
                                       join a in db.Artist on m.Name equals a.Name
                                       select new { m.ManagerId, a.ArtistId };

                if (independentCheck.Count() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }


}
