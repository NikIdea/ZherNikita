using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TourAgency.Models;
using TourAgency.DAO;

namespace TourAgency.Controllers
{
    public class HomeController : Controller
    {
        private Database1Entities1 _entities = new Database1Entities1(); 
        TourDAO tourDAO = new TourDAO();

        public ActionResult Index(string OneTourName)
        {
            var search = from s in _entities.Tours select s;
            if (!String.IsNullOrEmpty(OneTourName))
            {
                search = search.Where(c => c.description.Contains(OneTourName));
            }
            return View(search);
        }
        //
        // GET: /Home/Details/5
        
        public ActionResult Details(int id)
        {
            var tour = tourDAO.getAllTours().First(m => m.IdTour == id);
            if (tour != null)
            {
                return View("Details", tour);
            }
            else
            {
                return HttpNotFound();
            }
        }
        //
        // GET: /Home/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            Tour r = new Tour();
            r.IdTour = 0;
            r.nameTour = null;
            r.description = null;
            r.startDate = DateTime.Now.AddDays(30);
            return View("Create", r);
        }
        //
        // POST: /Home/Create
        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(Tour tour)
        {
            try
            {
                string tmp2 = tour.price.ToString();
                if (string.IsNullOrEmpty(tour.nameTour))
                {
                    ModelState.AddModelError("nameTour", "Поле 'название тура' обязательно для заполения");
                } 
                if (string.IsNullOrEmpty(tour.description))
                    {
                        ModelState.AddModelError("description", "Поле 'описание' обязательно для заполнения");
                    }
                if (string.IsNullOrEmpty(tmp2))
                {
                    ModelState.AddModelError("price", "Поле 'цена' обязательно для заполнения");
                }
                if (ModelState.IsValid && tourDAO.addTour(tour))

                    return RedirectToAction("Index");
                else
                    return View("Create");
            }
            catch
            {
                return View("Create");
            }
        }
        //
        // GET: /Home/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            var tour = tourDAO.getAllTours().First(m => m.IdTour == id);
            ViewData.Model = tour;
            return View();
        }
        //
        // POST: /Home/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id, FormCollection collection)
        {

            try
            {
                var tour = tourDAO.getAllTours().First(m => m.IdTour == id);
                UpdateModel(tour);
                tourDAO.editTour(tour);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Movies/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tour = tourDAO.getAllTours().First(m => m.IdTour == id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
       // [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            
            try
            {
                var tour = tourDAO.getAllTours().First(m => m.IdTour == id);
                tourDAO.deleteTour(tour);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchForNameDescription(string OneTourName)
        {
            var stops = from s in _entities.Tours select s;
            if (!String.IsNullOrEmpty(OneTourName))
            {
                stops = stops.Where(c => c.description.Contains(OneTourName));
            }
            return View();
        }
    }
}
