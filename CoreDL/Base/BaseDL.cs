using Dapper;
using Dapper.Contrib.Extensions;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.VMHUNG.Infrastructure.DataAccess
{
    public class BaseDL<T> : IBaseDL<T>
    {
        private String _connectionString;
        private String _className;
        protected DbConnection dbConnection;
        public BaseDL()
        {
            _connectionString = "UserID = root; " +
                "Host=localhost; " +
                "DataBase= test; " +
                "port=3306;" +
                "password=12345678;";
            var sqlconnection = "server=localhost,3306; database=test;user id=root;password=12345678;TrustServerCertificate=true";
            this._className = typeof(T).Name;
            this.dbConnection = new MySqlConnection(_connectionString);
        }
        /// <summary>
        /// Lấy khách hàng theo ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// Created By: VM Hùng (12/04/2021)
        public T GetById(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add($"@{_className}Id", id, DbType.String);
            var storeName = $"Proc_Get{_className}ById";
            var entity = dbConnection.Query<T>(storeName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }

        /// <summary>
        /// lấy tất cả khách hàng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// Created By: VM Hùng (12/04/2021)
        public IEnumerable<entity> GetAll<entity>()
        {
            var table = typeof(entity).Name;
            var query = string.Format("Select * from {0}", table);
            var entities = dbConnection.Query<entity>(query);
            return entities;
        }
        /// <summary>
        /// lấy tất cả khách hàng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// Created By: VM Hùng (12/04/2021)
        public IEnumerable<T> Insert()
        {
            var storeName = $"Proc_Get{_className}s";
            var entity = dbConnection.Query<T>(storeName, commandType: System.Data.CommandType.StoredProcedure);
            return entity;
        }
        /// <summary>
        /// Thêm nhiều
        /// </summary>
        /// <returns></returns>
        public bool Inserts<entity>(List<entity> entities)
        {
           var success = false;
           try
            {
                success = dbConnection.Insert<List<entity>>(entities) > 0;
            } 
            catch (Exception ex)
            {

            }
            return success;
        }
        /// <summary>
        /// Updates multiple
        /// </summary>
        /// <returns></returns>
        public bool Updates<entity>(List<entity> entities)
        {
            var success = false;
            try
            {
                success = dbConnection.Update<List<entity>>(entities);
            }
            catch (Exception ex)
            {

            }
            return success;
        }
        /// <summary>
        /// delete multiple
        /// </summary>
        /// <returns></returns>
        public bool Deletes<entity>(List<entity> entities)
        {
            var success = false;
            try
            {
                success = dbConnection.Delete<List<entity>>(entities);
            }
            catch (Exception ex)
            {

            }
            return success;
        }
    }
}
