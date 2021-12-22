using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_Managment_System.Models;
namespace Student_Managment_System.Controllers
{
    public class StudentController : Controller
    {
        public ViewResult Remove(int id)
        {
            StudentRepository.RemoveStudent(id);
            return View("ListStudents", StudentRepository.GetStudents());
        }

        public ViewResult Details(int id) {
            Student s = StudentRepository.FindStudent(id);
            return View("Thanks", s);
        }

        public ViewResult Edit(int id) {
            Student s = StudentRepository.FindStudent(id);
            return View("Edit", s);

        }
        [HttpPost]
        public ViewResult Edit(Student s)
        {
            if (ModelState.IsValid)
            {
                
                StudentRepository.EditStudent(s);

                return View("ListStudents", StudentRepository.GetStudents());
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Please enter correct data");
                return View();
            }

        }

        public ViewResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public ViewResult StudentForm() {
            return View();
        }
        [HttpPost]
        public ViewResult StudentForm(Student s)
        {
           
            if (ModelState.IsValid)
            {
                StudentRepository.AddStudent(s);
                return View("Thanks", s);
            }
            else {
                ModelState.AddModelError(String.Empty, "Please enter correct data");
                return View();
            }
        }

        public ViewResult ListStudents() {
            
            return View(StudentRepository.GetStudents());
        }
    }
}
