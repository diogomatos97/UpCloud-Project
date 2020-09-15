﻿using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace UpCloudLogic
{

    public class Login
    {
        Read read = new Read();
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
                        return read.RetrieveSongs(artistID);
                    }
                    else
                    {
                        return read.RetrieveArtists(mngID);
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
                    var getInfo = db.Manager.Where(c => c.Username == username.ToString() && c.Password == password.ToString()).FirstOrDefault();
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
                var login = db.Manager.Where(c => c.Username == username.ToString() && c.Password == password.ToString()).FirstOrDefault();
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
                                       where a.Name == name
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

        public string GetName(string username, string password)
        {
            using (var db = new ProjectContext())
            {

                bool status = LoginCheck(username, password);

                if (status == true)
                {
                    var getInfo = db.Manager.Where(c => c.Username == username.ToString() && c.Password == password.ToString()).FirstOrDefault();
                    return getInfo.Name;
                }

                else
                {
                    throw new Exception("The details provided are not correct!");
                }


            }
        }
        public void Exists(string username, string password)
        {
            using (var db = new ProjectContext())
            {
                var login = db.Manager.Where(c => c.Username == username.ToString() && c.Password == password.ToString()).FirstOrDefault();
                if (login == null)
                {
                    throw new Exception("AA");
                }

            }

        }

    }
}
