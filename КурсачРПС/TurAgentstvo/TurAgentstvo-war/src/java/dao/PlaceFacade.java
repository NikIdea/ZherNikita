/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dao;

import entity.Contract;
import entity.Place;
import entity.Tour;
import java.util.List;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

/**
 *
 * @author fours
 */
@Stateless
public class PlaceFacade extends AbstractFacade<Place> implements PlaceFacadeLocal {

    @PersistenceContext(unitName = "TurAgentstvo-warPU")
    private EntityManager em;

    @Override
    protected EntityManager getEntityManager() {
        return em;
    }

    public PlaceFacade() {
        super(Place.class);
    }
    
    @Override
    public List<Tour> getPlaceTours(Long placeId){
        Query query;
        query = em.createNativeQuery("SELECT * FROM Tour as t where t.place_id = ?1", Tour.class);
        query.setParameter(1, placeId);
        List<Tour> fullList = query.getResultList();
        return fullList;
    }
}
