<template>
  <div>
      <table>
          <thead>Gym Members: </thead>
          <tbody>
              <tr v-for="user in userList" v-bind:key="user.username">
                  <td>{{user.username}}: <router-link v-bind:to="{name: 'workouts', params: {userId: user.userId}}">View Details</router-link>
                  <button v-if="user.checkedIn != 'true'">Check-in</button>
                  <button v-if="user.checkedIn == 'true'">Check-out</button>
                  </td>
                  
              </tr>
          </tbody>
      </table>
  </div>
</template>

<script>

export default {
    name: "UserDisplay",
    props: {userList: Array},
    data() {
        return {
            checkedIn: false,
        }
    }

    
}
</script>

<style>
</style>