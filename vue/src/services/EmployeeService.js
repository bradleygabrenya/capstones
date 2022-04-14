import axios from 'axios'

export default {
    employeeEndWorkout(userId) {
        return axios.put('/employeeCheckout/' + userId)
    }
}

