using SWAN.Common.Models;
using SWAN.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAN.Services.Interfaces
{
    public interface ISessionService
    {
        CustomResponse GetAllSessions();

        CustomResponse InsertSession(SessionModel _session);

        CustomResponse DeleteSessionBySessionId(int _sessionId);

        #region Commented Code
        //CustomResponse GetSessionBrief(); 
        #endregion

    }
}
