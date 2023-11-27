using System;
using System.Collections.Generic;

namespace Demo_var_6Last.Models;

public partial class User
{
    public int UserId { get; set; }

    public int? RoleId { get; set; }

    public string? Lfp { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }
    //public User(string login, string pass) 
    //{ 
    //    Login = login;
    //    Password = pass;
    //}

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual Role? Role { get; set; }
}
