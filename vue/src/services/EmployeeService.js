import axios from 'axios'

export default {
    employeeEndWorkout(userId) {
        return axios.put('/employeeCheckout/' + userId)
    },

    updateUserRole(user){
        return axios.put('/profile/admin', user)
    }
}



