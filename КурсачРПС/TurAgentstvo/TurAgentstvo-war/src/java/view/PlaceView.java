/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package view;

import dao.ContractFacadeLocal;
import dao.PlaceFacadeLocal;
import entity.Contract;
import entity.Place;
import entity.Tour;
import java.io.Serializable;
import java.util.List;
import javax.ejb.EJB;
import javax.enterprise.context.RequestScoped;
import javax.enterprise.context.SessionScoped;
import javax.inject.Named;

/**
 *
 * @author fours
 */
@Named
@SessionScoped
public class PlaceView implements Serializable {
    //инъекция
    @EJB
    private PlaceFacadeLocal placeFacade;

    public PlaceView() {
        this.place = new Place();
    }
    
    

    private Place place;

    public Place getPlace() {
        return place;
    }

    public void setPlace(Place place) {
        this.place = place;
        
    }

    //просмотр всех мест
    public List<Place> getAllPlaces() {
        return placeFacade.findAll();
    }
     
    public String editThis() {
        return "/user/places.xhtml";
    }

    //добавить место
    public String addPlace() {
        this.placeFacade.create(place);
        return "places.xthml";
    }
    
    
    //смотрим туры по месту
    public List<Tour> getPlaceTours(Long idPlace){
        return placeFacade.getPlaceTours(idPlace);
    }

    //смотрим туры по месту
    public String goToPlaceTours(Long idPlace){
       place = placeFacade.find(idPlace);
       return "placetours.xhtml";
    }
    
    //удаляем
    public String delete(Long id){
        place = placeFacade.find(id);
        placeFacade.remove(place);
        return "places.xhtml?faces-redirect=true";
    }
    
}
