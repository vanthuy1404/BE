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
        Task<SinhVien> CreateSinhVienAsync(SinhVienCreateDTO sinhVien);
        Task<SinhVien> UpdateSinhVienAsync(SinhVienUpdateDTO sinhVien);
        Task<bool> DeleteSinhVienAsync(int maSV);
    }
}