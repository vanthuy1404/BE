// Quan li sinh vien
// Chuc nang: Them, sua, xoa, tim kiem sinh vien
//Tao UI console
using System;
using System.Collections.Generic;
using System.Linq;
using SinhVienNamSpace;

public class Program
{
    public static void Main(string[] args)
    {
        List<SinhVien> dsSinhVien = new List<SinhVien>
        {
            new SinhVien(1, "Nguyen Van Hanh", "Nam", new DateTime(2000, 1, 1), "CNTT"),
            new SinhVien(2, "Tran Thi Tam", "Nu", new DateTime(2001, 2, 2), "KTMT"),
            new SinhVien(3, "Le Van Giang", "Nam", new DateTime(2002, 3, 3), "QTKD"),
            new SinhVien(4, "Pham Thi Hong", "Nu", new DateTime(2003, 4, 4), "KTMT"),
            new SinhVien(5, "Nguyen Van Chien", "Nam", new DateTime(2004, 5, 5), "CNTT")
        };

        int choice;
        do
        {
            Console.WriteLine("=========== QUAN LI SINH VIEN ===========");
            Console.WriteLine("1: Hien thi danh sach");
            Console.WriteLine("2: Them SV");
            Console.WriteLine("3: Xoa SV");
            Console.WriteLine("4: Tim kiem SV");
            Console.WriteLine("5: Sua thong tin SV");
            Console.WriteLine("0: Thoat");
            Console.Write("Nhap lua chon cua ban: ");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Lua chon khong hop le, vui long chon lai.");
                continue;
            }
            switch (choice)
            {
                case 1:
                    Console.WriteLine("DANH SACH SV:");
                    ShowDanhSach(dsSinhVien);
                    break;
                case 2:
                    SinhVien svMoi = NhapSinhVien();
                    ThemSV(dsSinhVien, svMoi);
                    break;
                case 3:
                    Console.Write("Nhap ma SV can xoa: ");
                    if (int.TryParse(Console.ReadLine(), out int maSVCanXoa))
                        XoaSV(dsSinhVien, maSVCanXoa);
                    else
                        Console.WriteLine("Ma SV khong hop le!");
                    break;
                case 4:
                    Console.Write("Nhap tu khoa tim kiem: ");
                    string keyword = Console.ReadLine();
                    TimKiemSV(dsSinhVien, keyword);
                    break;
                case 5:
                    Console.Write("Nhap ma SV can sua: ");
                    if (int.TryParse(Console.ReadLine(), out int maSVCanSua))
                    {
                        SinhVien svSua = NhapSinhVien(maSVCanSua);
                        SuaSV(dsSinhVien, svSua);
                    }
                    else
                        Console.WriteLine("Ma SV khong hop le!");
                    break;
                case 0:
                    Console.WriteLine("Cam on ban da su dung chuong trinh!");
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le, vui long chon lai.");
                    break;
            }
        } while (choice != 0);
    }

    public static SinhVien NhapSinhVien(int? maSV = null)
    {
        int ma;
        if (maSV.HasValue)
        {
            ma = maSV.Value;
        }
        else
        {
            Console.Write("Nhap ma SV: ");
            while (!int.TryParse(Console.ReadLine(), out ma))
            {
                Console.Write("Ma SV khong hop le! Nhap lai: ");
            }
        }
        Console.Write("Nhap ten SV: ");
        string tenSV = Console.ReadLine();
        Console.Write("Nhap gioi tinh: ");
        string gioiTinh = Console.ReadLine();
        Console.Write("Nhap ngay sinh (dd/MM/yyyy): ");
        DateTime ngaySinh;
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaySinh))
        {
            Console.Write("Ngay sinh khong hop le! Nhap lai (dd/MM/yyyy): ");
        }
        Console.Write("Nhap ma khoa: ");
        string maKhoa = Console.ReadLine();
        return new SinhVien(ma, tenSV, gioiTinh, ngaySinh, maKhoa);
    }

    public static void ShowDanhSach(List<SinhVien> dsSinhVien)
    {
        if (dsSinhVien.Count == 0)
        {
            Console.WriteLine("Danh sach rong!");
            return;
        }
        dsSinhVien.ForEach(sv => Console.WriteLine(sv.ToString()));
    }

    public static bool CheckExisted(List<SinhVien> dsSinhVien, int maSV)
    {
        return dsSinhVien.Any(sv => sv.MaSV == maSV);
    }

    public static void ThemSV(List<SinhVien> dsSinhVien, SinhVien sv)
    {
        if (CheckExisted(dsSinhVien, sv.MaSV))
        {
            Console.WriteLine("Ma SV da ton tai");
            return;
        }
        dsSinhVien.Add(sv);
        Console.WriteLine("Da them SV thanh cong: " + sv.ToString());
    }

    public static void XoaSV(List<SinhVien> dsSinhVien, int maSV)
    {
        int index = dsSinhVien.FindIndex(sv => sv.MaSV == maSV);
        if (index != -1)
        {
            dsSinhVien.RemoveAt(index);
            Console.WriteLine("Xoa thanh cong!");
        }
        else
        {
            Console.WriteLine("Sinh vien khong ton tai");
        }
    }

    public static void TimKiemSV(List<SinhVien> dsSinhVien, string keyword)
    {
        keyword = keyword.ToLower();
        var results = dsSinhVien.Where(sv =>
            sv.TenSV.ToLower().Contains(keyword) ||
            sv.MaSV.ToString().Contains(keyword) ||
            sv.MaKhoa.ToLower().Contains(keyword)).ToList();
        if (results.Count > 0)
        {
            Console.WriteLine("KET QUA TIM KIEM:");
            results.ForEach(sv => Console.WriteLine(sv.ToString()));
        }
        else
        {
            Console.WriteLine("Khong tim thay ket qua nao!");
        }
    }

    public static void SuaSV(List<SinhVien> dsSinhVien, SinhVien svSauKhiSua)
    {
        int index = dsSinhVien.FindIndex(sv => sv.MaSV == svSauKhiSua.MaSV);
        if (index != -1)
        {
            dsSinhVien[index] = svSauKhiSua;
            Console.WriteLine("Da sua thong tin SV thanh cong: " + svSauKhiSua.ToString());
        }
        else
        {
            Console.WriteLine("Ma SV khong ton tai!");
        }
    }
}