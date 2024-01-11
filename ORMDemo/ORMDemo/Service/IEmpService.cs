using Models;
namespace Service;

public interface IEmpService{
    public List<Employee> GetAll();
    public Employee GetById(int Id);
     public void AddEmp(Employee employee);
     public void UpdateEmp(Employee employee);
     public void DelEmp(int Id);
}