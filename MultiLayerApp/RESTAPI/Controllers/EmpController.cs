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
        Console.WriteLine("------------>",empService.GetAll());
        return empService.GetAll();
    }
}