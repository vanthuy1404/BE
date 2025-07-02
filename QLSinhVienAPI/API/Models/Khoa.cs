using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Khoa")]
    public class Khoa
    {
        [Key]
        public string MaKhoa { get; set; }
        [Required]
        [StringLength(100)]
        public string TenKhoa { get; set; }
        public ICollection<SinhVien> dsSinhVien { get; set; }
    }
}