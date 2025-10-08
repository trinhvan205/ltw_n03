using System.ComponentModel.DataAnnotations;

namespace TvTDay08EFCF.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Fax { get; set; }
        public string FaxNumber { get; set;}    
        public string HomePage { get; set; }
        public string Extension { get; set; }
        public bool  IsActive { get; set; }
    }
}
