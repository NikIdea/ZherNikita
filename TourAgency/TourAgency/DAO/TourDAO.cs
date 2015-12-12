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
    public class TourDAO
    {
        private Database1Entities1 _entities = new Database1Entities1(); 

        public IEnumerable<Tour> getAllTours() 
        {
            return (from c in _entities.Tours select c); 
        }


        public bool addTour(Tour tour) 
        {
            try
            {
                _entities.Tours.Add(tour); 
                _entities.SaveChanges(); 
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Tour getTour(int id) 
        {
            return (from c in _entities.Tours where c.IdTour == id select c).FirstOrDefault();
        }

        public bool editTour(Tour tour) 
        {
            Tour originalTour = getTour(Convert.ToInt32(tour.IdTour)); 
            try
            { 
                _entities.Entry(originalTour).State = EntityState.Modified; 
                _entities.SaveChanges(); 
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool deleteTour(Tour tour) 
        {
            Tour originalTour = getTour(Convert.ToInt32(tour.IdTour)); 

            try
            {
                _entities.Tours.Remove(originalTour); 
                _entities.SaveChanges(); 
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}