using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.repository;
using datn_qlch_be.Core.Interfaces.services;

namespace datn_qlch_be.Web.Controllers
{

    public class FoodGroupController : QLCHBaseController<FoodGroup>
    {
        public FoodGroupController(IFoodGroupRepository repository, IFoodGroupService service) : base(repository,service)
        {
        }
    }
}
