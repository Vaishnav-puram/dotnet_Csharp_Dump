namespace Service;
using Emp;
public interface EmpService{
    public List<Employee> GetAll();
    public Employee GetById(int id);
    public void AddEmp(List<Employee> emp);
    public void DelEmp(int id);
    //public void UpdateEmp(int id,Employee emp);
}