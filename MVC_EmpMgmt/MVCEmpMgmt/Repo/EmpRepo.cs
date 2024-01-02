namespace Repo;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Emp;
public class EmpRepo
{
    public void Serialize(List<Employee> empList, string filename)
    {
        var options = new JsonSerializerOptions { IncludeFields = true };
        var employeesJson = JsonSerializer.Serialize<List<Employee>>(empList, options);
        File.WriteAllText(filename, employeesJson);
    }
    public List<Employee> DeSerialize(string filename)
    {

        //Deserialize from JSON file
        string jsonString = File.ReadAllText(filename);
        List<Employee> jsonEmployees = JsonSerializer.Deserialize<List<Employee>>(jsonString);
        return jsonEmployees;
    }
}