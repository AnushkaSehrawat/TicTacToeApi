using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeAssignment
{
    public class GetRepoInstance
    {
        IRepo Default = null;
        public IRepo getInstance(string instance)
        {
            
            if (instance=="sql")
            {
                return new Sql();
            }
            return Default;
        }
    }
}
