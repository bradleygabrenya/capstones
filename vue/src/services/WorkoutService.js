import axios from 'axios';

const path = '/workouts'

export default {

    getWorkouts(userId) {
        return axios.get(path + '/' + userId)
    },

}