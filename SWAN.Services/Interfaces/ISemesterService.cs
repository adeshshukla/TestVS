﻿using SWAN.Common.Models;
using SWAN.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAN.Services.Interfaces
{
    public interface ISemesterService
    {
        CustomResponse GetAllSemesters();

        CustomResponse InsertSemester(MasterModel _semester);

    }
}
