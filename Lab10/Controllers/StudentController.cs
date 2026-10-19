using Lab10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab10.Controllers
{
    [Route("Admin/Student")]
    public class StudentController : Controller
    {
        // 1. Khởi tạo danh sách static và gán dữ liệu mẫu trực tiếp tại đây để tránh bị mất hoặc lỗi constructor
        private static List<Student> students = new List<Student>()
        {
            new Student() { Id = 101, Name = "Hải Nam", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true, Address = "A1-2018", Email = "nam@g.com" },
            new Student() { Id = 102, Name = "Minh Tú", Branch = Branch.BE, Gender = Gender.FeMale, IsRegular = true, Address = "A1-2019", Email = "tu@g.com" },
            new Student() { Id = 103, Name = "Hoàng Phong", Branch = Branch.CE, Gender = Gender.Male, IsRegular = false, Address = "A1-2020", Email = "phong@g.com" },
            new Student() { Id = 104, Name = "Xuân Mai", Branch = Branch.EE, Gender = Gender.FeMale, IsRegular = false, Address = "A1-2021", Email = "mai@g.com" }
        };

        [Route("List")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View(students);
        }

        [HttpGet("Add", Name = "StudentAdd")]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem{Text="IT", Value="1"},
                new SelectListItem{Text="BE", Value="2"},
                new SelectListItem{Text="CE", Value="3"},
                new SelectListItem{Text="EE", Value="4"},
            };
            return View();
        }

        [HttpPost("Add")]
        public IActionResult Create(Student student)
        {
            int newId = students.Any() ? students.Max(s => s.Id) + 1 : 101;
            student.Id = newId;
            students.Add(student);
            return RedirectToAction("Index");
        }
    }
}