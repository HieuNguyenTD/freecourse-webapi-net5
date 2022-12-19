using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoaModel> hangHoas = new List<HangHoaModel>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(string id)
        {
            try
            {
                //LINQ [Object] Query
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoaModel
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };
            hangHoas.Add(hanghoa);
            return Ok(new
            {
                Success = true,
                Data = hanghoa
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoaModel hanghoaEdit)
        {
            try
            {
                //LINQ [Object] Query
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
          
                if (id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                //Update
                hangHoa.DonGia = hanghoaEdit.DonGia;
                hangHoa.TenHangHoa = hanghoaEdit.TenHangHoa;
                return Ok(hangHoa);
                //Test X
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                //LINQ [Object] Query
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }

                if (id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                //Delete
                hangHoas.Remove(hangHoa);
                return Ok(hangHoas);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
