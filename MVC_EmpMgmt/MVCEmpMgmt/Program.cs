using System;
using Controller;
using Service;
using Emp;
using Views;

EmpService empService=new EmpServiceImpl();
EmpController empController=new EmpController(empService);
List<Employee> emplist=empController.GetAll();
ViewImpl viewImpl;
int ID,NoOfHrsWorked,Tax,EType;
string Name,Dept,JD;
double BasicSal,DA;
int Choice;
Employee e;

do{
    Console.WriteLine("1.Add new Employee to company");
    Console.WriteLine("2.Get all Employees");
    Console.WriteLine("3.Get Employee by ID");
    Console.WriteLine("4.Delete Employee by ID");
    Console.WriteLine("7.Exit");
    Choice=Convert.ToInt32(Console.ReadLine());
    switch(Choice){
        case 1:
             Console.WriteLine("Enter Employee id : ");
            ID=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee name : ");
            Name=Console.ReadLine();
            Console.WriteLine("Enter basic salary : ");
            BasicSal=Convert.ToDouble(Console.ReadLine()); 
            Console.WriteLine("Enter Daily Allowance : ");
            DA=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter no.of hrs worked : ");
            NoOfHrsWorked=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter tax percentage");
            Tax=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Department name :");
            Dept=Console.ReadLine();
            Console.WriteLine("Enter Joining Date : ");
            JD=Console.ReadLine();
            Console.WriteLine("Enter Employment type : Options [0.FULL_TIME  1.PART_TIME   2.INTERN   3.CONTRACT]");
            EType=Convert.ToInt32(Console.ReadLine());
            e=new Employee(ID,Name,NoOfHrsWorked,BasicSal,Tax,Dept,DA,(EmpType)EType,DateTime.Parse(JD));
            emplist.Add(e);
            break;
        case 2:
            List<Employee> emps=empController.GetAll();
            viewImpl=new ViewImpl(emps);
            viewImpl.RenderList();
            break;
        case 3:
            Console.WriteLine("Enter employee id : ");
            ID=Convert.ToInt32(Console.ReadLine());
            Employee emp=empController.GetById(ID);
            viewImpl=new ViewImpl(emp);
            viewImpl.RenderEmp();
            break;
        case 4 :
            Console.WriteLine("Enter employee id : ");
            ID=Convert.ToInt32(Console.ReadLine());
            empController.DelEmp(ID);
            emplist=empController.GetAll();
            break;
        case 7:
            empController.AddEmp(emplist);
            Console.WriteLine("Qutting...");
            break;
    }
}while(Choice!=7);