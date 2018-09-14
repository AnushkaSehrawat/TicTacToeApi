using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeAssignment
{
    public class Authorization
    {
        SqlConnection conobject = new SqlConnection();
        SqlCommand cmd;
        string query;
        string response;
        public string AuthenticateUser(string tokenaccess)
        {
            string token = null;
            response = null; 
            if (conobject.State != System.Data.ConnectionState.Open)
            {
                conobject.ConnectionString = "Data Source=TAVDESK087;Initial Catalog=TicTacToeDB;Integrated Security=True";
                conobject.Open();
            }
            query = "select * from Users where AccessToken = @acesstoken";

            SqlCommand cmd = new SqlCommand(query, conobject);
            cmd.Parameters.Add(new SqlParameter("@acesstoken", tokenaccess));
            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                token = datareader["AccessToken"].ToString();
            }
            datareader.Close();
            if (token != null)
            {
                response = "Valid Key";
            }
            return response;
        }
    }
}
