import axios from 'axios'

export default {
    employeeEndWorkout(userId) {
        axios.put('/employeeCheckout/' + userId)
    }
}

