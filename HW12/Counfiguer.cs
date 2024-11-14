using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12
{
    public static class Counfiguer
    {
        public static string Connectionstring { get; set; }
       static Counfiguer()
        {
            Connectionstring = @"Data Source=LEILI\LEILA;Initial Catalog=HW12-2;Integrated Security=true; TrustServerCertificate=True";
        }
    }
}
