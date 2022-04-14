<template>
  <div>
      <table>
          <thead>Gym Members: </thead>
          <tbody>
              <tr v-for="user in userList" v-bind:key="user.username">
                  <td>{{user.username}}: <router-link v-bind:to="{name: 'workouts', params: {userId: user.userId}}">View Details</router-link>
                  <button v-show="user.checkedIn != 'true'" v-on:click="employeeStartWorkout(user)">Check-in</button>
                  <button v-show="user.checkedIn == 'true'" v-on:click="employeeEndWorkout(user)">Check-out</button>
                  </td>
                  
              </tr>
          </tbody>
      </table>
  </div>
</template>

<script>
import WorkoutService from '@/services/WorkoutService'
import EmployeeService from '@/services/EmployeeService'

export default {
    name: "UserDisplay",
    props: {userList: Array},

    methods: {
        employeeStartWorkout(user) {
        WorkoutService.addDailyWorkout(user.userId).then((response) => {
            if(response.status === 200) {
                user.checkedIn = "true";
            }
        })
    },
    employeeEndWorkout(user) {
        EmployeeService.employeeEndWorkout(user.userId).then((response) => {
            if (response.status ===200) {
                user.checkedIn = "false";
            }
        })
    }
    }

    
}
</script>

<style>
</style>