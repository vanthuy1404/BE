using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Models;
namespace API.Services
{
    public interface ISinhVienService
    {
        Task<IEnumerable<SinhVienDTO>> GetAllSinhVienAsync();
        Task<SinhVienDTO> GetSinhVienByIdAsync(int maSV);
        Task<SinhVien> CreateSinhVienAsync(SinhVien sinhVien);
        Task<SinhVien> UpdateSinhVienAsync(int maSV, SinhVien sinhVien);
        Task<bool> DeleteSinhVienAsync(int maSV);
    }
}