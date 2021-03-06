﻿using SWAN.Common.Response;
using SWAN.Data;
using SWAN.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAN.Repository.Repository
{
    public class CourseBranchSemesterMappingRepository : Repository<CourseBranchSemesterMapping>, ICourseBranchSemesterMappingRepository
    {
        public CourseBranchSemesterMappingRepository(SWANDBEntities context) : base(context)
        {

        }
    }
}
