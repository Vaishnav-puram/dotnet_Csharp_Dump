namespace Repo.ConnectedDataAccess;
using Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
public class EmpDBRepo{
   
    
    int Id;
    int NoOfHrsWorked;
    int Tax;
    double BasicSal;
    double DA;
    string Name;
    string Dept;
    EmpType EType;
    string JoiningDate;
    public List<Employee> GetAll(){
        List<Employee> elist=new List<Employee>();
        MySqlConnection conn=new MySqlConnection();
        string myConnectionString="server=localhost;port=3306;user=root;password=Vaishv@123;database=emp";
        conn.ConnectionString = myConnectionString;
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=conn;
        cmd.CommandText="select * From employee";
        try{
            conn.Open();
            MySqlDataReader reader=cmd.ExecuteReader();
            while (reader.Read())
            {
                 Id=Int32.Parse(reader["Id"].ToString());
                 NoOfHrsWorked=Int32.Parse(reader["NoOfHrsWorked"].ToString());
                 Tax=Int32.Parse(reader["Tax"].ToString());
                 BasicSal=Double.Parse(reader["BasicSal"].ToString());
                 DA=Double.Parse(reader["DA"].ToString());
                 Name=reader["Name"].ToString();
                 Dept=reader["Dept"].ToString();
                 //EType=reader["EType"].ToString();
                 Enum.TryParse(reader["EType"].ToString(),out EType);
                 JoiningDate=reader["JoiningDate"].ToString();
                Employee emp=new Employee(Id,Name,  NoOfHrsWorked,  BasicSal,  Tax,  Dept,  DA,(EmpType)EType,DateTime.Parse(JoiningDate));
                elist.Add(emp);
            }
        }catch(Exception ex){
            Console.WriteLine(ex.Message);
        }finally{
            conn.Close();
        }
        return elist;
    }
    public Employee GetById(int Id){
        Employee emp=new Employee();
        MySqlConnection conn=new MySqlConnection();
        string myConnectionString="server=localhost;port=3306;user=root;password=Vaishv@123;database=emp";
        conn.ConnectionString = myConnectionString;
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=conn;
        cmd.CommandText=$"select * from employee where Id={Id}";
        try{
            conn.Open();
            MySqlDataReader reader=cmd.ExecuteReader();
            while (reader.Read())
            {
                 Id=Int32.Parse(reader["Id"].ToString());
                 NoOfHrsWorked=Int32.Parse(reader["NoOfHrsWorked"].ToString());
                 Tax=Int32.Parse(reader["Tax"].ToString());
                 BasicSal=Double.Parse(reader["BasicSal"].ToString());
                 DA=Double.Parse(reader["DA"].ToString());
                 Name=reader["Name"].ToString();
                 Dept=reader["Dept"].ToString();
                 //EType=reader["EType"].ToString();
                 Enum.TryParse(reader["EType"].ToString(),out EType);
                 JoiningDate=reader["JoiningDate"].ToString();
                 emp=new Employee(Id,Name,  NoOfHrsWorked,  BasicSal,  Tax,  Dept,  DA,(EmpType)EType,DateTime.Parse(JoiningDate));
            }
        }catch(Exception ex){
            Console.WriteLine(ex.Message);
        }finally{
            conn.Close();
        }
        return emp;
    }

    public void AddEmp(Employee emp){
        Id=emp.Id;
        Name=emp.Name;
        Dept=emp.Dept;
        DA=emp.DA;
        BasicSal=emp.BasicSal;
        Tax=emp.Tax;
        DateTime JDate=emp.JoiningDate;
        JoiningDate=JDate.ToString("yyyy-MM-dd");
        NoOfHrsWorked=emp.NoOfHrsWorked;
        EType=emp.EType;
        int Etype=(int)EType;
        MySqlConnection conn=new MySqlConnection();
        string myConnectionString="server=localhost;port=3306;user=root;password=Vaishv@123;database=emp";
        conn.ConnectionString = myConnectionString;
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=conn;
        cmd.CommandText=$"insert into employee values({Id},'{Name}',{NoOfHrsWorked},{DA},{BasicSal},{Tax},'{Dept}',{Etype},'{JoiningDate}')";
        Console.WriteLine($"insert into employee values({Id},'{Name}',{NoOfHrsWorked},{DA},{BasicSal},{Tax},'{Dept}',{Etype},'{JoiningDate}')");
        try{
            conn.Open();
            cmd.ExecuteNonQuery();
        }catch(Exception ex){
            Console.WriteLine(ex.Message);
        }finally{
            conn.Close();
        }
    }
    public void DelEmp(int Id){
        MySqlConnection conn=new MySqlConnection();
        string myConnectionString="server=localhost;port=3306;user=root;password=Vaishv@123;database=emp";
        conn.ConnectionString = myConnectionString;
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=conn;
        cmd.CommandText=$"delete from employee where id={Id}";
        Console.WriteLine($"delete from employee where id={Id}");
        try{
            conn.Open();
            cmd.ExecuteNonQuery();
        }catch(Exception ex){
            Console.WriteLine(ex.Message);
        }finally{
            conn.Close();
        }
    }
    public void UpdateEmp(int Id,Employee emp){
        Id=emp.Id;
        Name=emp.Name;
        Dept=emp.Dept;
        DA=emp.DA;
        BasicSal=emp.BasicSal;
        Tax=emp.Tax;
        DateTime JDate=emp.JoiningDate;
        JoiningDate=JDate.ToString("yyyy-MM-dd");
        NoOfHrsWorked=emp.NoOfHrsWorked;
        EType=emp.EType;
        int Etype=(int)EType;
        MySqlConnection conn=new MySqlConnection();
        string myConnectionString="server=localhost;port=3306;user=root;password=root123;database=Emp";
        conn.ConnectionString = myConnectionString;
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=conn;
        cmd.CommandText=$"update employee set Name='{Name}',NoOfHrsWorked={NoOfHrsWorked},DA={DA},BasicSal={BasicSal},Tax={Tax},Dept='{Dept}',EType={Etype},JoiningDate='{JoiningDate}' where Id={Id}";
        Console.WriteLine($"update employee set Name='{Name}',NoOfHrsWorked={NoOfHrsWorked},DA={DA},BasicSal={BasicSal},Tax={Tax},Dept='{Dept}',EType={Etype},JoiningDate='{JoiningDate}' where Id={Id}");
        try{
            conn.Open();
            cmd.ExecuteNonQuery();
        }catch(Exception ex){
            Console.WriteLine(ex.Message);
        }finally{
            conn.Close();
        }
    }
}