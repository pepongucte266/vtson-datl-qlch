using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.repository;
using datn_qlch_be.Core.Interfaces.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Services
{
    public class InventoryItemUnitService : BaseService<InventoryItemUnit>, IInventoryItemUnitService
    {
        #region Fields
        readonly IInventoryItemUnitRepository _repository;

        #endregion
        public InventoryItemUnitService(IInventoryItemUnitRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
