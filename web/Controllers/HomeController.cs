using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using web.Models;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        // переменная для взаимодействия с бд
        private PhoneDBContext db;
        public HomeController(PhoneDBContext context)
        {
            db = context;
        }

        // методы, которые будут добавлять новый объект в базу данных и выводить из нее все объекты
        public IActionResult Index()
        {
            // Готовим данные для представления
            ViewData["Title"] = "Автомобили";
            var phones = db.Phones.Include(a => a.Brand).ToList();
            // Передаем управление "Представлению"
            return View(phones);
        }

        // ************* Добавить/Создать телефон **************
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Compans = new SelectList(db.Brands, "Id", "Name");
            Phone phone = new Phone();
            return View(phone);
        }
        [HttpPost]
        public IActionResult Create(Phone phone)
        {
            db.Phones.Add(phone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // ************* Редактировать данные телефона **************
        [HttpGet]
        public IActionResult EditPhone(int Id)
        {
            var phone = db.Phones.FirstOrDefault(p => p.Id == Id);
            ViewBag.Compans = new SelectList(db.Brands, "Id", "Name");
            return View(phone);
        }

        [HttpPost]
        public IActionResult EditPhone(Phone phone)
        {
           db.Phones.Update(phone);
           db.SaveChanges();
           return RedirectToAction("Index");
        }

        // ************* Удалить телефон **************
        public IActionResult Delete(Phone phone)
        {
            db.Phones.Attach(phone);
            db.Phones.Remove(phone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Show_brand(int id)
        {
            var instr = db.Brands.FirstOrDefault(b => b.Id == id);
            var mus = db.Phones.Where(x => x.BrandId == id);
            ViewData["Phones"] = mus;
            return View(instr);
        }

        // ************* Редактировать данные бренда телефона **************
        [HttpGet]
        public IActionResult Edit_brand(int Id)
        {
            var brand = db.Brands.FirstOrDefault(p => p.Id == Id);
            ViewBag.Compans = new SelectList(db.Brands, "Id", "Name");
            return View(brand);
        }

        [HttpPost]
        public IActionResult Edit_brand(Brand brand)
        {
            //if (ModelState.IsValid)
            //{
                db.Brands.Update(brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            //}
            //return View();
        }



    }
}