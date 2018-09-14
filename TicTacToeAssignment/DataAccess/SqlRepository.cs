using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeAssignment.Model;

namespace DataAccess
{
    class SqlRepository : IRepository
    {
        SqlConnection conobject = new SqlConnection();
       
        public void AddToDB(User userObject)
        {
            conobject.ConnectionString = "Data Source=TAVDESK087;Initial Catalog=TicTacToeDB;Integrated Security=True";
            conobject.Open();
            string query = "insert into Users values(@Fname,@Lname,@Email,@AccessToken)";
            SqlCommand cmd = new SqlCommand(query, conobject);
            cmd.Parameters.Add(new SqlParameter("@Fname", userObject.FirstName));
            cmd.Parameters.Add(new SqlParameter("@Lname", userObject.LastName));
            cmd.Parameters.Add(new SqlParameter("@Email", userObject.Email));
            cmd.Parameters.Add(new SqlParameter("@AccessToken", userObject.AccessToken));

            cmd.ExecuteNonQuery();
            conobject.Close();
        }

        public string GetFromDB(int id)
        {
            string token=null;
            conobject.ConnectionString = "Data Source=TAVDESK087;Initial Catalog=TicTacToeDB;Integrated Security=True";
            conobject.Open();
            string query = "select from Users where id= @id";
            SqlCommand cmd = new SqlCommand(query, conobject);
            cmd.Parameters.Add(new SqlParameter("@id", id));
           
            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                token = datareader["AccessToken"].ToString();
            }

            return token;
           
        }
    }
}
