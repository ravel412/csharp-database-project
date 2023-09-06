using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WinFormsApp3
{
    public class funksiyon
    {

        public static string connectionadress1 = "";
      
        public static void baglanti(SqlConnection temp )
        {
            if (temp.State == ConnectionState.Closed)
            {

                temp.Open();
            }
            else
            {


            }

        }
    
    }
}
