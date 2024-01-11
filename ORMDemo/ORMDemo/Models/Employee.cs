using System.ComponentModel.DataAnnotations;

namespace Models;
[Serializable]
public class Employee
{
    public int Id { get; set; }
    [Required(ErrorMessage ="Name is Required!")]
    public string Name { get; set; }
    public int NoOfHrsWorked { get; set; }
    public double DA { get; set; }
    public double BasicSal { get; set; }
    public int Tax { get; set; }
    public string Dept { get; set; }

    public EmpType EType { get; set; }
    public DateTime JoiningDate { get; set; }

    public Employee(){}

    public Employee(int Id, string Name, int NoOfHrsWorked, double BasicSal, int Tax, string Dept, double DA, EmpType EType, DateTime JoiningDate)
    {
        this.Id = Id;
        this.Name = Name;
        this.NoOfHrsWorked = NoOfHrsWorked;
        this.BasicSal = BasicSal;
        this.Tax = Tax;
        this.Dept = Dept;
        this.DA = DA;
        this.EType = EType;
        this.JoiningDate = JoiningDate;
    }
    public double computeSal()
    {
        double finalSal;
        int T = this.Tax / 100;
        finalSal = this.BasicSal + (this.NoOfHrsWorked * this.DA) - T;
        return finalSal;
    }
    public override string ToString()
    {
        return this.Id + " " + this.Name + " " + this.EType + " " + this.NoOfHrsWorked + " " + this.BasicSal + " " + this.JoiningDate + " " + this.Tax + " " + this.Dept;
    }
}