using SWAN.Repository.Interfaces;
using SWAN.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SWAN.Common.Response;
using System.Data;

namespace SWAN.Repository.Repository
{
    public class Repository<T> : IRepository<T, CustomResponse> where T : class
    {
        protected SWANDBEntities _context = null;
        private DbSet<T> dbSet = null;


        public Repository(SWANDBEntities _context)
        {
            this._context = _context;
            dbSet = _context.Set<T>();
        }

        /// <summary>
        /// This function deletes the dataobject after finding it into the database
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        public CustomResponse Delete(T dataObject)
        {
            T existing = dbSet.Find(dataObject);
            dbSet.Remove(existing);
            return new CustomResponse()
            {
                Status = 200,
                Data = _context.SaveChanges(),
                Result = "Data deleted successfully"
            };
        }
        /// <summary>
        /// This function deletes the dataobject without finding it into the database
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        public CustomResponse DeleteEntity(T dataObject)
        {
            dbSet.Remove(dataObject);
            return new CustomResponse()
            {
                Status = 200,
                Data = _context.SaveChanges(),
                Result = "Data deleted successfully"
            };
        }

        public CustomResponse Delete(IEnumerable<T> dataObjects)
        {
            dbSet.RemoveRange(dataObjects);
            return new CustomResponse()
            {
                Status = 200,
                Data = _context.SaveChanges(),
                Result = "Data deleted successfully"
            };
        }

        public CustomResponse GetAll()
        {
            IEnumerable<T> list = dbSet.ToList();
            return new CustomResponse()
            {
                Status = 200,
                Data = list,
                Result = "Executed"
            };

        }

        public CustomResponse Insert(T dataObject)
        {
            dbSet.Add(dataObject);
            return new CustomResponse()
            {
                Status = 200,
                Data = _context.SaveChanges(),
                Result = "Data inserted successfully"

            };

        }

        public CustomResponse Insert(IEnumerable<T> dataObjects)
        {
            dbSet.AddRange(dataObjects);
            return new CustomResponse()
            {
                Status = 200,
                Data = _context.SaveChanges()
            };

        }

        public CustomResponse Update(T dataObject)
        {
            dbSet.Attach(dataObject);
            _context.Entry(dataObject).State = EntityState.Modified;
            return new CustomResponse()
            {
                Status = 200,
                Data = _context.SaveChanges()
            };

        }

        public CustomResponse ExecuteSql(string spName, params object[] sqlParams)
        {
            int result = _context.Database.ExecuteSqlCommand(spName, sqlParams);
            return new CustomResponse { Status = 200, Data = result };
        }

        public CustomResponse ExecuteDataSet(string spName, params object[] sqlParams)
        {
            var result = _context.Database.SqlQuery<Session>(spName, sqlParams);
            return new CustomResponse { Status = 200, Data = result };
        }

        
    }
}
