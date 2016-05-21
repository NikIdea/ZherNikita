/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dao;

import entity.Contract;
import entity.Tour;
import entity.UserA;
import java.util.List;
import javax.ejb.Local;

/**
 *
 * @author fours
 */
@Local
public interface ContractFacadeLocal {

    void create(Contract contract);
    
    void setStatus(Contract contract);
    
    void delete(Contract contract);
    
    void createContract(Contract contract, UserA user, Tour tour);

    void edit(Contract contract);

    void remove(Contract contract);

    Contract find(Object id);

    List<Contract> findAll();

    List<Contract> findRange(int[] range);

    int count();
    
    List<Contract> getUnchecked();
    
    List<Contract> getChecked();
    
    void check(Contract contract);
    
}
