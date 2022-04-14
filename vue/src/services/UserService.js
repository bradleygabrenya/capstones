import axios from 'axios';

export default {
    putUpdateProfile(user) {
        axios.put('/profile/user', user)
    }
}

