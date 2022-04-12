import axios from 'axios';

const path = '/workoutdetails'

export default {

    getWorkoutDetails(workoutId) {
        return axios.get(path + '/' + workoutId)
    },

    postUseTracking(useTracking) {
        return axios.post(path + '/' + useTracking.workoutId)
    }
}
