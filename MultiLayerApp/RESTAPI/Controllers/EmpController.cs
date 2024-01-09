using BOL;
using Microsoft.AspNetCore.Mvc;
using SAL;
namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpController:ControllerBase{
    private readonly IEmpService empService;
    public EmpController(IEmpService empService){
        Console.WriteLine("EmpController invoked...");
        this.empService=empService;
    }

    [HttpGet]
    public ActionResult<List<Employee>> GetAll(){
        return empService.GetAll();
    }
    
    [HttpPost]
    public void AddEmp(Employee employee){
        empService.AddEmp(employee);
    }

    [HttpGet("{Id}")]
    public ActionResult<Employee> GetById(int Id){
        return empService.GetById(Id);
    }

    [HttpPut("{Id}")]
    public void UpdateEmp(int Id,Employee employee){
        empService.UpdateEmp(Id,employee);
    }
    [HttpDelete("{Id}")]
    public void DelEmp(int Id){
        empService.DelEmp(Id);
    }
}