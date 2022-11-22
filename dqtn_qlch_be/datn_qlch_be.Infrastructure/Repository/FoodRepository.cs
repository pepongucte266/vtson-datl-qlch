using Dapper;
using Microsoft.Extensions.Configuration;
using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.repository;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace datn_qlch_be.Infrastructure.Repository
{
    public class FoodRepository : BaseRepository<Food>, IFoodRepository
    {
        #region Constructor
        public FoodRepository(IConfiguration configuration) : base(configuration) { }

        #endregion

        #region Methods

        #endregion
        /// <summary>
        /// Lấy thông tin món ăn theo id
        /// </summary>
        /// <param name="id">Id của món ăn</param>
        /// <returns>food:thông tin món ăn</returns>
        /// CreateBy: VTSON 22/07/2022
        public Food GetById(Guid id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@$FoodId", id);
            var food = SqlConnection.QueryFirstOrDefault<Food>("Proc_GetFoodById", param: dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
            return food;
        }
        public new IEnumerable<Food> GetAll()
        {
            var foods = SqlConnection.Query<Food>("Proc_GetFoodList", commandType: System.Data.CommandType.StoredProcedure);
            return foods;
        }

        /// <summary>
        /// Thên mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>1: thành công</returns>
        /// Created By: VTSON (19/07/2022) 
        public new int Insert(Food food)
        {
            var props = food.GetType().GetProperties().Select(x => x.Name);
            string query = "";
            int CreatedDateIndex = Array.IndexOf(props.ToArray(), "CreatedDate");
            int ModifiedIndex = Array.IndexOf(props.ToArray(), "ModifiedDate");
            for (int i = 7; i < props.Count(); i++)
            {
                object? value = food.GetType().GetProperty(props.ElementAt(i)).GetValue(food);
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
            parameters.Add($"@$TableName", "Food");
            parameters.Add($"@$String", query);
            parameters.Add($"@$NewId", DbType.Guid, direction: ParameterDirection.Output);
            var res = SqlConnection.Execute($"Proc_Insert", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            return res;
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <param name="food"></param>
        /// <returns>1: thành công</returns>
        /// Created By: VTSON (19/07/2022) 
        public new int Update(Food food)
        {
            var props = food.GetType().GetProperties().Select(x => x.Name);
            string query = "";
            ArrayList list = new ArrayList();
            for (int i = 7; i < props.Count(); i++)
            {
                string column = props.ElementAt(i);
                object? value = food.GetType().GetProperty(props.ElementAt(i)).GetValue(food);
                if (column == "ModifiedDate")
                {
                    list.Add($"{column} = NOW()");
                }
                else if (column == "CreatedDate")
                {
                    continue;
                }
                else if (value is null)
                {
                    list.Add($"{column} = NULL");
                }
                else
                {
                    list.Add($"{column} = '{value}'");
                }
            }
            query = string.Join(",", list.ToArray());
            query += $" WHERE {props.ElementAt(0)} = '{food.GetType().GetProperty(props.ElementAt(0)).GetValue(food)}'";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@$TableName", "Food");
            parameters.Add($"@$String", query);
            var res = SqlConnection.Execute($"Proc_Update", param: parameters, commandType: System.Data.CommandType.StoredProcedure);

            return res;
        }

        /// <summary>
        /// Lấy danh sách món ăn
        /// </summary>
        /// <param name="pageSize">Số bản ghi</param>
        /// <param name="pageNumber">Trang số</param>
        /// <returns>totalRecord: Tổng số bản ghi; totalPage: Tổng số trang; Data: danh sách nhân viên</returns>
        /// CreateBy: VTSON 22/07/2022
        public object GetFilter(int? pageNumber, int? pageSise, string? where, string? sort)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@$PageNumber", pageNumber);
            parameters.Add("@$PageSize", pageSise);
            parameters.Add("@$TotalRecord", DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@$TotalPage", DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@$Where", where);
            parameters.Add("@$Sort", sort);
            var Data = SqlConnection.Query<Food>("Proc_FoodFilter", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            int TotalPage = parameters.Get<int>("@$TotalPage");
            int TotalRecord = parameters.Get<int>("@$TotalRecord");
            Object data = new
            {
                TotalRecord,
                TotalPage,
                Data
            };
            return data;
        }

        /// <summary>
        /// Lấy thông tin món ăn theo mã món
        /// </summary>
        /// <param name="foodCode">mã món ănn</param>
        /// <returns>food:thông tin món ăn</returns>
        /// CreateBy: VTSON 23/07/2022
        public Food GetByFoodCode(string foodCode)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@$FoodCode", foodCode);
            var food = SqlConnection.QueryFirstOrDefault<Food>("Proc_GetFoodByFoodCode", param: dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
            return food;
        }

        /// <summary>
        /// Thêm mới vào db
        /// <param name="food">món ăn</param>
        /// <param name="foodFavoriteServices">các sơ thích phục vụ</param>
        /// </summary>
        /// CreateBy: VTSON 25/07/2022
        public int InsertFull(Food food, FoodFavoriteService[] foodFavoriteServices)
        {
            SqlConnection.Open();
            using (MySqlTransaction transaction = SqlConnection.BeginTransaction())
            {
                try
                {
                    string query = BuildQuery(food, 7, 0);

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add($"@$TableName", "Food");
                    parameters.Add($"@$String", query);
                    parameters.Add($"@$NewId", DbType.Guid, direction: ParameterDirection.Output);
                    SqlConnection.Execute($"Proc_Insert", param: parameters, transaction, commandType: System.Data.CommandType.StoredProcedure);
                    var newId = parameters.Get<dynamic>("@$NewId");
                    foreach (FoodFavoriteService foodFavoriteService in foodFavoriteServices)
                    {
                        foodFavoriteService.FoodId = newId;
                        query = BuildQuery(foodFavoriteService, 4, 0);
                        DynamicParameters FFSparameters = new DynamicParameters();
                        parameters.Add($"@$TableName", "FoodFavoriteService");
                        parameters.Add($"@$String", query);
                        parameters.Add($"@$NewId", DbType.Guid, direction: ParameterDirection.Output);
                        SqlConnection.Execute($"Proc_Insert", param: parameters, transaction, commandType: System.Data.CommandType.StoredProcedure);
                    }

                    transaction.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return -1;
                }
            }
        }

        /// <summary>
        /// Cập nhật vào db
        /// <param name="food">món ăn</param>
        /// <param name="foodFavoriteServices">các sơ thích phục vụ</param>
        /// </summary>
        /// CreateBy: VTSON 25/07/2022
        public int UpdateFull(Food food, FoodFavoriteService[] foodFavoriteServices)
        {
            SqlConnection.Open();
            using (MySqlTransaction transaction = SqlConnection.BeginTransaction())
            {
                try
                {
                    string query = BuildQuery(food, 7, 1);

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add($"@$TableName", "Food");
                    parameters.Add($"@$String", query);
                    SqlConnection.Execute($"Proc_Update", param: parameters, transaction, commandType: System.Data.CommandType.StoredProcedure);

                    DynamicParameters parametersForDelete = new DynamicParameters();
                    parametersForDelete.Add("$FoodId",food.FoodId);
                    SqlConnection.Execute($"Proc_DeleteFoodFavoriteServiceByFoodId", param: parametersForDelete, transaction, commandType: CommandType.StoredProcedure);

                    foreach (FoodFavoriteService foodFavoriteService in foodFavoriteServices)
                    {
                        foodFavoriteService.FoodId = food.FoodId;
                        query = BuildQuery(foodFavoriteService, 4, 0);
                        DynamicParameters FFSparameters = new DynamicParameters();
                        parameters.Add($"@$TableName", "FoodFavoriteService");
                        parameters.Add($"@$String", query);
                        parameters.Add($"@$NewId", DbType.Guid, direction: ParameterDirection.Output);
                        SqlConnection.Execute($"Proc_Insert", param: parameters, transaction, commandType: System.Data.CommandType.StoredProcedure);
                    }

                    transaction.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return -1;
                } finally
                {
                    SqlConnection.Close();
                }
            }
        }
    }

}

