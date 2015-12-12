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
    public class StatisticDAO
    {
        private Database1Entities1 _entities = new Database1Entities1();

        public IEnumerable<Statistic> getAllStatistics() 
        {
            return (from c in _entities.Statistics select c);
        }

        public Tour GetStatisticTour(int? id) 
        {
            if (id != null)
                return (from c in _entities.Tours where c.IdTour == id select c).FirstOrDefault();
            else
                return (from c in _entities.Tours select c).FirstOrDefault();
        }

        public Statistic getStatistic(int id) 
        {
            return (from c in _entities.Statistics.Include("Tour") where c.IdStatistic == id select c).FirstOrDefault();
        }

        public IEnumerable<Statistic> getStatisticByTour(int id)  
        {
            return (from c in _entities.Statistics.Include("Tour") where c.idTour == id select c);
        }

        public bool addStatistic(int TourID, Statistic statistic) 
        {
            try
            {
                statistic.Tour = GetStatisticTour(TourID);
                _entities.Statistics.Add(statistic); 
                _entities.SaveChanges(); 
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool editStatistic(int StatisticID, Statistic statistic)
        {
            try
            {
                _entities.Entry(statistic).State = EntityState.Modified; 
                _entities.SaveChanges(); 
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool deleteStatistic(int id) 
        {
            Statistic statistic = selectStatistic(id); 

            try
            {
                _entities.Statistics.Remove(statistic); 
                _entities.SaveChanges(); 
            }
            catch
            {
                return false;
            }
            return true;
        }
        public Statistic selectStatistic(int id)
        {
            return (_entities.Statistics.Find(id));
        }
    }
}