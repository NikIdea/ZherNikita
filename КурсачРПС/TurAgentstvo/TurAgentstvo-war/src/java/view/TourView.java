/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package view;

import dao.ContractFacadeLocal;
import dao.TourFacadeLocal;
import entity.Contract;
import entity.Tour;
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
public class TourView implements Serializable{
//инъекция
@EJB
private TourFacadeLocal tourFacade;

public TourView(){
    this.tour = new Tour();
}

private Tour tour;

    public Tour getTour() {
        return tour;
    }

    public void setTour(Tour tour) {
        this.tour = tour;
    }

    
//все туры
public List<Tour> getAllTours(){
    return tourFacade.findAll();
}

//добавить тур
public String addTour(){
    tourFacade.create(tour);
    return "/faces/user/tours.xhtml";
}


//получить тур
public String toEdit(Long id){
    tour = tourFacade.find(id);
    return "/faces/user/showTour.xhtml";
}

//редактировать тур
public String editThis(){
    tourFacade.edit(tour);
    return "/faces/user/tours.xhtml";
}

public String deleteTour(Long id){
    tour = tourFacade.find(id);
    tourFacade.remove(tour);
    return "/faces/user/tours.xhtml";
}

   
}
