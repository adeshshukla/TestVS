using SWAN.Data;
using SWAN.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAN.Repository.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private bool disposed = false;
        private SWANDBEntities _context = null;

        private Repository<Session> sessionRepository;
        public Repository<Session> SessionRepository
        {
            get
            {
                if (this.sessionRepository == null)
                    //this.sessionRepository = new Repository<Session>(_context);
                    this.sessionRepository = new SessionRepository(_context);
                return sessionRepository;
            }
        }

        private Repository<University> _universityRepository;
        public Repository<University> UniversityRepository
        {
            get
            {
                if (this._universityRepository == null)
                    this._universityRepository = new Repository<University>(_context);
                return _universityRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
