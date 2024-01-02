namespace Service;
using System.Collections.Generic;
using Emp;
using Repo;

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
       return null;

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
    // public void UpdateEmp(int id,Employee newEmp){
    //     Employee emp=this.GetById(id);
    // }
}