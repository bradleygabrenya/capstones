import axios from 'axios';

export default {
    getUserMetrics(userId) {
        return axios.get('/usermetrics/' + userId);
    },

    getTotalUserMetrics(){
        return axios.get('/totalusermetrics');
    }
}

