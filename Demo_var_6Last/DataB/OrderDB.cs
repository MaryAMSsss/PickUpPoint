using Demo_var_6Last.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_var_6Last.DataB
{
    public static class OrderDB
    {
        public static void AddOrder(Order order)
        {
            BaseDB.tradeContext.Orders.Add(order);
            BaseDB.tradeContext.SaveChanges();
        }
    }
}
