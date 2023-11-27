using Demo_var_6Last.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_var_6Last.DataB
{
    public class UserDB
    {
        public List<User> GetUsers()
        {
            return BaseDB.tradeContext.Users.ToList();
        }
    }
}
