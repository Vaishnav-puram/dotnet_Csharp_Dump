using System.Collections.Generic;
namespace Views;
using Emp;
public class ViewImpl:View{
    private List<Employee> empList;
    private Employee emp;
    public ViewImpl(List<Employee> empList){
        this.empList=empList;
    }
    public ViewImpl(Employee emp){
        this.emp=emp;
    }
    public void RenderList(){
        foreach(Employee emp in empList){
            Console.WriteLine(emp);
        }
    }
    public void RenderEmp(){
        Console.WriteLine(emp);
    }
}