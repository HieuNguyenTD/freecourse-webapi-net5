using Microsoft.EntityFrameworkCore;
using MyWebAPI_1.Data;
using MyWebAPI_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI_1.Services
{
    public class HangHoaRepository : IHangHoaRepository
    {
        private readonly MyDbContext _context;
        private static int PAGE_SIZE { get; set; } = 5;
        public HangHoaRepository(MyDbContext context)
        {
            _context = context;
        }
        public List<HangHoaModel> GetAll(string search, double? from, double? to, string sortBy, int page = 1)
        {
            //Muốn ra data của khóa ngoại thì phải có Include
            var allProducts = _context.HangHoas.Include(hh=>hh.Loai).AsQueryable();

            #region Filtering
            if (!string.IsNullOrEmpty(search))
            {
                allProducts = allProducts.Where(hh => hh.TenHh.Contains(search));
            }

            if (from.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.DonGia >= from);
            }

            if (to.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.DonGia <= to);
            }
            #endregion

            #region Sorting
            //Default sort by Name (TenHh)
            allProducts = allProducts.OrderBy(hh => hh.TenHh);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "tenhh_desc":
                        allProducts = allProducts.OrderByDescending(hh => hh.TenHh);
                        break;
                    case "gia_asc":
                        allProducts = allProducts.OrderBy(hh => hh.DonGia);
                        break;
                    case "gia_desc":
                        allProducts = allProducts.OrderByDescending(hh => hh.DonGia);
                        break;
                    default:
                        break;
                }
            }
            #endregion

            //#region Paging
            //allProducts = allProducts.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            //#endregion

            //var result = allProducts.Select(hh => new HangHoaModel
            //{
            //    MaHangHoa = hh.MaHh,
            //    TenHangHoa = hh.TenHh,
            //    DonGia = hh.DonGia,
            //    TenLoai = hh.Loai.TenLoai
            //});

            //return result.ToList();

            var result = PaginatedList<MyWebAPI_1.Data.HangHoa>.Create(allProducts, page, PAGE_SIZE);
            return result.Select(hh => new HangHoaModel
            {
                MaHangHoa = hh.MaHh,
                TenHangHoa = hh.TenHh,
                DonGia = hh.DonGia,
                TenLoai = hh.Loai?.TenLoai
            }).ToList();
        }

        public List<HangHoaModel> GetAll_bk(string search, double? from, double? to, string sortBy, int page = 1)
        {
            var allProducts = _context.HangHoas.AsQueryable();

            #region Filtering
            if (!string.IsNullOrEmpty(search))
            {
                allProducts = allProducts.Where(hh => hh.TenHh.Contains(search));
            }

            if (from.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.DonGia >= from);
            }

            if (to.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.DonGia <= to);
            }
            #endregion

            #region Sorting
            //Default sort by Name (TenHh)
            allProducts = allProducts.OrderBy(hh => hh.TenHh);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "tenhh_desc":
                        allProducts = allProducts.OrderByDescending(hh => hh.TenHh);
                        break;
                    case "gia_asc":
                        allProducts = allProducts.OrderBy(hh => hh.DonGia);
                        break;
                    case "gia_desc":
                        allProducts = allProducts.OrderByDescending(hh => hh.DonGia);
                        break;
                    default:
                        break;
                }
            }
            #endregion

            #region Paging
            allProducts = allProducts.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            #endregion

            var result = allProducts.Select(hh => new HangHoaModel
            {
                MaHangHoa = hh.MaHh,
                TenHangHoa = hh.TenHh,
                DonGia = hh.DonGia,
                TenLoai = hh.Loai.TenLoai
            });

            return result.ToList();


        }

        //public List<HangHoaModel> GetAll(string search)
        //{
        //    var allProducts = _context.HangHoas.Where(hh => hh.TenHh.Contains(search));

        //    var result = allProducts.Select(hh => new HangHoaModel
        //    {
        //        MaHangHoa = hh.MaHh,
        //        TenHangHoa = hh.TenHh,
        //        DonGia = hh.DonGia,
        //        TenLoai = hh.Loai.TenLoai
        //    });

        //    return result.ToList();
        //}

        public List<HangHoaModel> GetAll()
        {
            var allProducts = _context.HangHoas.ToList();

            var result = allProducts.Select(hh => new HangHoaModel
            {
                MaHangHoa = hh.MaHh,
                TenHangHoa = hh.TenHh,
                DonGia = hh.DonGia,
                TenLoai = hh.Loai.TenLoai
            });

            return result.ToList();
        }
    }
}
