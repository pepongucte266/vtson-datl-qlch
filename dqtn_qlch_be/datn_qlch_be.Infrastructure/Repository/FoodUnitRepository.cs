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
    public class FoodUnitRepository: BaseRepository<FoodUnit>, IFoodUnitRepository
    {
        public FoodUnitRepository(IConfiguration configuration) : base(configuration) { }
    }
}
