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
    public class SessionRepository : Repository<Session>, ISessionRepository
    {
        public SessionRepository(SWANDBEntities context) : base(context)
        {

        }

        public CustomResponse DeleteSessionBySessionId(int _sessionId)
        {
            Session session = _context.Sessions.Where(p => p.Id == _sessionId).FirstOrDefault();
            return base.DeleteEntity(session);
        }
    }
}
