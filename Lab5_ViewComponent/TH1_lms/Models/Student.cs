using System.ComponentModel.DataAnnotations;

namespace TH1_lms.Models
{
    public class Student
    {
        public int Id { get; set; }//Mã sinh viên
        [Required(ErrorMessage ="Tên không được để trống")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Tên phải có ít nhất 4 kí tự")]
        public string? Name { get; set; } //Họ tên
        [Required(ErrorMessage = "Email không được bỏ trống")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Email không hợp lệ")]
        public string? Email { get; set; } //Email
        [StringLength(100, MinimumLength = 8, ErrorMessage ="Password phải có ít nhất 8 kí tự vả tối đa 100 kí tự")]
        [Required(ErrorMessage = "Password không được để trống")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Password phải bao gồm chữ thường, in hoa, số và kí tự đặc biệt")]
        public string? Password { get; set; }//Mật khẩu
        [Required]
        public Branch? Branch { get; set; }//Ngành học
        [Required]
        public Gender? Gender { get; set; }//Giới tính
        public bool IsRegular { get; set; }//Hệ: true-chính qui, false-phi cq
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage ="địa chỉ không được bỏ trống")]
        public string? Address { get; set; }//Địa chi
        [Range(typeof(DateTime), "01/01/1963", "31/12/2005", ErrorMessage = "Ngay sinh phai tu 01/01/1963 den 31/12/2005")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngay sinh la bat buoc")]
        public DateTime DateOfBirth { get; set; }//Ngày sinh
    }

}
