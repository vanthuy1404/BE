using API.Models;

namespace API.Services
{
    public interface IKhoaService
    {
        Task<IEnumerable<Khoa>> GetAllKhoa();
    }
}