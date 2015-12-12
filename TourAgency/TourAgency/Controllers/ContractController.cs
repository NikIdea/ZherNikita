using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using TourAgency.Models;
using TourAgency.DAO;

namespace TourAgency.Controllers
{
    public class ContractController : Controller
    {
        //
        // GET: /Contact/
        ContractDAO contractDAO = new ContractDAO();
        TourDAO tourDAO = new TourDAO();

        [Authorize(Roles = "Client, Manager, Administrator")]
        public ActionResult Index(int? id)
        {
            ViewData["tour"] = tourDAO.getAllTours();
            return View(contractDAO.getAllContracts());
        }

        [Authorize(Roles = "Client, Manager, Administrator")]
        public ActionResult Details(int id)
        {
            return View(contractDAO.getContract(id));

        }


        protected bool ViewDataSelectList(int idTour)
        {
            var tour = tourDAO.getAllTours();
            ViewData["idTour"] = new SelectList(tour, "IdTour", "number", idTour);
            return tour.Count() > 0;
        }

        [Authorize(Roles = "Client, Manager, Administrator")]
        public ActionResult CreateBron(int id)
        {
            Contract t = new Contract();
            t.idTour = id;
            t.condition = "Забронирован";
            t.idUser = WebSecurity.CurrentUserId;
            if (!ViewDataSelectList(-1))
                return RedirectToAction("Index");
            return View("Create", t);
        }

        [Authorize(Roles = "Client, Manager, Administrator")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateBron(int idTour, [Bind(Exclude = "IdTour")] Contract contract)
        {
            try
            {
                if (contractDAO.addBronContract(idTour, contract))
                    return RedirectToAction("Index");
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize(Roles = "Client, Manager, Administrator")]
        public ActionResult CreateBought(int id)
        {
            Contract t = new Contract();
            t.idTour = id;
            t.condition = "Куплен";
            t.idUser = WebSecurity.CurrentUserId;
            if (!ViewDataSelectList(-1))
                return RedirectToAction("Index", "Home");
            return View("Create", t);
        }


        [Authorize(Roles = "Client, Manager, Administrator")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateBought(int idTour, [Bind(Exclude = "IdTour")] Contract contract)
        {
            try
            {
                if (contractDAO.addBoughtContract(idTour, contract))
                    return RedirectToAction("Index");
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize(Roles = "Manager, Client")]
        public ActionResult Edit(int id)
        {
            Contract contract = contractDAO.getContract(id);
            if (!ViewDataSelectList(Convert.ToInt32(contract.Tour.IdTour)))
                return RedirectToAction("Index");
            return View(contractDAO.getContract(id));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Manager, Client")]
        public ActionResult Edit(int idTour, int id, Contract contract)
        {
            if (contractDAO.editContract(idTour, contract))
                return RedirectToAction("Index");
            else
            {
                ViewDataSelectList(-1);
                return View("Edit", contractDAO.getContract(id));
            }
        }

        public ActionResult Delete(int id)
        {
            return View("Delete", contractDAO.getContract(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id, Contract contract)
        {

            if (contractDAO.deleteContract(id))
                return RedirectToAction("Index");
            else return View("Delete", contractDAO.getContract(id));

        }
    }
}
