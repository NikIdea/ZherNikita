/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package converter;

import dao.PlaceFacadeLocal;
import dao.UserAFacadeLocal;
import entity.Place;
import entity.UserA;
import javax.annotation.ManagedBean;
import javax.ejb.EJB;
import javax.enterprise.context.RequestScoped;
import javax.faces.application.FacesMessage;
import javax.faces.component.UIComponent;
import javax.inject.Named;
import javax.faces.context.FacesContext;
import javax.faces.convert.Converter;
import javax.faces.convert.ConverterException;
import javax.xml.registry.infomodel.User;

/**
 *
 * @author fours
 */
@ManagedBean
@RequestScoped
@Named("userConverter")
public class UserConverter implements Converter{
    @EJB
    UserAFacadeLocal userFacade;

    @Override
    public Object getAsObject(FacesContext context, UIComponent component, String submittedValue) {
        if (submittedValue == null || submittedValue.isEmpty()) {
            return null;
        }

        try {
            return userFacade.find(Long.valueOf(submittedValue));
        } catch (NumberFormatException e) {
            throw new ConverterException(new FacesMessage(String.format("%s is not a valid User ID", submittedValue)), e);
        }
    }

    @Override
    public String getAsString(FacesContext context, UIComponent component, Object modelValue) {
        if (modelValue == null) {
            return "";
        }

        if (modelValue instanceof UserA) {
            return String.valueOf(((UserA) modelValue).getId());
        } else {
            throw new ConverterException(new FacesMessage(String.format("%s is not a valid user", modelValue)));
        }
    }
}
