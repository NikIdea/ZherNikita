package entity;

import entity.Place;
import java.util.Date;
import javax.annotation.Generated;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;

@Generated(value="EclipseLink-2.5.2.v20140319-rNA", date="2016-05-10T18:37:05")
@StaticMetamodel(Tour.class)
public class Tour_ { 

    public static volatile SingularAttribute<Tour, Integer> quantity;
    public static volatile SingularAttribute<Tour, Date> endDate;
    public static volatile SingularAttribute<Tour, Integer> Price;
    public static volatile SingularAttribute<Tour, String> nameTour;
    public static volatile SingularAttribute<Tour, Long> id;
    public static volatile SingularAttribute<Tour, Place> place;
    public static volatile SingularAttribute<Tour, Date> startDate;

}