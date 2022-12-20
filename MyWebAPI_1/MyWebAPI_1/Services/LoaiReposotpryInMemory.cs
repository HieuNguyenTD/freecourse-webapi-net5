using MyWebAPI_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI_1.Services
{
    public class LoaiReposotpryInMemory : ILoaiRepository
    {
        static List<LoaiVM> loais = new List<LoaiVM>
        {
            new LoaiVM{ MaLoai = 1, TenLoai = "Tivi"},
            new LoaiVM{ MaLoai = 2, TenLoai = "Tủ lạnh"},
            new LoaiVM{ MaLoai = 3, TenLoai = "Điều hòa"},
            new LoaiVM{ MaLoai = 4, TenLoai = "Máy giặt"},
        };

        public LoaiVM Add(LoaiModel loai)
        {
            var _loai = new LoaiVM
            {
                MaLoai = loais.Max(o => o.MaLoai) + 1,
                TenLoai = loai.TenLoai
            };

            loais.Add(_loai);
            return _loai;
        }

        public void Delete(int id)
        {
            var _loai = loais.SingleOrDefault(o => o.MaLoai == id);
            loais.Remove(_loai);
        }

        public List<LoaiVM> GetAll()
        {
            return loais;
        }

        public LoaiVM GetByID(int id)
        {
            return loais.SingleOrDefault(o=>o.MaLoai == id);
        }

        public void Update(LoaiVM loai)
        {
            var _loai = loais.SingleOrDefault(o => o.MaLoai == loai.MaLoai);
            if(_loai != null)
            {
                _loai.TenLoai = loai.TenLoai;
            }
        }
    }
}
