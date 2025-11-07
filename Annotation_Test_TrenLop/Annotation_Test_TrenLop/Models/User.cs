using System.ComponentModel.DataAnnotations;

namespace Annotation_Test_TrenLop.Models
{
    public class User
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage ="User Name không được để trống")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "User Name tối thiểu là 5 kí tự đến 10 kí tự")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Password không được để trống")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password tối kiểu 6 kí tự")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Mat khau khong giong nhau")]             
        public string ReenterPassword { get; set; }

        [Range(18, 60, ErrorMessage ="tuổi từ 18 đến 60")]
        [Required(ErrorMessage ="Tuổi không được để trống")]
        public int Age { get; set; }

        [Required(ErrorMessage ="Email không được để trống")]
        [EmailAddress(ErrorMessage ="Email không đúng định dạng")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }
       
    }
}
