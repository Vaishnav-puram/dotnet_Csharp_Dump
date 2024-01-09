namespace DAL;
using BOL;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

public class DisconnectedEmpDBRepo
{


    int Id;
    int NoOfHrsWorked;
    int Tax;
    double BasicSal;
    double DA;
    string Name;
    string Dept;
    EmpType EType;
    string JoiningDate;

    public List<Employee> GetAll()
    {
        List<Employee> elist = new List<Employee>();
        MySqlConnection conn = new MySqlConnection();
        string myConnectionString = "server=localhost;port=3306;user=root;password=Vaishv@123;database=emp";
        conn.ConnectionString = myConnectionString;
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "select * From employee";
        DataSet ds = new DataSet();
        MySqlDataAdapter da = new MySqlDataAdapter();
        da.SelectCommand = cmd;
        da.Fill(ds);
        DataTable dt = ds.Tables[0];
        DataRowCollection empRows = dt.Rows;
        foreach (DataRow reader in empRows)
        {
            Id = Int32.Parse(reader["Id"].ToString());
            NoOfHrsWorked = Int32.Parse(reader["NoOfHrsWorked"].ToString());
            Tax = Int32.Parse(reader["Tax"].ToString());
            BasicSal = Double.Parse(reader["BasicSal"].ToString());
            DA = Double.Parse(reader["DA"].ToString());
            Name = reader["Name"].ToString();
            Dept = reader["Dept"].ToString();
            //EType=reader["EType"].ToString();
            Enum.TryParse(reader["EType"].ToString(), out EType);
            JoiningDate = reader["JoiningDate"].ToString();
            Employee emp = new Employee(Id, Name, NoOfHrsWorked, BasicSal, Tax, Dept, DA, (EmpType)EType, DateTime.Parse(JoiningDate));
            elist.Add(emp);
        }

        return elist;
    }
    public Employee GetById(int Id)
    {
        Employee emp = new Employee();
        MySqlConnection conn = new MySqlConnection();
        string myConnectionString = "server=localhost;port=3306;user=root;password=Vaishv@123;database=emp";
        conn.ConnectionString = myConnectionString;
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = $"select * from employee where Id={Id}";

        DataSet ds = new DataSet();
        MySqlDataAdapter da = new MySqlDataAdapter();
        da.SelectCommand = cmd;
        da.Fill(ds);
        DataTable dt = ds.Tables[0];
        DataRowCollection empRows = dt.Rows;
        DataRow row = empRows[0];

        Id = Int32.Parse(row["Id"].ToString());
        NoOfHrsWorked = Int32.Parse(row["NoOfHrsWorked"].ToString());
        Tax = Int32.Parse(row["Tax"].ToString());
        BasicSal = Double.Parse(row["BasicSal"].ToString());
        DA = Double.Parse(row["DA"].ToString());
        Name = row["Name"].ToString();
        Dept = row["Dept"].ToString();
        //EType=reader["EType"].ToString();
        Enum.TryParse(row["EType"].ToString(), out EType);
        JoiningDate = row["JoiningDate"].ToString();
        emp = new Employee(Id, Name, NoOfHrsWorked, BasicSal, Tax, Dept, DA, (EmpType)EType, DateTime.Parse(JoiningDate));
        return emp;
    }

    public void AddEmp(Employee emp)
    {
        MySqlConnection conn = new MySqlConnection();
        string myConnectionString = "server=localhost;port=3306;user=root;password=Vaishv@123;database=emp";
        conn.ConnectionString = myConnectionString;
        DataSet ds = new DataSet();
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = $"select * from employee";
        da.SelectCommand = cmd;
        da.Fill(ds);
        DataTable dt = ds.Tables[0];
        DataRow dr = dt.NewRow();
        dr["Id"] = emp.Id;
        dr["Name"] = emp.Name;
        dr["NoOfHrsWorked"] = emp.NoOfHrsWorked;
        dr["DA"] = emp.DA;
        dr["BasicSal"] = emp.BasicSal;
        dr["Tax"] = emp.Tax;
        dr["Dept"] = emp.Dept;
        dr["EType"] = (int)emp.EType;
        dr["JoiningDate"] = emp.JoiningDate.ToString("yyyy-MM-dd");
        dt.Rows.Add(dr);
        MySqlCommandBuilder builder = new MySqlCommandBuilder(da);
        da.Update(ds);
    }
    public void DelEmp(int Id)
    {
        MySqlConnection conn = new MySqlConnection();
        string myConnectionString = "server=localhost;port=3306;user=root;password=Vaishv@123;database=emp";
        conn.ConnectionString = myConnectionString;
        DataSet ds = new DataSet();
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = $"select * from employee";
        da.SelectCommand=cmd;
        da.Fill(ds);
        DataTable dt=ds.Tables[0];
        DataRow [] rows=dt.Select($"Id={Id}");
        DataRow row=rows[0];
        row.Delete();
    
        MySqlCommandBuilder builder = new MySqlCommandBuilder(da);
        da.Update(ds);
    }
    public void UpdateEmp(int Id, Employee emp)
    {
        MySqlConnection conn = new MySqlConnection();
        string myConnectionString = "server=localhost;port=3306;user=root;password=Vaishv@123;database=emp";
        conn.ConnectionString = myConnectionString;
        DataSet ds = new DataSet();
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = $"select * from employee";
        da.SelectCommand=cmd;
        da.Fill(ds);
        DataTable dt=ds.Tables[0];
        DataRow [] rows=dt.Select($"Id={Id}");
        DataRow row=rows[0];
        row["Name"] = emp.Name;
        row["NoOfHrsWorked"] = emp.NoOfHrsWorked;
        row["DA"] = emp.DA;
        row["BasicSal"] = emp.BasicSal;
        row["Tax"] = emp.Tax;
        row["Dept"] = emp.Dept;
        row["EType"] = (int)emp.EType;
        row["JoiningDate"] = emp.JoiningDate.ToString("yyyy-MM-dd");
        MySqlCommandBuilder builder = new MySqlCommandBuilder(da);
        da.Update(ds);  
    }
}