using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeAssignment.Model;

namespace TicTacToeAssignment
{
    public class Sql : IRepo
    {
        SqlConnection conobject = new SqlConnection();
        SqlCommand cmd;
        string query;
        string response;
        public string AddToDB(User userObject)
        {
            string email = null;
            response = null;
            conobject.ConnectionString = "Data Source=TAVDESK087;Initial Catalog=TicTacToeDB;Integrated Security=True";
            conobject.Open();
            query = "Select * from Users where Email=@email";
            cmd = new SqlCommand(query, conobject);
            cmd.Parameters.Add(new SqlParameter("@email", userObject.Email));
            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                email = datareader["Email"].ToString();
            }
            datareader.Close();
            if (email == null)
            {
                string token = Guid.NewGuid().ToString();
                userObject.AccessToken = token;
                query = "insert into Users values(@Fname,@Lname,@Email,@AccessToken)";
                cmd = new SqlCommand(query, conobject);
                cmd.Parameters.Add(new SqlParameter("@Fname", userObject.FirstName));
                cmd.Parameters.Add(new SqlParameter("@Lname", userObject.LastName));
                cmd.Parameters.Add(new SqlParameter("@Email", userObject.Email));
                cmd.Parameters.Add(new SqlParameter("@AccessToken", userObject.AccessToken));

                cmd.ExecuteNonQuery();
                response = "User Successfully added";
            }

            conobject.Close();
            return response;
        }



        public string GetFromDB(int id)
        {
            string token = null;
            conobject.ConnectionString = "Data Source=TAVDESK087;Initial Catalog=TicTacToeDB;Integrated Security=True";
            conobject.Open();
            string query = "select * from Users where UserId= @id";
            SqlCommand cmd = new SqlCommand(query, conobject);
            cmd.Parameters.Add(new SqlParameter("@id", id));

            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                token = datareader["AccessToken"].ToString();
            }

            return token;


        }

        public void addlog(Logger logObject)
        {
            conobject.ConnectionString = "Data Source=TAVDESK087;Initial Catalog=TicTacToeDB;Integrated Security=True";
            conobject.Open();
            query = "insert into Logs values(@Request,@Response,@Exception)";
            cmd = new SqlCommand(query, conobject);
            cmd.Parameters.Add(new SqlParameter("@Request", logObject.Request));
            cmd.Parameters.Add(new SqlParameter("@Response", logObject.Response));
            cmd.Parameters.Add(new SqlParameter("@Exception", logObject.Exception));

            cmd.ExecuteNonQuery();
            conobject.Close();
        }
    }
}
