using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI_1.Data
{
    public class DonHangChiTiet
    {

        public Guid MaHh { get; set; }
        public Guid MaDh { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }
        //relationship
        public DonHang DonHang { get; set; }
        public HangHoa HangHoa { get; set; }
    }
}
