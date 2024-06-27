using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Utility
{
    public class ConnectionString
    {
        private static string cName = @"Data Source=WIN-FTJ1J5HGOHN\SQLEXPRESS;Initial Catalog=Business;Integrated Security=True";
        public static string CName
        {
            get => cName;
        }
    }
}
