namespace TestMvc.Models
{
    public class SinhVien
    {
        public int MaSV { get; set; }
        public string TenSV { get; set; }
        public int Tuoi { get; set; }
        public SinhVien(){}
        public SinhVien(int msv, string ten, int tuoi)
        {
            this.MaSV = msv;
            this.TenSV = ten;
            this.Tuoi = tuoi;
        }
    }
}