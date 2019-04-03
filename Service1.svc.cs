using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string checkCre(string userId, string password)
        {
            string role = "00", pwd = "oo";
            int flag = 0;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R5QLBIQ\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True");
            con.Open();
            string sql = "checkCre";
            SqlCommand command = new SqlCommand(sql, con);
            SqlParameter param1 = new SqlParameter("@uid", userId);
            command.Parameters.Add(param1);

            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                role = dr.GetString(1);
                pwd = dr.GetString(0);

            }
            con.Close();
            if (password.Equals(pwd))
            {
                return role;


            }
            else
            {
                return "wrong password";
            }

            

        }


        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
