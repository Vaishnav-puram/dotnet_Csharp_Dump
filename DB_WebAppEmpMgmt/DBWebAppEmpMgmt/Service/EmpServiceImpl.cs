namespace Service;
using System.Collections.Generic;
using Models;
using Repo.ConnectedDataAccess;
using Repo.DisConnectedDataAccess;
using CustomExceptions;

public class EmpServiceImpl : EmpService
{
    EmpDBRepo empDBRepo=new EmpDBRepo();
    DisconnectedEmpDBRepo disEmpRepo=new DisconnectedEmpDBRepo();
    public List<Employee> GetAll()
    {
        
        List<Employee> empList = new List<Employee>();
        //empList=empDBRepo.GetAll();
        empList=disEmpRepo.GetAll();
        return empList;
    }

    public void AddEmp(Employee emp){
        //empDBRepo.AddEmp(emp);
        disEmpRepo.AddEmp(emp);
    }

    public Employee GetById(int id){
       // return empDBRepo.GetById(id);
       return disEmpRepo.GetById(id);
    }
    public void DelEmp(int id){
        //empDBRepo.DelEmp(id);
        disEmpRepo.DelEmp(id);
    }
    public void UpdateEmp(int id,Employee newEmp){
        disEmpRepo.UpdateEmp(id,newEmp);
    }
}