using System.Collections.Generic;
using System.Linq;
using TestMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace TestMvc.Controllers
{
    public class SinhVienController : Controller
    {
        static List<SinhVien> dsSinhVien = new List<SinhVien>
        {
            new SinhVien(1, "Thuy", 22),
            new SinhVien(2, "Thanh", 24)
        };

        public IActionResult Index()
        {
            return View(dsSinhVien);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SinhVien sv)
        {
            sv.MaSV = dsSinhVien.Any() ? dsSinhVien.Max(x => x.MaSV) + 1 : 1;
            dsSinhVien.Add(sv);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int maSV)
        {
            SinhVien sv = dsSinhVien.FirstOrDefault(sv => sv.MaSV == maSV);
            return View(sv);
        }
        
    }
}