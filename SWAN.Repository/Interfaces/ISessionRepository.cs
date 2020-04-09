using SWAN.Common.Response;
using SWAN.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAN.Repository.Interfaces
{
    public interface ISessionRepository : IRepository<Session, CustomResponse>
    {
        CustomResponse DeleteSessionBySessionId(int _sessionId);
        CustomResponse GetAllSessionInMemory();
    }
}
