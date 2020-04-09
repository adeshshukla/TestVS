using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAN.Repository.Interfaces
{    
    public interface IRepository<T, D> where T : class
    {
        /// <summary>
        /// interface ISave<T, D> where T : new()
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        D Insert(T dataObject);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataObjects"></param>
        /// <returns></returns>
        D Insert(IEnumerable<T> dataObjects);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        D Delete(T dataObject);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        D DeleteEntity(T dataObject);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataObjects"></param>
        /// <returns></returns>
        D Delete(IEnumerable<T> dataObjects);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        D Update(T dataObject);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        D GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        D ExecuteSql(string spName, params object[] sqlParams);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        D ExecuteDataSet(string spName, params object[] sqlParams);
    }
}
