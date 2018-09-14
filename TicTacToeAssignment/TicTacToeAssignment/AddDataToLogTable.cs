using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeAssignment.Model;

namespace TicTacToeAssignment
{
    public class AddDataToLogTable
    {
        SqlConnection conobject = new SqlConnection();
        SqlCommand cmd;
        string query;
       
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
