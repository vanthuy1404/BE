using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KhoaController : ControllerBase
    {
        public readonly IKhoaService _service;
        public KhoaController(IKhoaService service) {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Khoa>>>> GetAllKhoa()
        {
            List<Khoa> khoa = (await _service.GetAllKhoa()).ToList();
            return Ok(new BaseResponse<IEnumerable<Khoa>>(khoa, "Lấy khoa thành công", true));
            
        }

    }
}