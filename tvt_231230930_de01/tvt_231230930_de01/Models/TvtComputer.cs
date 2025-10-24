using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tvt_231230930_de01.Models
{
    [Table ("TvtComputer")]
    public class TvtComputer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tvtComId { get; set; }
        [Required(ErrorMessage ="Ten may tinh khong duoc de trong")]
        [Display(Name ="Ten may tinh")]
        public string tvtComName { get; set; }
        [Range(100,5000, ErrorMessage ="Gia nam trong khoang 100 den 5000")]
        [Display(Name ="Gia may tinh")]
        public decimal tvtComprice { get; set; }
        [Required(ErrorMessage ="Vui long chon anh(.jpg| .png| .gif| .tiff) ")]
        [RegularExpression(@"(.*\.)(jpg|png|gif|tiff)$")]
        [Display(Name ="Anh minh hoa")]
        public string tvtComImage { get; set; }
        [Display(Name ="Trang thai")]
        public bool tvtComStatus { get; set; }
    }
}
