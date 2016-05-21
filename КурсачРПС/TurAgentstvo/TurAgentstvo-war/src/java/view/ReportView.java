/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package view;

import dao.ContractFacadeLocal;
import dao.ReportFacadeLocal;
import entity.Contract;
import entity.Report;
import java.io.Serializable;
import java.util.List;
import javax.ejb.EJB;
import javax.enterprise.context.SessionScoped;
import javax.inject.Named;

/**
 *
 * @author fours
 */
@Named
@SessionScoped
public class ReportView implements Serializable{
@EJB
private ReportFacadeLocal reportFacade;

public ReportView(){
    this.report = new Report();
}

private Report report;


//список всех отчетов
public List<Report> getAllReports(){
    return reportFacade.findAll();
}

public String editThis(){
    return "/reports/reports.xhtml";
}

  
}
