import axios from 'axios'

export default {
    getClasses() {
        return axios.get('/classes');
    }
}