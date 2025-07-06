using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class SinhVienService : ISinhVienService
    {
        private readonly SinhVienDbContext _context;
        public SinhVienService(SinhVienDbContext context)
        {
            _context = context;
        }
        public async Task<SinhVien> CreateSinhVienAsync(SinhVien sinhVien)
        {
            if (sinhVien == null)
            {
                throw new ArgumentNullException(nameof(sinhVien), "Sinh Vien không đc null");
            }
            await _context.dsSinhVien.AddAsync(sinhVien);
            await _context.SaveChangesAsync();
            return sinhVien;
        }

        public async Task<bool> DeleteSinhVienAsync(int maSV)
        {
            if (maSV <= 0)
            {
                throw new ArgumentException("Invalid MaSV", nameof(maSV));
            }
            var sinhVien = await _context.dsSinhVien.FindAsync(maSV);
            if (sinhVien == null)
            {
                throw new KeyNotFoundException($"Sinh Vien with MaSV {maSV} not found");
            }
            _context.dsSinhVien.Remove(sinhVien);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<SinhVienDTO>> GetAllSinhVienAsync()
        {

            List<SinhVienDTO> dsSinhVien = await _context.dsSinhVien.Include(sv => sv.Khoa).Select(sv => new SinhVienDTO
            {
                MaSV = sv.MaSV,
                TenSV = sv.TenSV,
                NgaySinh = sv.NgaySinh,
                GioiTinh = sv.GioiTinh,
                MaKhoa = sv.MaKhoa,
                TenKhoa = sv.Khoa.TenKhoa
            }).ToListAsync();
            return dsSinhVien;
        }

        public async Task<SinhVienDTO?> GetSinhVienByIdAsync(int maSV)
        {
            if (maSV <= 0)
            {
                throw new ArgumentException("Invalid MaSV", nameof(maSV));
            }
            var sinhVien = await _context.dsSinhVien.Include(sv => sv.Khoa).FirstOrDefaultAsync(sv => sv.MaSV == maSV);
            if (sinhVien == null)
            {
                return null;
            }
            return new SinhVienDTO
            {
                MaSV = sinhVien.MaSV,
                TenSV = sinhVien.TenSV,
                NgaySinh = sinhVien.NgaySinh,
                GioiTinh = sinhVien.GioiTinh,
                MaKhoa = sinhVien.MaKhoa,
                TenKhoa = sinhVien.Khoa?.TenKhoa
            };
        }

        public async Task<SinhVien> UpdateSinhVienAsync(SinhVien sinhVien)
        {
            if (sinhVien.MaSV <= 0)
            {
                throw new ArgumentException("Invalid MaSV", nameof(sinhVien.MaSV));
            }
            if (sinhVien == null)
            {
                throw new ArgumentNullException(nameof(sinhVien), "Sinh Vien không đc null");
            }
            var existingSinhVien = await _context.dsSinhVien.FindAsync(sinhVien.MaSV);
            if (existingSinhVien == null)
            {
                throw new KeyNotFoundException($"Sinh Vien with MaSV {sinhVien.MaSV} not found");
            }
            existingSinhVien.TenSV = sinhVien.TenSV;
            existingSinhVien.NgaySinh = sinhVien.NgaySinh;
            existingSinhVien.GioiTinh = sinhVien.GioiTinh;
            existingSinhVien.MaKhoa = sinhVien.MaKhoa;

            await _context.SaveChangesAsync();
            return sinhVien;
        }
    }
}