using SWAN.Common.Response;
using SWAN.Data;
using SWAN.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAN.Repository.Repository
{
    public class ProgramRepository : Repository<Program>, IProgramRepository
    {
        public ProgramRepository(SWANDBEntities context) : base(context)
        {

        }
    }
}
