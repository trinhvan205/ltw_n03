using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvtDay10LabCf.Models
{
    [Table("TvtSan_Pham")]
    public class TvtSan_Pham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long tvtId { get; set; }
        public string tvtMaSanPham { get; set; }
        public string tvtTenSanPham { get; set; }
        public string tvtHinhAnh { get; set; }
        public int tvtSoLuong { get; set; }
        public decimal tvtDonGia { get; set; }
        public long tvtMaLoai { get; set; }
        public bool tvtTrangThai { get; set; }
        public TvtLoai_San_Pham TvtLoai_San_Pham { get; set; }
    }
}
