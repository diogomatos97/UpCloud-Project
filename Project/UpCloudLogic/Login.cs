using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpCloudLogic
{
    class Login
    {
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
    }
}
