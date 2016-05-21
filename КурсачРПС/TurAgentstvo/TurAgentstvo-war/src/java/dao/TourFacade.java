/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dao;

import entity.Tour;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

/**
 *
 * @author fours
 */
@Stateless
public class TourFacade extends AbstractFacade<Tour> implements TourFacadeLocal {

    @PersistenceContext(unitName = "TurAgentstvo-warPU")
    private EntityManager em;

    @Override
    protected EntityManager getEntityManager() {
        return em;
    }

    public TourFacade() {
        super(Tour.class);
    }
    
    @Override
    public void del(Tour tour){
        em.detach(tour);
    }
}
