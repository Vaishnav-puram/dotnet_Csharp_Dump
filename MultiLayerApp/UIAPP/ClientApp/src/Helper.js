import axios from 'axios';
export const BASE_URL='http://localhost:5091';
export const axiosService=axios.create({
    baseURL:BASE_URL,
    Headers:{
        'Content-Type':'application/json'
    }
})
