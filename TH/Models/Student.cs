using System.ComponentModel.DataAnnotations;

namespace Bài_TH_01.Models
{
    public class Student
    {
        public int Id { get; set; } //Mã sinh viên

        [Required(ErrorMessage = "Họ và tên là bắt buộc")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Tên phải có từ {2} đến {1} ký tự")]
        [Display(Name = "Họ và tên")]
        public string? Name { get; set; } //Họ tên

        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        [RegularExpression(@"^[\w\.-]+@gmail\.com$", ErrorMessage = "Email phải có đuôi gmail.com")]
        [Display(Name = "Email")] public string? Email { get; set; } //Email

        [StringLength(100, MinimumLength = 8)]
        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.{8,}$)(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).*$", ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, chữ số và ký tự đặc biệt")]
        [Display(Name = "Mật khẩu")]
        public string? Password { get; set; } //Mật khẩu

        [Required]
        [Display(Name = "Ngành")]
        public Branch? Branch { get; set; } //Ngành học

        [Required]
        [Display(Name = "Giới tính")]
        public Gender? Gender { get; set; } //Giới tính
        [Display(Name = "Hệ đào tạo")]
        public bool IsRegular { get; set; } //Hệ: true-chính quy, false-phi chính quy

        [DataType(DataType.MultilineText)]
        [Required]
        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; } //Địa chỉ

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; } //Ngày sinh
        [Required(ErrorMessage = "Điểm là bắt buộc")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng {1} đến {2}")]
        [Display(Name = "Điểm")]
        public double Score { get; set; }
        [Display(Name = "Ảnh")]
        public string? PhotoPath { get; set; }
    }
}
