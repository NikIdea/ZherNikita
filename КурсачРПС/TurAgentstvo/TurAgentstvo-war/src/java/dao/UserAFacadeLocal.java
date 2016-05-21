/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dao;

import entity.UserA;
import java.util.List;
import javax.ejb.Local;

/**
 *
 * @author fours
 */
@Local
public interface UserAFacadeLocal {

    void create(UserA userA);

    void edit(UserA userA);

    void remove(UserA userA);

    UserA find(Object id);

    List<UserA> findAll();

    List<UserA> findRange(int[] range);

    int count();
    
}
