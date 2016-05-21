/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dao;

import entity.UserA;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

/**
 *
 * @author fours
 */
@Stateless
public class UserAFacade extends AbstractFacade<UserA> implements UserAFacadeLocal {

    @PersistenceContext(unitName = "TurAgentstvo-warPU")
    private EntityManager em;

    @Override
    protected EntityManager getEntityManager() {
        return em;
    }

    public UserAFacade() {
        super(UserA.class);
    }
    
}
