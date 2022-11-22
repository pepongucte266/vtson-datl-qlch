﻿using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.repository;
using datn_qlch_be.Core.Interfaces.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Services
{
    public class FoodCategoryService : BaseService<FoodCategory>, IFoodCategoryService
    {
        public FoodCategoryService(IFoodCategoryRepository repository) : base(repository) { }
    }
}
