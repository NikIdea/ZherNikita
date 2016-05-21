/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package view;

import dao.ContractFacadeLocal;
import dao.UserAFacadeLocal;
import entity.Contract;
import entity.UserA;
import java.io.Serializable;
import java.util.List;
import javax.ejb.EJB;
import javax.enterprise.context.SessionScoped;
import javax.inject.Named;
import javax.xml.registry.infomodel.User;

/**
 *
 * @author fours
 */
@Named
@SessionScoped
public class UserView implements Serializable{
@EJB
private UserAFacadeLocal userFacade;

public UserView(){
    this.user = user;
}

private UserA user;

public List<UserA> getAllUsers(){
    return userFacade.findAll();
}

   
}
