﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI_1.Data;
using MyWebAPI_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDbContext _context;
        public LoaiController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {

            try
            {
                var loai = _context.Loais.SingleOrDefault(o => o.MaLoai == id);

                if (loai != null)
                {
                    return Ok(loai);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateNew(LoaiModel model)
        {
            try
            {
                var loai = new Loai
                {
                    TenLoai = model.TenLoai
                };

                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLoaiById(int id, LoaiModel loaiModel)
        {
            try
            {
                var loai = _context.Loais.SingleOrDefault(o => o.MaLoai == id);
                if (loai != null)
                {
                    loai.TenLoai = loaiModel.TenLoai;
                    _context.SaveChanges();
                    return NoContent();
                }
                else return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
