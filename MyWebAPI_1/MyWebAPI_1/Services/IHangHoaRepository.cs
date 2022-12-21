using MyWebAPI_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI_1.Services
{
    public interface IHangHoaRepository
    {
        List<HangHoaModel> GetAll();
        List<HangHoaModel> GetAll(string search, double? from, double? to, string sortBy, int page = 1);
    }
}
