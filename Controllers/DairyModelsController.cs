using Diaryapp.Data;
using Diaryapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diaryapp.Controllers
{
    public class DairyModelsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DairyModelsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<DiaryModel> entries = _db.DiaryModels.ToList();
            return View(entries);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DiaryModel obj)
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError(key:"Title", errorMessage:"Title is too short dummy!");
            }

            if (ModelState.IsValid)
            {
                _db.DiaryModels.Add(obj); //Adds to the new entry DB
                _db.SaveChanges(); // Saves the changes to the DB
                return RedirectToAction(actionName: "Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            DiaryModel? dairyModel = _db.DiaryModels.Find(id);

            if (dairyModel == null)
            {
                return NotFound();
            }

            return View(dairyModel);
        }


        [HttpPost]
        public IActionResult Edit(DiaryModel obj)
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError(key: "Title", errorMessage: "Title is too short dummy!");
            }

            if (ModelState.IsValid)
            {
                _db.DiaryModels.Update(obj); //Updates the new entry to the DB
                _db.SaveChanges(); // Saves the changes to the DB
                return RedirectToAction(actionName: "Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            DiaryModel? dairyModel = _db.DiaryModels.Find(id);

            if (dairyModel == null)
            {
                return NotFound();
            }

            return View(dairyModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            // Retrive obj to delete
            var diaryModel = _db.DiaryModels.FirstOrDefault(d => d.Id == id);

            if(diaryModel == null)
            {
                return NotFound();
            }

            //Perfrom the deletion
            _db.DiaryModels.Remove(diaryModel); // Remove the entry from the database
            _db.SaveChanges(); //Save changes to the DB

            return RedirectToAction(actionName: "Index"); // Redirect to index page


        }

    }
}
