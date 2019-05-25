using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ygl.DbHelper;
using yglAPI.Models;
using yglAPI.Models;

namespace yglAPI.DbHelper.ModelDao
{
    public class UserDao : DaoBase<User, Int32>
    {
        public int? insertUser(User user)
        {
            return this.Insert(user);
        }

        public int deleteUser(int id)
        {
            return this.Delete(id);
        }

        public User getUser(int id)
        {
            return this.Get(id);
        }

        public User GetUser(string username,string password)
        {
            return Get("select * from [user] where username=@username and password=@password", new { username, password });
        }

    }
}
