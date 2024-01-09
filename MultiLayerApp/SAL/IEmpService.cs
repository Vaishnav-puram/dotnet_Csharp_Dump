using BOL;
namespace SAL;

public interface IEmpService{
    public List<Employee> GetAll();
    public Employee GetById(int Id);
    public void AddEmp(Employee employee);
    public void UpdateEmp(int Id,Employee employee);
    public void DelEmp(int Id);
}