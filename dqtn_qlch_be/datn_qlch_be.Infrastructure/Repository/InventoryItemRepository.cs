using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Infrastructure.Repository
{
    public class InventoryItemRepository : BaseRepository<InventoryItem>, IInventoryItemRepository
    {
        #region Constructor
        public InventoryItemRepository(IConfiguration configuration) : base(configuration) { }

        #endregion
    }
}
