import { NavLink,useNavigate  } from "react-router-dom";
import React,{ useEffect, useState } from "react";
import { GetAll,DelEmp } from "./RESTService";
function Home() {
    const navigate=useNavigate();
    let [employees, setEmployees] = useState([]);
    useEffect(() => {
        GetAll()
            .then((res) => {
                console.log(res);
                setEmployees(res.data);
            })
            .catch((error) => {
                console.log(error);
            })
    }, [employees])
    const handleDelete=(e,id)=>{
        e.preventDefault();
        console.log("current id to be deleted ==>",id)
        DelEmp(id)
        .then((res)=>{
            console.log(res.data);
            navigate("/")
        })
        .catch((error)=>{
            console.log(error)
        })
    }
    return (
        <>
            <div style={{display:'flex',justifyContent:'center',alignContent:'center'}}>
            <h3>Welcome to Employee Management</h3>
            <h3><NavLink to={'/addEmp'}>AddEmployee</NavLink></h3>
            </div>
            <br/>
            
            <div>
                <table border={'2px'} style={{ textAlign: 'center' }}>
                    <tr>
                        <th>EmpId</th>
                        <th>Name</th>
                        <th>NoOfHrsWorked</th>
                        <th>BasicSal</th>
                        <th>Tax</th>
                        <th>Department</th>
                        <th>DA</th>
                        <th>EmpType</th>
                        <th>JoiningDate</th>
                        <th>Salary</th>
                        <th colSpan={2} style={{ color: 'red' }}>Actions</th>
                    </tr>
                    {employees.map((emp) => (
                        <tr key={emp.Id}>
                            <td>{emp.Name}</td>
                            <td>{emp.NoOfHrsWorked}</td>
                            <td>{emp.BasicSal}</td>
                            <td>{emp.Tax}</td>
                            <td>{emp.Dept}</td>
                            <td>{emp.DA}</td>
                            <td>{emp.EType}</td>
                            <td>{emp.JoiningDate}</td>
                            <td>{emp.computeSal()}</td>
                            <td><NavLink to={`/edit/${emp.Id}`}><button>Update</button></NavLink></td>
                            <td><button onClick={(e)=>handleDelete(e,`${emp.Id}`)}>Delete</button></td>
                        </tr>
                    ))}
                </table>
            </div>
        </>
    )
}
export default Home;