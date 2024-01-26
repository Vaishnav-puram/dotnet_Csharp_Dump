using C_Basics.ExtenstionMethodsDemo;
using C_Basics.PartialDemo;
using C_Basics.SealedDemo;

var obj = new { Name = "Vaishnav", age = 23 };
Console.WriteLine("**************Anonymous Types****************** ");
Console.WriteLine("Name : {0} Age : {1} ", obj.Name, obj.age);

var objArr = new[]
{
    new
    {
        Name = "Vaishnav", age = 23
    },
    new
    {
         Name = "Rajat", age = 22
    }
};
foreach(var ele in objArr)
{
    Console.WriteLine("Name : {0} Age : {1} ", ele.Name, ele.age);
}

Console.WriteLine("********Partial Classes**********");
PartialEmp emp = new PartialEmp()
{
    FirstName = "Pranaya",
    LastName = "Rout",
    Salary = 100000,
    Gender = "Male"
};
emp.DisplayFullName();
emp.DisplayEmployeeDetails();

Console.WriteLine("********Sealed Classes**********");

Manager m1 = new Manager();
m1.GetEmployeeData();
m1.DisplayEmployeeData();

Console.WriteLine("********Extenstion Methods**********");
OldClass obj1 = new OldClass();
obj1.Test1();
obj1.Test2();
//Calling Extension Methods
obj1.Test3();
obj1.Test4(10);
obj1.Test5();


void AddNums(int a, int b, int[] ?restOfNums=null)
{
    int result = a + b;
    foreach(int ele in restOfNums)
    {
        result += ele;
    }
    Console.WriteLine("Sum is : " + result);
}

AddNums(10, 20, new int[] { 30, 40, 50 });


