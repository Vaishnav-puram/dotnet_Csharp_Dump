namespace Service;
using System.Collections.Generic;
using Emp;
using Repo;
using CustomExceptions;

public class EmpServiceImpl : EmpService
{
    EmpRepo empRepo = new EmpRepo();
    string filename = @"..\EmpFile\EmpData.json";
    public List<Employee> GetAll()
    {
        
        List<Employee> empList = new List<Employee>();
        empList = empRepo.DeSerialize(filename);
        return empList;
    }
    public void AddEmp(List<Employee> empList)
    {
        empRepo.Serialize(empList, filename);
    }

    public Employee GetById(int id){
        List<Employee> emps=empRepo.DeSerialize(filename);
        foreach(Employee emp in emps){
            if(emp.Id==id){
                return emp;
            }
        }
       throw new ResourceNotFoundException("Unable to find the employee with given id !");

    }
    public void DelEmp(int id){
        List<Employee> emps=empRepo.DeSerialize(filename);
        foreach(Employee emp in emps){
            if(emp.Id==id){
                emps.Remove(emp);
                break;
            }
        }
        empRepo.Serialize(emps,filename);
    }
    public void UpdateEmp(int id,Employee newEmp){
        Employee emp=GetById(id);
        emp.Id=newEmp.Id;
        emp.Name=newEmp.Name;
        emp.Dept=newEmp.Dept;
        emp.NoOfHrsWorked=newEmp.NoOfHrsWorked;
        emp.JoiningDate=newEmp.JoiningDate;
        emp.EType=newEmp.EType;
        emp.BasicSal=newEmp.BasicSal;
        emp.Tax=newEmp.Tax;
        emp.DA=newEmp.DA;
        DelEmp(id);
        List<Employee> empList=GetAll();
        empList.Add(emp);
        AddEmp(empList);
    }
}