namespace Service;
using Models;
public interface EmpService{
   public List<Employee> GetAll();
    public Employee GetById(int id);
    public void AddEmp(Employee emp);
    public void DelEmp(int id);
    public void UpdateEmp(int id,Employee emp);
}