import axios from 'axios';

export default {
    getUserMetrics(userId) {
        return axios.get('/usermetrics/' + userId);
    }
}