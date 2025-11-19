using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLySinhVien
{
    public class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public double DiemTB { get; set; }

        public SinhVien() 
        {
            MaSV = "SV001";
            HoTen = "Le Huynh Ngoc ";
            DiemTB = 8.5;
        }

        public SinhVien(string maSV, string hoTen, double diemTB)
        {
            MaSV = maSV;
            HoTen = hoTen;
            DiemTB = diemTB;
        }

        public void XuatThongTin()
        {
            Console.Write($"Ma SV: {MaSV}, Ho ten: {HoTen}, Diem TB: {DiemTB:F1}");
        }

        public bool IsDat()
        {
            return DiemTB >= 5;
        }

        public void NhapThongTin()
        {
            Console.Write("Nhap ma SV: ");
            MaSV = Console.ReadLine();

            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhap diem TB: ");
            DiemTB = double.Parse(Console.ReadLine());
        }
    }

    class Program
    {
        private static List<SinhVien> danhSachSV = new List<SinhVien>
        {
            new SinhVien(),
            new SinhVien("SV002", "Tran Thi B", 4.0)
        };

        static void Main(string[] args)
        {
            int luaChon;

            do
            {
                Console.WriteLine("\n=== QUAN LY SINH VIEN ===");
                Console.WriteLine("1. Hien thi danh sach sinh vien");
                Console.WriteLine("2. Them sinh vien moi");
                Console.WriteLine("3. Xoa sinh vien theo MSSV");
                Console.WriteLine("4. Chinh sua sinh vien theo MSSV");
                Console.WriteLine("5. Thoat");
                Console.Write("Chon chuc nang: ");

                luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        HienThiDanhSach();
                        break;
                    case 2:
                        ThemSinhVien();
                        break;
                    case 3:
                        XoaSinhVien();
                        break;
                    case 4:
                        ChinhSuaSinhVien();
                        break;
                    case 5:
                        Console.WriteLine("Tam biet!");
                        break;
                    default:
                        Console.WriteLine("Chuc nang khong hop le!");
                        break;
                }
            } while (luaChon != 5);
        }

        static void HienThiDanhSach()
        {
            Console.WriteLine("\n=== DANH SACH SINH VIEN ===");
            if (danhSachSV.Count == 0)
            {
                Console.WriteLine("Danh sach trong!");
                return;
            }

            for (int i = 0; i < danhSachSV.Count; i++)
            {
                Console.WriteLine($"\nSinh vien {i + 1}:");
                danhSachSV[i].XuatThongTin();
                Console.Write(danhSachSV[i].IsDat() ? " (Dat)" : " (Khong dat)");
            }
        }

        static void ThemSinhVien()
        {
            Console.WriteLine("\n=== THEM SINH VIEN MOI ===");
            SinhVien sv = new SinhVien();
            sv.NhapThongTin();

            // Kiểm tra trùng MSSV
            if (danhSachSV.Any(s => s.MaSV == sv.MaSV))
            {
                Console.WriteLine("Loi: Ma SV da ton tai!");
                return;
            }

            danhSachSV.Add(sv);
            Console.WriteLine("Them sinh vien thanh cong!");
        }

        static void XoaSinhVien()
        {
            Console.WriteLine("\n=== XOA SINH VIEN ===");
            Console.Write("Nhap MSSV can xoa: ");
            string mssv = Console.ReadLine();

            SinhVien sv = danhSachSV.FirstOrDefault(s => s.MaSV == mssv);
            if (sv != null)
            {
                danhSachSV.Remove(sv);
                Console.WriteLine("Da xoa sinh vien thanh cong!");
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien voi MSSV: " + mssv);
            }
        }

        static void ChinhSuaSinhVien()
        {
            Console.WriteLine("\n=== CHINH SUA SINH VIEN ===");
            Console.Write("Nhap MSSV can chinh sua: ");
            string mssv = Console.ReadLine();

            SinhVien sv = danhSachSV.FirstOrDefault(s => s.MaSV == mssv);
            if (sv != null)
            {
                Console.WriteLine("\nThong tin hien tai:");
                sv.XuatThongTin();

                Console.WriteLine("\nNhap thong tin moi:");
                Console.Write("Nhap ho ten moi: ");
                sv.HoTen = Console.ReadLine();

                Console.Write("Nhap diem TB moi: ");
                sv.DiemTB = double.Parse(Console.ReadLine());

                Console.WriteLine("Chinh sua thanh cong!");
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien voi MSSV: " + mssv);
            }
        }
    }
}
