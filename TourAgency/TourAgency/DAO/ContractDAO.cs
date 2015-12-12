using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Data.EntityModel;
using System.Data;
using System.Data.Objects;
using System.Data.SqlClient;
using TourAgency.Models;
using TourAgency.DAO;

namespace TourAgency.DAO
{
    public class ContractDAO
    {
        private Database1Entities1 _entities = new Database1Entities1();

        public IEnumerable<Contract> getAllContracts()
        {
            return (from c in _entities.Contracts select c);
        }

        public Tour GetContractTour(int? id)
        {
            if (id != null)
                return (from c in _entities.Tours where c.IdTour == id select c).FirstOrDefault();
            else
                return (from c in _entities.Tours select c).FirstOrDefault();
        }

        public Contract getContract(int id)
        {
            return (from c in _entities.Contracts.Include("Tour") where c.IdContract == id select c).FirstOrDefault();
        }

        public IEnumerable<Contract> getContractByTour(int id)
        {
            return (from c in _entities.Contracts.Include("Tour") where c.idTour == id select c);
        }

        public bool addBronContract(int idTour, Contract contract)
        {
            try
            {
                contract.Tour = GetContractTour(idTour);
                TourDAO tourDAO = new TourDAO();
                Tour oldTour = _entities.Tours.Find(idTour);

                    _entities.Contracts.Add(contract);
                    _entities.Entry(oldTour).State = EntityState.Modified;
                    _entities.SaveChanges();
                
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool addBoughtContract(int idTour, Contract contract)
        {
            try
            {
                contract.Tour = GetContractTour(idTour);
                TourDAO tourDAO = new TourDAO();
                Tour oldTour = _entities.Tours.Find(idTour);

                    _entities.Contracts.Add(contract);
                    _entities.Entry(oldTour).State = EntityState.Modified;
                    _entities.SaveChanges();
                
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool editContract(int ContractID, Contract contract)
        {

            try
            {
                _entities.Entry(contract).State = EntityState.Modified;
                _entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool deleteContract(int id)
        {
            TourDAO tourDAO = new TourDAO();
            Contract contract = selectContract(id);
            try
            {
                Tour oldTour = _entities.Tours.Find(contract.idTour);
                _entities.Entry(oldTour).State = EntityState.Modified;
                _entities.Contracts.Remove(contract);
                _entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public Contract selectContract(int id)
        {
            return (_entities.Contracts.Find(id));
        }
    }
}