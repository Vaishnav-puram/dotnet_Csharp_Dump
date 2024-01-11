namespace Service;
using Repo;
using Models;

public class EmpService:IEmpService{
    private readonly EmpDbContext _dbContext;
    public EmpService(EmpDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    public List<Employee> GetAll(){
        // List<Employee>elist=new List<Employee>();
        return _dbContext.Employee.ToList();
    }
    public void AddEmp(Employee emp){
        _dbContext.Employee.Add(emp);
        _dbContext.SaveChanges();
    }
    public Employee GetById(int Id){
        return _dbContext.Employee.Find(Id);
    }
    public void UpdateEmp(Employee employee){
        Console.WriteLine("---->",employee);
        Employee? emp=_dbContext.Employee.Find(employee.Id);
        emp.Name=employee.Name;
        emp.Dept=employee.Dept;
        emp.NoOfHrsWorked=employee.NoOfHrsWorked;
        emp.BasicSal=employee.BasicSal;
        emp.DA=employee.DA;
        emp.Tax=employee.Tax;
        emp.EType=employee.EType;
        emp.JoiningDate=employee.JoiningDate;
        Console.WriteLine(emp);
        _dbContext.SaveChanges();
    }
    public void DelEmp(int Id){
        Employee? emp=_dbContext.Employee.Find(Id);
        _dbContext.Employee.Remove(emp);
        _dbContext.SaveChanges();
    }
}