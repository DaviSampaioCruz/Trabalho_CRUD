using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_CRUD
{
    internal class ItensRepository
    {
        private readonly string _connectionString;

        public ItensRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
