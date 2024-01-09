using BOL;
using BLL;
using System.Collections.Generic;
namespace SAL;

public class EmpServiceImpl : IEmpService
{
    BIManager bIManager=new BIManager();
    public List<Employee> GetAll()
    {
       return bIManager.GetAll();
    }
    public void AddEmp(Employee employee)
    {
        bIManager.AddEmp(employee);
    }
    public Employee GetById(int Id)
    {
        return bIManager.GetById(Id);
    }
    
    public void DelEmp(int Id)
    {
        bIManager.DelEmp(Id);
    }

    public void UpdateEmp(int Id, Employee employee)
    {
        bIManager.UpdateEmp(Id,employee);
    }
}