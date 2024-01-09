using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BOL;
using SAL;

namespace Controllers;

public class EmpController : Controller
{
   private readonly IEmpService empService;

    public EmpController(IEmpService empService)
    {
        this.empService=empService;
    }

    public IActionResult Index()
    {
        List<Employee> empList=empService.GetAll();
        ViewData["employees"]=empList;
        return View();
    }

    [HttpGet]
    public IActionResult AddEmp(){
        return View();
    }
    
    [HttpPost]
    public IActionResult CreateEmp(int Id,string Name,int noHrs,double BasicSal,int Tax,string Dept,double DA,int EType,DateTime JoiningDate){
        Employee e=new Employee(Id,Name,noHrs,BasicSal,Tax,Dept,DA,(EmpType)EType,JoiningDate);
        empService.AddEmp(e);
        return RedirectToAction("Index","Emp",null);

    }
    [HttpGet]
    public IActionResult UpdateForm(int Id){
        // ViewData["EmpId"]=Id;
        List<Employee> empList=empService.GetAll();
        var emp=empList.Find((e)=>e.Id==Id);
        return View(emp);
    }

    [HttpPost]
    public IActionResult UpdateEmp(int Id,string Name,int noHrs,double BasicSal,int Tax,string Dept,double DA,int EType,DateTime JoiningDate){
        Console.WriteLine("--->",Id);
        Console.WriteLine("--->",Name);
        Employee e=empService.GetById(Id);
        Console.WriteLine(e);
        e.Name = Name;
        e.NoOfHrsWorked = noHrs;
        e.BasicSal = BasicSal;
        e.Tax = Tax;
        e.Dept = Dept;
        e.DA = DA;
        e.EType = (EmpType)EType;
        e.JoiningDate = JoiningDate;
        empService.UpdateEmp(Id,e);
        return RedirectToAction("Index","Emp",null);

    }

    [HttpGet]
    public IActionResult DelEmp(int Id){
        empService.DelEmp(Id);
        return RedirectToAction("Index","Emp",null);
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
