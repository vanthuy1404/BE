using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    [Table("SinhVien")]
    public class SinhVien
    {
        [Key]
        public int MaSV { get; set; }
        public string TenSV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        [ForeignKey("Khoa")]
        public string MaKhoa { get; set; }
        [JsonIgnore]
        public Khoa Khoa { get; set; }
        public SinhVien() { }
        public SinhVien(int maSV, string tenSV, DateTime ngaySinh, string gioiTinh, string maKhoa)
        {
            MaSV = maSV;
            TenSV = tenSV;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            MaKhoa = maKhoa;
        }
    }
}