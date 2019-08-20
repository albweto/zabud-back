using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ZabudApi.Models;

namespace ZabudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {

        SalesDataAccesLayer data = new SalesDataAccesLayer();
        [HttpGet]
        public IEnumerable<Sale> Get()
        {
            //TODO: Implement Realistic Implementation
            return data.getAllSales();
        }
    }
}