using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LamViecVoiData.Models
{
    public enum Gender { Nam = 0, Nữ = 1, Khác = 2 }
    public enum EmployeeStatus { NgừngHoạtĐộng = 0, ĐangHoạtĐộng = 1 }

    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Họ và tên bắt buộc phải nhập")]
        [StringLength(100, ErrorMessage = "Họ và tên tối đa 100 ký tự")]
        [MinLength(4, ErrorMessage = "Họ và tên phải có ít nhất 4 ký tự")]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Giới tính bắt buộc phải chọn")]
        [Display(Name = "Giới tính")]
        public Gender Gender { get; set; }

        
        [Required(ErrorMessage = "Số điện thoại bắt buộc phải nhập")]
        [RegularExpression(@"^(0[3|5|7|8|9][0-9]{8}|02[0-9]{9})$",
    ErrorMessage = "Số điện thoại không hợp lệ. Vui lòng nhập đúng định dạng Việt Nam (VD: 0912345678 hoặc 02412345678)")]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email bắt buộc phải nhập")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@gmail\.com$",
    ErrorMessage = "Địa chỉ email phải có dạng ...@gmail.com")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lương bắt buộc phải nhập")]
        [Range(1000, 100000000, ErrorMessage = "Lương phải từ 1.000 đến 100.000.000")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Mức lương")]
        public decimal Salary { get; set; }

        [Display(Name = "Trạng thái")]
        public EmployeeStatus Status { get; set; }

        //thêm trường ngày bát đầu làm
        [Required(ErrorMessage = "Ngày bắt đầu làm việc là bắt buộc")]
        [DataType(DataType.Date, ErrorMessage = "Ngày không hợp lệ")]
        [Display(Name = "Ngày bắt đầu làm việc")]
        public DateTime StartDate { get; set; }
    }
}
