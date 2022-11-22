using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.repository;
using datn_qlch_be.Core.Interfaces.services;

namespace datn_qlch_be.Web.Controllers
{

    public class FavoriteServiceController : QLCHBaseController<FavoriteService>
    {
        public FavoriteServiceController(IFavoriteServiceRepository repository, IFavoriteServiceService service) : base(repository, service)
        {
        }
    }
}
