using MyWebAPI_1.Data;
using MyWebAPI_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI_1.Services
{
    public class LoaiRepository : ILoaiRepository
    {
        private readonly MyDbContext _context;

        public LoaiRepository(MyDbContext context)
        {
            _context = context;
        }

        public LoaiVM Add(LoaiModel loai)
        {
            var _loai = new Loai
            {
                TenLoai = loai.TenLoai
            };

            _context.Add(_loai);
            _context.SaveChanges();
            return new LoaiVM
            {
                MaLoai = _loai.MaLoai,
                TenLoai = _loai.TenLoai
            };
        }

        public void Delete(int id)
        {
            var loai = _context.Loais.SingleOrDefault(o=>o.MaLoai == id);
            if(loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
            }
        }

        public List<LoaiVM> GetAll()
        {
            var loais = _context.Loais.Select(o=> new LoaiVM
            {
                MaLoai = o.MaLoai,
                TenLoai = o.TenLoai
            });

            return loais.ToList();
        }

        public LoaiVM GetByID(int id)
        {
            var loai = _context.Loais.SingleOrDefault(o=>o.MaLoai == id);

            if (loai != null)
            {
                return new LoaiVM { MaLoai = loai.MaLoai, TenLoai = loai.TenLoai };
            }
            else return null;
        }

        public void Update(LoaiVM loai)
        {
            var _loai = _context.Loais.SingleOrDefault(o => o.MaLoai == loai.MaLoai);
            if (_loai != null)
            {
                _loai.TenLoai = loai.TenLoai;
                _context.SaveChanges();
            }
        }
    }
}
