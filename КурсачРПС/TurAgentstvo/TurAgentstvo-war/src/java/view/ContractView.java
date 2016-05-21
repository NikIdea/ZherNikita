/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package view;

import dao.ContractFacadeLocal;
import dao.TourFacadeLocal;
import dao.UserAFacadeLocal;
import entity.Contract;
import entity.Tour;
import entity.UserA;
import java.io.Serializable;
import java.util.List;
import javax.annotation.security.RolesAllowed;
import javax.ejb.EJB;
import javax.enterprise.context.SessionScoped;
import javax.inject.Named;

/**
 *
 * @author fours
 */
@Named
@SessionScoped
public class ContractView implements Serializable{
//инъекция 
@EJB
private ContractFacadeLocal contractFacade;
@EJB
private TourFacadeLocal tourFacade;
@EJB
private UserAFacadeLocal userFacade;

public ContractView(){
    this.contract = new Contract();
}

private Contract contract;

    public Contract getContract() {
        return contract;
    }

    public void setContract(Contract contract) {
        this.contract = contract;
    }

//получить проверенные
public List<Contract> getAllContracts(){
    return contractFacade.getChecked();
}

//получить непроверенные
public List<Contract> getUncheckedContracts(){
    return contractFacade.getUnchecked();
}

//та самая транзакция
public String check(Long id){
   contract = contractFacade.find(id);
   contractFacade.check(contract);
   contractFacade.setStatus(contract);
   return deleteContract(id);
}

//добавить котнракт

public String addContract(){
    contractFacade.create(contract);
    return "contracts.xhtml";
}

public String deleteContract(Long id){
    contract = contractFacade.find(id);
    contractFacade.remove(contract);
    return "contracts.xhtml?faces-redirect=true";
}

public String editThis(){
    return "/user/tours.xhtml";
}

public String gohome(){
    return "/faces/index.xhtml?faces-redirect=true";
}

}
