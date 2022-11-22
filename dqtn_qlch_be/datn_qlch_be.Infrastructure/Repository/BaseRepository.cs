using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using datn_qlch_be.Core.Interfaces.repository;
using System.Data;

namespace datn_qlch_be.Infrastructure.Repository
{
    public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : class
    {
        #region Fields
        protected string ConnectionString;
        protected MySqlConnection SqlConnection;
        private string _className;
        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("VTSON");
            SqlConnection = new MySqlConnection(ConnectionString);
            _className = typeof(Entity).Name;
        }
        #endregion

        #region Methods

        // <summary>
        /// Xóa
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi xóa thành côngg</returns>
        /// Created By: VTSON (19/07/2022) 
        public int Delete(string ids)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"$Ids", ids);
            parameters.Add($"$TableName", _className);
            var res = SqlConnection.Execute($"Proc_Delete", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            return res;
        }

        /// <summary>
        /// Lấy tất cả
        /// </summary>
        /// <returns>Danh sách thực thể</returns>
        /// Created By: VTSON (19/07/2022) 
        public IEnumerable<Entity> GetAll()
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@$TableName", _className);
            var entities = SqlConnection.Query<Entity>("Proc_Get", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            return entities;
        }

        /// <summary>
        /// Thên mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>1: thành công</returns>
        /// Created By: VTSON (19/07/2022) 
        public int Insert(Entity entity)
        {
            var props = entity.GetType().GetProperties().Select(x => x.Name);
            var tableName = entity.GetType().Name;
            string query = "";
            int CreatedDateIndex = Array.IndexOf(props.ToArray(), "CreatedDate");
            int ModifiedIndex = Array.IndexOf(props.ToArray(), "ModifiedDate");
            for (int i = 1; i < props.Count(); i++)
            {
                object? value = entity.GetType().GetProperty(props.ElementAt(i)).GetValue(entity);
                if (i == CreatedDateIndex || i == ModifiedIndex)
                {
                    query += $",NOW()";
                }
                else if (value is null)
                {
                    query += $",NULL";
                }
                else
                {
                    query += $",'{value}'";
                }
            }
            query += ")";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@$TableName", tableName);
            parameters.Add($"@$String", query);
            parameters.Add($"@$NewId", DbType.Guid, direction: ParameterDirection.Output);
            var res = SqlConnection.Execute($"Proc_Insert", param: parameters, commandType: System.Data.CommandType.StoredProcedure);

            return res;
        }

        /// <summary>
        /// Kiểm tra entity đã tồn tại
        /// </summary>
        /// <param name="curentId"></param>
        /// <returns>true: đã tồn tại; false: không tồn tại</returns>
        /// Created By: VTSON (19/07/2022) 
        public bool IsExistByValue(string column, Guid? curentId, string value)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@$TableName", _className);
            parameters.Add("@$Column", column);
            parameters.Add("@$CurrentId", curentId);
            parameters.Add("@$Value", value);
            var isExits = SqlConnection.QueryFirstOrDefault("Proc_CheckExits", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            return isExits != null;
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>1: thành công</returns>
        /// Created By: VTSON (19/07/2022) 
        public int Update(Entity entity)
        {
            var props = entity.GetType().GetProperties().Select(x => x.Name);
            string query = "";
            ArrayList list = new ArrayList();
            int ModifiedIndex = Array.IndexOf(props.ToArray(), "ModifiedDate");
            for (int i = 1; i < props.Count(); i++)
            {
                string column = props.ElementAt(i);
                object? value = entity.GetType().GetProperty(props.ElementAt(i)).GetValue(entity);
                if (i == ModifiedIndex)
                {
                    list.Add($"{column} = NOW()");
                }
                else if (value is null)
                {
                    list.Add($"{column} = NULL ");
                }
                else
                {
                    list.Add($"{column} = '{value}' ");
                }
            }
            query = string.Join(",", list.ToArray());
            query += $"WHERE {props.ElementAt(0)} = '{entity.GetType().GetProperty(props.ElementAt(0)).GetValue(entity)}'";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@$TableName", _className);
            parameters.Add($"@$String", query);
            var res = SqlConnection.Execute($"Proc_Update", param: parameters, commandType: System.Data.CommandType.StoredProcedure);

            return res;
        }


        protected virtual string BuildQuery(object entity, int index, int type)
        {
            string query = "";
            var props = entity.GetType().GetProperties().Select(x => x.Name);
            if (type == 0)
            {
                var tableName = entity.GetType().Name;

                int CreatedDateIndex = Array.IndexOf(props.ToArray(), "CreatedDate");
                int ModifiedIndex = Array.IndexOf(props.ToArray(), "ModifiedDate");
                for (int i = index; i < props.Count(); i++)
                {
                    object? value = entity.GetType().GetProperty(props.ElementAt(i)).GetValue(entity);
                    if (i == CreatedDateIndex || i == ModifiedIndex)
                    {
                        query += $",NOW()";
                    }
                    else if (value is null)
                    {
                        query += $",NULL";
                    }
                    else
                    {
                        query += $",'{value}'";
                    }
                }
                query += ")";
            }
            else
            {
                ArrayList list = new ArrayList();
                int ModifiedIndex = Array.IndexOf(props.ToArray(), "ModifiedDate");
                for (int i = index; i < props.Count(); i++)
                {
                    string column = props.ElementAt(i);
                    object? value = entity.GetType().GetProperty(props.ElementAt(i)).GetValue(entity);
                    if(column == "CreatedDate")
                    {
                        continue;
                    }
                    if (i == ModifiedIndex)
                    {
                        list.Add($"{column} = NOW()");
                    }
                    else if (value is null)
                    {
                        list.Add($"{column} = NULL ");
                    }
                    else
                    {
                        list.Add($"{column} = '{value}' ");
                    }
                }
                query = string.Join(",", list.ToArray());
                query += $"WHERE {props.ElementAt(0)} = '{entity.GetType().GetProperty(props.ElementAt(0)).GetValue(entity)}'";
            }

            return query;
        }
        #endregion

    }
}
