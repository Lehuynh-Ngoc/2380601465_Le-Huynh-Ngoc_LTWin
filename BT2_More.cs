using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyHocSinh
{
    public class Student
    {
        private string studentID;
        private string fullName;
        private int age;

        // Properties viết gọn với expression bodies
        public string StudentID { get => studentID; set => studentID = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public int Age { get => age; set => age = value; }

        public Student() { }

        public Student(string studentID, string fullName, int age)
        {
            StudentID = studentID;
            FullName = fullName;
            Age = age;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"MaSV: {StudentID}, Ho ten: {FullName}, Tuoi: {Age}");
        }
    }

    class Program
    {
        private static List<Student> students = new List<Student>
        {
            new Student("HS001", "Nguyen Van A", 16),
            new Student("HS002", "Tran Thi B", 17),
            new Student("HS003", "Le Van C", 15),
            new Student("HS004", "Pham Thi D", 18),
            new Student("HS005", "Hoang Van E", 14),
            new Student("HS006", "Anh Thi F", 19),
            new Student("HS007", "Bui Van G", 16)
        };

        static void Main(string[] args)
        {
            Console.WriteLine("=== QUAN LY HOC SINH BANG LINQ ===\n");

            // a. In danh sách toàn bộ danh sách học sinh
            Console.WriteLine("a. DANH SACH TOAN BO HOC SINH:");
            students.ForEach(s => s.DisplayInfo());

            // b. Tìm và in ra danh sách các học sinh có tuổi từ 15 đến 18
            Console.WriteLine("\nb. HOC SINH TU 15 DEN 18 TUOI:");
            var studentsAge15To18 = students.Where(s => s.Age >= 15 && s.Age <= 18);
            studentsAge15To18.ToList().ForEach(s => s.DisplayInfo());

            // c. Tìm và in ra học sinh có tên bắt đầu bằng chữ "A"
            Console.WriteLine("\nc. HOC SINH TEN BAT DAU BANG 'A':");
            var studentsNameStartsWithA = students.Where(s => s.FullName.StartsWith("A"));
            if (studentsNameStartsWithA.Any())
                studentsNameStartsWithA.ToList().ForEach(s => s.DisplayInfo());
            else
                Console.WriteLine("Khong co hoc sinh nao ten bat dau bang 'A'");

            // d. Tính tổng tuổi của tất cả học sinh trong danh sách
            Console.WriteLine("\nd. TONG TUOI TAT CA HOC SINH:");
            int totalAge = students.Sum(s => s.Age);
            Console.WriteLine($"Tong tuoi: {totalAge}");

            // e. Tìm và in ra học sinh có tuổi lớn nhất
            Console.WriteLine("\ne. HOC SINH CO TUOI LON NHAT:");
            var oldestStudent = students.OrderByDescending(s => s.Age).FirstOrDefault();
            if (oldestStudent != null)
                oldestStudent.DisplayInfo();

            // f. Sắp xếp danh sách học sinh theo tuổi tăng dần
            Console.WriteLine("\nf. DANH SACH SAP XEP THEO TUOI TANG DAN:");
            var sortedByAge = students.OrderBy(s => s.Age);
            sortedByAge.ToList().ForEach(s => s.DisplayInfo());

            // Các truy vấn LINQ khác để tham khảo
            Console.WriteLine("\n=== MOT SO TRUY VAN LINQ KHAC (Luu tam de nho)===");

            // Tìm học sinh theo StudentID
            Console.WriteLine("\nTim hoc sinh co StudentID = \"HS003\":");
            var studentById = students.FirstOrDefault(s => s.StudentID == "HS003");
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
                    Console.WriteLine($"  - {student.FullName} (Ma HS: {student.StudentID})");
                }
            }

            Console.WriteLine("\nNhan phim bat ky de thoat...");
            Console.ReadKey();
        }
    }
}
