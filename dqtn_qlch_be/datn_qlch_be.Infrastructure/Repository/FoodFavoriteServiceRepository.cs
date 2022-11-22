using Dapper;
using Microsoft.Extensions.Configuration;
using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Infrastructure.Repository
{
    public class FoodFavoriteServiceRepository : BaseRepository<FoodFavoriteService>, IFoodFavoriteServiceRepository
    {
        public FoodFavoriteServiceRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<FoodFavoriteService> GetById(Guid id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@$FoodId", id);
            var result = SqlConnection.Query<FoodFavoriteService>("Proc_GetFavoriteByFoodId", param: dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public new int Insert(FoodFavoriteService foodFavoriteService)
        {
            var props = foodFavoriteService.GetType().GetProperties().Select(x => x.Name);
            string query = "";
            int CreatedDateIndex = Array.IndexOf(props.ToArray(), "CreatedDate");
            int ModifiedIndex = Array.IndexOf(props.ToArray(), "ModifiedDate");
            for (int i = 4; i < props.Count(); i++)
            {
                object? value = foodFavoriteService.GetType().GetProperty(props.ElementAt(i)).GetValue(foodFavoriteService);
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
            parameters.Add($"@$TableName", "FoodFavoriteService");
            parameters.Add($"@$String", query);
            var res = SqlConnection.Execute($"Proc_Insert", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            return res;
        }
    }
}
