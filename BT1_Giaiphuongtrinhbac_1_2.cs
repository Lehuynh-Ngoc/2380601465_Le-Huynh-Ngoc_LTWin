using System;

namespace GiaiPhuongTrinh
{
    public class PhuongTrinhBac1
    {
        protected double hesoA;
        protected double hesoB;

        public PhuongTrinhBac1(double a, double b)
        {
            hesoA = a;
            hesoB = b;
        }

        public virtual void Giai()
        {
            if (hesoA == 0)
            {
                Console.WriteLine(hesoB == 0 ? "Phuong trinh vo so nghiem" : "Phuong trinh vo nghiem");
            }
            else
            {
                double x = -hesoB / hesoA;
                Console.WriteLine($"Nghiem duy nhat: x = {x:F2}");
            }
        }

        public void HienThiPhuongTrinh()
        {
            string pt = ChuyenDoiHeSo(hesoA, "x", true) + ChuyenDoiHeSo(hesoB, "", false);
            if (string.IsNullOrEmpty(pt)) pt = "0";
            Console.WriteLine($"Phuong trinh co dang sau: {pt} = 0");
        }

        protected string ChuyenDoiHeSo(double heso, string bien, bool laHeSoDau = false)
        {
            if (heso == 0) return "";

            string dau = "";
            string giatri = "";

            // Xét dấu hệ số đầu tiên
            if (heso > 0)
            {
                if (!laHeSoDau) dau = "+ ";
            }
            else if (heso < 0)
            {
                dau = "- ";
            }

            double absHeso = Math.Abs(heso);

            if (absHeso == 1 && !string.IsNullOrEmpty(bien))
                giatri = bien;
            else if (!string.IsNullOrEmpty(bien))
                giatri = $"{absHeso}{bien}";
            else
                giatri = absHeso.ToString();

            return dau + giatri;
        }

        public class PhuongTrinhBac2 : PhuongTrinhBac1
        {
            private double hesoC;

            public PhuongTrinhBac2(double a, double b, double c) : base(a, b)
            {
                hesoC = c;
            }

            public override void Giai()
            {
                if (hesoA == 0)
                {
                    Console.WriteLine("Day la phuong trinh bac 1:");
                    base.Giai();
                    return;
                }

                HienThiPhuongTrinh();

                double delta = hesoB * hesoB - 4 * hesoA * hesoC;

                if (delta < 0)
                    Console.WriteLine("Phuong trinh vo nghiem");
                else if (delta == 0)
                {
                    double x = -hesoB / (2 * hesoA);
                    Console.WriteLine($"Nghiem kep: x1 = x2 = {x:F2}");
                }
                else
                {
                    double x1 = (-hesoB + Math.Sqrt(delta)) / (2 * hesoA);
                    double x2 = (-hesoB - Math.Sqrt(delta)) / (2 * hesoA);
                    Console.WriteLine($"2 nghiem phan biet:\nx1 = {x1:F2}\nx2 = {x2:F2}");
                }
            }

            public new void HienThiPhuongTrinh()
            {
                string pt = ChuyenDoiHeSo(hesoA, "x²", true) + ChuyenDoiHeSo(hesoB, "x", false) + ChuyenDoiHeSo(hesoC, "", false);
                if (string.IsNullOrEmpty(pt)) pt = "0";
                Console.WriteLine($"Phuong trinh co dang sau: {pt} = 0");
            }
        }

        class Program
        {
            static void Main()
            {
                int luaChon;

                do
                {
                    Console.WriteLine("\n=== MENU GIAI PHUONG TRINH ===");
                    Console.WriteLine("1. Giai phuong trinh bac 1");
                    Console.WriteLine("2. Giai phuong trinh bac 2");
                    Console.WriteLine("0. Thoat");
                    Console.Write("Chon chuc nang: ");

                    luaChon = int.Parse(Console.ReadLine());

                    switch (luaChon)
                    {
                        case 1:
                            GiaiPhuongTrinhBac1();
                            break;
                        case 2:
                            GiaiPhuongTrinhBac2();
                            break;
                        case 0:
                            Console.WriteLine("Tam biet!");
                            break;
                        default:
                            Console.WriteLine("Chuc nang khong hop le!");
                            break;
                    }
                } while (luaChon != 0);
            }

            static void GiaiPhuongTrinhBac1()
            {
                Console.WriteLine("\n=== GIAI PHUONG TRINH BAC 1 ===");
                Console.Write("Nhap he so a: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Nhap he so b: ");
                double b = double.Parse(Console.ReadLine());

                PhuongTrinhBac1 pt = new PhuongTrinhBac1(a, b);
                pt.HienThiPhuongTrinh();
                pt.Giai();
            }

            static void GiaiPhuongTrinhBac2()
            {
                Console.WriteLine("\n=== GIAI PHUONG TRINH BAC 2 ===");
                Console.Write("Nhap he so a: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Nhap he so b: ");
                double b = double.Parse(Console.ReadLine());
                Console.Write("Nhap he so c: ");
                double c = double.Parse(Console.ReadLine());

                PhuongTrinhBac2 pt = new PhuongTrinhBac2(a, b, c);
                pt.Giai();
            }
        }
    }
}