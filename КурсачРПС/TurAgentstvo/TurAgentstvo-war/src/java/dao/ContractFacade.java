/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dao;

import entity.Contract;
import entity.Report;
import entity.Tour;
import entity.UserA;
import java.util.Date;
import java.util.List;
import javax.ejb.EJB;
import javax.ejb.EJBException;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.servlet.annotation.HttpConstraint;
import javax.servlet.annotation.ServletSecurity;

/**
 *
 * @author fours
 */
@Stateless
public class ContractFacade extends AbstractFacade<Contract> implements ContractFacadeLocal {

    @PersistenceContext(unitName = "TurAgentstvo-warPU")
    private EntityManager em;

    @Override
    protected EntityManager getEntityManager() {
        return em;
    }

    @EJB
    ReportFacadeLocal reportFacade;
    
    public ContractFacade() {
        super(Contract.class);
    }
    //Смотрим все непроверенные контракты
    @Override
    public List<Contract> getUnchecked(){
        Query query;
        query = em.createNativeQuery("SELECT * FROM Contract as c where c.status = 'unchecked'", Contract.class);
        List<Contract> fullList = query.getResultList();
        return fullList;
    }
    //Смотрим все проверенные контракты
    @Override
    public List<Contract> getChecked(){
        Query query;
        query = em.createNativeQuery("SELECT * FROM Contract as c where c.status = 'checked'", Contract.class);
        List<Contract> fullList = query.getResultList();
        return fullList;
    }
    
    @Override
    public void createContract(Contract contract, UserA user, Tour tour){
        contract.setUser(user);
        contract.setTour(tour);
        contract.setStatus("unchecked");
        em.flush();
        em.persist(contract);
    }
    
    
    //Транзакция, утверждаем контракт и добавляем в репорт информацию из контракта
    @Override
    public void check(Contract contract){
        int lastId = reportFacade.count();
        Long lastIdLong = Long.valueOf(lastId);
        Report oldReport = reportFacade.find(lastIdLong);
        Date d = new Date();
        Report report = new Report();
        if(contract.getTour().getPrice()>200){
        contract.setStatus("checked");
        reportFacade.create(report);

            report.setSumm(contract.getTour().getPrice()*contract.getTour().getQuantity());

        report.setDateTime(d);
        }
        else{
            throw new EJBException("Цена тура не может быть меньше 200!");
        }
        em.flush();
        em.persist(contract);
    }
    
    @Override
    public void setStatus(Contract contract){
        contract.setStatus("checked");
        //em.persist(contract);
    }
    
    @Override 
    public void delete(Contract contract){
    em.detach(contract);
}
    
}
