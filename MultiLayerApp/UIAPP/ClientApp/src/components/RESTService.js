import { axiosService } from "../Helper";
export const GetAll=()=>{
    return axiosService.get('/api/Emp');
}

export const AddEmp=(empData)=>{
    return axiosService.post('/api/Emp',empData);
}

export const DelEmp=(Id)=>{
    return axiosService.delete(`/api/Emp/${Id}`);
}

export const UpdateEmp=(Id,empData)=>{
    return axiosService.post(`/api/Emp/${Id}`,empData);
}