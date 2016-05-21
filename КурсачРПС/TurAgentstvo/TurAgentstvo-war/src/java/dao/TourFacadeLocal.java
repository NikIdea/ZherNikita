/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dao;

import entity.Tour;
import java.util.List;
import javax.ejb.Local;

/**
 *
 * @author fours
 */
@Local
public interface TourFacadeLocal {
    
    void del(Tour tour);

    void create(Tour tour);

    void edit(Tour tour);

    void remove(Tour tour);

    Tour find(Object id);

    List<Tour> findAll();

    List<Tour> findRange(int[] range);

    int count();
    
}
