using Demo_var_6Last.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_var_6Last.DataB
{
    public static class PickUpPointDB
    {
        public static List<PickUpPoint> GetPoints()
        {
            return BaseDB.tradeContext.PickUpPoints.ToList();
        }
    }
}
