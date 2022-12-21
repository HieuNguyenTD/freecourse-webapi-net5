using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI_1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IHangHoaRepository _hangHoaRepository;
        public ProductsController(IHangHoaRepository hangHoaRepository)
        {
            _hangHoaRepository = hangHoaRepository;
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    try
        //    {
        //        var result = _hangHoaRepository.GetAll();
        //        return Ok(result);
        //    }
        //    catch
        //    {
        //        return BadRequest("We can't get the product.");
        //    }
        //}

        [HttpGet]
        public IActionResult GetAllProducts(string search, double? from, double? to, 
            string sortBy = "gia_asc", int page = 1)
        {
            try
            {
                var result = _hangHoaRepository.GetAll(search, from, to, sortBy, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest("We can't get the product.");
            }
        }
    }
}
