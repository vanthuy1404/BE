using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class KhoaService : IKhoaService
    {
        private readonly SinhVienDbContext _context;
        public KhoaService(SinhVienDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Khoa>> GetAllKhoa()
        {
            return await _context.dsKhoa.ToListAsync();
        }

        
    }
}