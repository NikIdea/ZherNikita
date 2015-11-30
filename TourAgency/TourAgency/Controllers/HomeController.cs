
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
        TourDAO tourDAO = new TourDAO();

        public ActionResult Index()
        {
            return View(tourDAO.getAllTours());
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
        //[Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }
        //
        // POST: /Home/Create
        [AcceptVerbs(HttpVerbs.Post)]
        //[Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Exclude = "IdTour")] Tour tour)
        {
            try
            {
                if (tourDAO.addTour(tour))
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
        //[Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {

            var tour = tourDAO.getAllTours().First(m => m.IdTour == id);
            ViewData.Model = tour;
            return View();
        }
        //
        // POST: /Home/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        //[Authorize(Roles = "Administrator")]
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
        //[Authorize(Roles = "Administrator")]
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
        //[Authorize(Roles = "Administrator")]
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
    }
}
