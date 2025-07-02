using API.DTOs;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        private readonly ISinhVienService _sinhVienService;
        public SinhVienController(ISinhVienService sinhVienService)
        {
            _sinhVienService = sinhVienService;
        }
        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<SinhVienDTO>>>> GetAllSinhVien()
        {
            var dsSinhVien = await _sinhVienService.GetAllSinhVienAsync();
            if (dsSinhVien == null)
            {
                return NotFound(new BaseResponse<IEnumerable<SinhVienDTO>>(null, "Danh sách rỗng", false));
            }
            var response = new BaseResponse<IEnumerable<SinhVienDTO>>(dsSinhVien, "Lấy danh sách sinh viên thành công", true);
            return Ok(response);
        }
        [HttpGet("{maSV}")]
        public async Task<ActionResult<BaseResponse<SinhVienDTO>>> GetSinhVienById(int maSV)
        {
            SinhVienDTO sv = await _sinhVienService.GetSinhVienByIdAsync(maSV);
            if (sv == null)
            {
                return NotFound(new BaseResponse<IEnumerable<SinhVienDTO>>(null, "Danh sách rỗng", false));
            }
            var response = new BaseResponse<SinhVienDTO>(sv, $"Lấy sinh viên có mã Sinh Viên {maSV} thành công", true);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<SinhVien>> CreateSinhVien(SinhVien sinhVien)
        {
            var createdSV = await _sinhVienService.CreateSinhVienAsync(sinhVien);
            var response = new BaseResponse<SinhVien>(createdSV, "Đã tạo thành công", true);
            return CreatedAtAction(nameof(GetSinhVienById), new { maSV = createdSV.MaSV }, response);
        }
        [HttpPut("{maSV}")]
        public async Task<ActionResult<BaseResponse<SinhVien>>> UpdateSinhVien(int maSV, SinhVien sinhVien)
        {
            SinhVien sv = await _sinhVienService.UpdateSinhVienAsync(maSV, sinhVien);
            var response = new BaseResponse<SinhVien>(sv, "Đã cập nhật", true);
            return Ok(response);
        }
        [HttpDelete("{maSV}")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteSinhVien(int maSV)
        {
            var isDeleted = await _sinhVienService.DeleteSinhVienAsync(maSV);
            return Ok(new BaseResponse<bool>(true, "Đã cập nhật", true));
        }


    }
}