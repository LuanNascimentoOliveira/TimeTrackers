import axios from 'axios';

const API_URL = import.meta.env.VITE_API_URL

const ApiService = async (timeEntry) => {
    try {

        const response = await axios.post(`${API_URL}`, timeEntry);

        return response.status;

    } catch (error) {

        return error.status;
    }
}

export default ApiService;