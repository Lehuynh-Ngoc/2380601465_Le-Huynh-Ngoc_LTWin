using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyHocSinh
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Student() { }

        public Student(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"MSSV: {Id}, Ten: {Name}, Tuoi: {Age}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Tạo danh sách học sinh với ít nhất 5 học sinh
            List<Student> students = new List<Student>
            {
                new Student(1, "Nguyen Van A", 16),
                new Student(2, "Tran Thi B", 17),
                new Student(3, "Le Van C", 15),
                new Student(4, "Pham Thi D", 18),
                new Student(5, "Hoang Van E", 14),
                new Student(6, "Anh Thi F", 19),
                new Student(7, "Bui Van G", 16)
            };

            Console.WriteLine("=== QUAN LY HOC SINH BANG LINQ ===\n");

            // a. In toàn bộ danh sách học sinh
            Console.WriteLine("a. DANH SACH TOAN BO HOC SINH:");
            students.ForEach(s => s.DisplayInfo());

            // b. Học sinh có tuổi từ 15 đến 18
            Console.WriteLine("\nb. HOC SINH TU 15 DEN 18 TUOI:");
            var studentsAge15To18 = students.Where(s => s.Age >= 15 && s.Age <= 18);
            studentsAge15To18.ToList().ForEach(s => s.DisplayInfo());

            // c. Học sinh có tên bắt đầu bằng chữ "A"
            Console.WriteLine("\nc. HOC SINH TEN BAT DAU BANG 'A':");
            var studentsNameStartsWithA = students.Where(s => s.Name.StartsWith("A"));
            if (studentsNameStartsWithA.Any())
                studentsNameStartsWithA.ToList().ForEach(s => s.DisplayInfo());
            else
                Console.WriteLine("Khong co hoc sinh nao ten bat dau bang 'A'");

            // d. Tính tổng tuổi của tất cả học sinh
            Console.WriteLine("\nd. TONG TUOI TAT CA HOC SINH:");
            int totalAge = students.Sum(s => s.Age);
            Console.WriteLine($"Tong tuoi: {totalAge}");

            // e. Học sinh có tuổi lớn nhất
            Console.WriteLine("\ne. HOC SINH CO TUOI LON NHAT:");
            var oldestStudent = students.OrderByDescending(s => s.Age).FirstOrDefault();
            if (oldestStudent != null)
                oldestStudent.DisplayInfo();

            // f. Sắp xếp danh sách theo tuổi tăng dần
            Console.WriteLine("\nf. DANH SACH SAP XEP THEO TUOI TANG DAN:");
            var sortedByAge = students.OrderBy(s => s.Age);
            sortedByAge.ToList().ForEach(s => s.DisplayInfo());

            // Các truy vấn LINQ khác để tham khảo
            Console.WriteLine("\n=== MOT SO TRUY VAN LINQ KHAC (Luu tam de nho)===");

            // Tìm học sinh theo ID
            Console.WriteLine("\nTim hoc sinh co MSSV = 3:");
            var studentById = students.FirstOrDefault(s => s.Id == 3);
            studentById?.DisplayInfo();

            // Đếm số học sinh
            Console.WriteLine($"\nTong so hoc sinh: {students.Count}");

            // Tuổi trung bình
            Console.WriteLine($"Tuoi trung binh: {students.Average(s => s.Age):F2}");

            // Nhóm học sinh theo tuổi
            Console.WriteLine("\nHoc sinh nhom theo tuoi:");
            var groupByAge = students.GroupBy(s => s.Age)
                                    .OrderBy(g => g.Key);

            foreach (var group in groupByAge)
            {
                Console.WriteLine($"Tuoi {group.Key}: {group.Count()} hoc sinh");
                foreach (var student in group)
                {
                    Console.WriteLine($"  - {student.Name} (ID: {student.Id})");
                }
            }

            Console.WriteLine("\nNhan phim bat ky de thoat...");
            Console.ReadKey();
        }
    }
}