using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_CRUD
{
    internal class MutantesRepository
    {
        private readonly string _connectionString;

        public MutantesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
