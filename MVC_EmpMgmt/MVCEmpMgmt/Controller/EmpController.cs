namespace Controller;
using Service;
using Emp;
public class EmpController{
    private EmpService empService;

    public EmpController(EmpService empService){
        this.empService=empService;
    }

    public Employee GetById(int id){
        return empService.GetById(id);
    }

    public List<Employee> GetAll(){
        return empService.GetAll();
    }
    public void AddEmp(List<Employee> empList){
        empService.AddEmp(empList);
    }

    public void DelEmp(int id){
        empService.DelEmp(id);
    }
}