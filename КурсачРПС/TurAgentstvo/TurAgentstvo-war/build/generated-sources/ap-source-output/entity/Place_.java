package entity;

import entity.Tour;
import javax.annotation.Generated;
import javax.persistence.metamodel.ListAttribute;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;

@Generated(value="EclipseLink-2.5.2.v20140319-rNA", date="2016-05-10T18:37:05")
@StaticMetamodel(Place.class)
public class Place_ { 

    public static volatile SingularAttribute<Place, String> country;
    public static volatile SingularAttribute<Place, String> city;
    public static volatile SingularAttribute<Place, String> hotel;
    public static volatile SingularAttribute<Place, Long> id;
    public static volatile ListAttribute<Place, Tour> tours;
    public static volatile SingularAttribute<Place, Integer> hotelStars;

}