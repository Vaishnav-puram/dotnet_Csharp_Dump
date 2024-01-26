using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Basics.SealedDemo
{
    public class Employee
    {
        protected int Eid, Eage;
        protected string Ename, Eaddress;
        public virtual void GetEmployeeData()
        {
            Console.WriteLine("Enter Emplpyee Details:");
            Console.Write("Enter Employee ID:");
            Eid = int.Parse(Console.ReadLine());
            Console.Write("Enter Employee Name:");
            Ename = Console.ReadLine();
            Console.Write("Enter Employee Address:");
            Eaddress = Console.ReadLine();
            Console.Write("Enter Employee Age:");
            Eage = int.Parse(Console.ReadLine());
        }
        public virtual void DisplayEmployeeData()
        {
            Console.WriteLine("\nEmplpyee Details Are:");
            Console.WriteLine($"Employee ID: {Eid}");
            Console.WriteLine($"Employee Name: {Ename}");
            Console.WriteLine($"Employee Address: {Eaddress}");
            Console.WriteLine($"Employee Age: {Eage}");
        }
    }
    public sealed class Manager : Employee
    {
        double Bonus, Salary;
        public override void GetEmployeeData()
        {
            Console.WriteLine("Enter Manager Details:");
            Console.Write("Enter Manager ID:");
            Eid = int.Parse(Console.ReadLine());
            Console.Write("Enter Manager Name:");
            Ename = Console.ReadLine();
            Console.Write("Enter Manager Salary:");
            Salary = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Manager Bonus:");
            Bonus = double.Parse(Console.ReadLine());
        }
        public override void DisplayEmployeeData()
        {
            Console.WriteLine("\nManager Details Are:");
            Console.WriteLine($"Manager ID: {Eid}");
            Console.WriteLine($"Manager Name: {Ename}");
            Console.WriteLine($"Manager Salary: {Salary}");
            Console.WriteLine($"Manager Bonus: {Bonus}");
        }
    }
}
