 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using TourAgency.Models;
using TourAgency.DAO;


namespace TourAgency.Controllers
{
    public class StatisticController : Controller
    {
       
       StatisticDAO statisticDAO = new StatisticDAO();
       TourDAO tourDAO = new TourDAO();

        
        public ActionResult Index(int? id)
        {
            ViewData["tour"] = tourDAO.getAllTours();
            return View(statisticDAO.getAllStatistics());
        }

        public ActionResult Details(int id)
        {
            return View(statisticDAO.getStatistic(id));
           
        }

        protected bool ViewDataSelectList(int idTour)
        {
            var tour = tourDAO.getAllTours();
            ViewData["idTour"] = new SelectList(tour, "idTour", "idTour", idTour);
            return tour.Count() > 0;
        }

        [Authorize(Roles = "Administrator, Manager")]
        public ActionResult Create()
        {
            if (!ViewDataSelectList(-1))
                return RedirectToAction("Index");
            return View("Create");
        }

        [Authorize(Roles = "Administrator, Manager")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(int idTour, [Bind(Exclude = "IdTour")] Statistic statistic)
        {
            try
            {
                if (statisticDAO.addStatistic(idTour, statistic))
                    return RedirectToAction("Index");
                else
                {
                    ViewDataSelectList(idTour);
                    return View("Create");
                }
                   
            }
            catch
            {
                return View("Create");
            }
        }

        [Authorize(Roles = "Administrator, Manager")]
        public ActionResult Edit(int id)
        {
            Statistic statistic = statisticDAO.getStatistic(id);
            if (!ViewDataSelectList(Convert.ToInt32(statistic.Tour.IdTour)))
                return RedirectToAction("Index");
            return View(statisticDAO.getStatistic(id));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int idTour, int id, Statistic statistic)
        {

            if (statisticDAO.editStatistic(idTour, statistic))
                return RedirectToAction("Index");
            else
            {
                ViewDataSelectList(-1);
                return View("Edit", statisticDAO.getStatistic(id));
            }
        }

        [Authorize(Roles = "Administrator, Manager")]
        public ActionResult Delete(int id)
        {
            return View("Delete", statisticDAO.getStatistic(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id, Statistic statistic)
        {

            if (statisticDAO.deleteStatistic(id))
                return RedirectToAction("Index");
            else return View("Delete", statisticDAO.getStatistic(id));

        }
    }
}
