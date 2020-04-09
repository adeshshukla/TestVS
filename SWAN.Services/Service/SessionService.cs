using AutoMapper;
using SWAN.Common.Models;
using SWAN.Common.Response;
using SWAN.Data;
using SWAN.Repository.Interfaces;
using SWAN.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAN.Services.Service
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _repo;
        private readonly IMapper _mapper;
        public SessionService(ISessionRepository repo)
        {
            this._repo = repo;

            #region Object Mapper
            //var config = new MapperConfiguration(cfg =>
            //{
            //    //cfg.AddProfile<AppProfile>();
            //    cfg.CreateMap<Session, MasterModel>().ReverseMap()
            //    .ForMember(x => x.Name, opt => opt.MapFrom(y => y.Name));
            //    //.ForMember(x => x.Session1, opt => opt.MapFrom(y => y.SessionName));
            //});

            //_mapper = config.CreateMapper(); 
            #endregion

            var config = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile<AppProfile>();
                cfg.CreateMap<Session, SessionModel>().ReverseMap();
            });

            _mapper = config.CreateMapper();

        }

        public CustomResponse GetAllSessions()
        {
            return _repo.GetAll();
        }

        public CustomResponse InsertSession(SessionModel _session)
        {
            Session session = _mapper.Map<Session>(_session);
            session.CreateTs = DateTime.Now;
            return _repo.Insert(session);
        }


        public CustomResponse DeleteSessionBySessionId(int _sessionId)
        {
            return _repo.DeleteSessionBySessionId(_sessionId);
        }



        #region Commented Code
        //public CustomResponse GetSessionBrief()
        //{
        //    var param = new SqlParameter("@SessionId", 1);
        //    return _repo.ExecuteDataSet("dbo.cusp_Session_GetSessionBrief @SessionId", param);
        //} 
        #endregion
    }
}
