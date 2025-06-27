using System;
namespace SinhVienNamSpace
{
    public class SinhVien
    {
        public int MaSV { get;  set; }
        public string TenSV { get;  set; }
        public string GioiTinh { get;  set; }
        public DateTime NgaySinh { get;  set; }
        public string MaKhoa { get;  set; }
        public SinhVien(int maSV, string tenSV, string gioiTinh, DateTime ngaySinh, string maKhoa)
        {
            MaSV = maSV;
            TenSV = tenSV;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            MaKhoa = maKhoa;
        }
        public override string ToString()
        {
            return $"Ma SV: {MaSV}, Ten SV: {TenSV}, Gioi tinh: {GioiTinh}, Ngay sinh: {NgaySinh.ToShortDateString()}, Ma khoa: {MaKhoa}";
        }
    }

}