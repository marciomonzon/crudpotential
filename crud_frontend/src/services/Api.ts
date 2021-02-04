import axios from 'axios';

const api = axios.create({
    baseURL: "http://localhost:59607"
})

export default api