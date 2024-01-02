using System.Collections.Generic;
using Emp;

//Employee e=new Employee(123,"vijay",10,2300,15,"HR");
// Console.WriteLine(e);
int ID,NoOfHrsWorked,Tax,EType;
string Name,Dept,JD;
double BasicSal,DA;
int Choice;
Employee e;
List<Employee> emplist=new List<Employee>();
do{
    Console.WriteLine("1.Show all Employee list");
    Console.WriteLine("2.Show Employee details by ID");
    Console.WriteLine("3.Add new Employee to company");
    Console.WriteLine("4.Remove Employee from Company by ID");
    Console.WriteLine("5.Calculate salary for given Employee");
    Console.WriteLine("6.Show all Employees with their name and salary in list");
    Console.WriteLine("7.Exit");
    Choice=Convert.ToInt32(Console.ReadLine());
    switch(Choice){
        case 1:
            if(!emplist.Any()){
                Console.WriteLine("No Employees available !");
            }else{
            foreach(Employee emp in emplist){
                Console.WriteLine(emp);
            }
            }
            break;
        case 2:
            Console.WriteLine("Enter Employee ID : ");
            ID=Convert.ToInt32(Console.ReadLine());
            bool flag=false;
            foreach(Employee emp in emplist){
                if(emp.Id==ID){
                    flag=true;
                    Console.WriteLine(emp);
                    break;
                }
            }
            if(!flag){
                Console.WriteLine("Employee with the given ID is not found ");
            }
            break;
        case 3:
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
        case 4:
            Console.WriteLine("Enter Employee ID : ");
            ID=Convert.ToInt32(Console.ReadLine());
            flag=false;
            foreach(Employee emp in emplist){
                if(emp.Id==ID){
                    flag=true;
                    emplist.Remove(emp);
                    break;
                }
            }
            if(!flag){
                Console.WriteLine("Employee with the given ID is not found :");
            }
            break;
        case 5:
            Console.WriteLine("Enter Employee ID : ");
            ID=Convert.ToInt32(Console.ReadLine());
            flag=false;
            foreach(Employee emp in emplist){
                if(emp.Id==ID){
                    flag=true;
                    Console.WriteLine("Salary for the employee with id : "+emp.Id+" is : "+emp.computeSal());
                    break;
                }
            }
            if(!flag){
                Console.WriteLine("Employee with the given ID is not found :");
            }
            break;
        case 6:
            foreach(Employee emp in emplist){
               Console.WriteLine("Employee name :"+emp.Name+" ---> "+" Salary : "+ emp.computeSal());
            }
            break;
        case 7:
            Console.WriteLine("Qutting...");
            break;
    }
}while(Choice!=7);
