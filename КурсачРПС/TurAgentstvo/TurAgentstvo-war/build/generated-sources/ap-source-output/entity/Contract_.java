package entity;

import entity.Tour;
import entity.UserA;
import javax.annotation.Generated;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;

@Generated(value="EclipseLink-2.5.2.v20140319-rNA", date="2016-05-10T18:37:05")
@StaticMetamodel(Contract.class)
public class Contract_ { 

    public static volatile SingularAttribute<Contract, Long> id;
    public static volatile SingularAttribute<Contract, UserA> user;
    public static volatile SingularAttribute<Contract, Tour> tour;
    public static volatile SingularAttribute<Contract, String> status;

}