using BOL;
using DAL;

public class BIManager{
    DisconnectedEmpDBRepo empDBRepo=new DisconnectedEmpDBRepo();
    public List<Employee> GetAll(){
        return empDBRepo.GetAll();
    }
    public Employee GetById(int Id){
        return empDBRepo.GetById(Id);
    }
    public void AddEmp(Employee emp){
        empDBRepo.AddEmp(emp);
    }
    public void UpdateEmp(int Id,Employee emp){
        empDBRepo.UpdateEmp(Id,emp);
    }
    public void DelEmp(int Id){
        empDBRepo.DelEmp(Id);
    }
}