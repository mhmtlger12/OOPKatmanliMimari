using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FacadeLayer
{
   public class SqlSonnect
    {
        public static SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-7DOUM90;Initial Catalog=DBKatmanliProje;Integrated Security=True");

    }
}
