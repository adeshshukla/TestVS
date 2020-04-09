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
    public class CourseBranchMappingRepository : Repository<CourseBranchMapping>, ICourseBranchMappingRepository
    {
        public CourseBranchMappingRepository(SWANDBEntities context) : base(context)
        {

        }
    }
}
