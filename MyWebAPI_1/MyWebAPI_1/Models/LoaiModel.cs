using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI_1.Models
{
    public class LoaiModel
    {
        //Ma tu tang nen chi can ten loai thoi
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
    }
}
