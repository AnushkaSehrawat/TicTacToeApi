using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeAssignment.Model;

namespace TicTacToeAssignment
{
    public interface IRepository
    {
        void AddToDB(User userObject);
        string GetFromDB(int id);
    }
}
