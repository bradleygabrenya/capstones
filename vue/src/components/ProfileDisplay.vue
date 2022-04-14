<template>
  <div>
      <table>
          <thead></thead>
          <tbody>
              <tr>
                  <td><img :src="this.$store.state.user.photo" alt=""></td>
              </tr>
              <tr>
                  <td>Username: </td>
                  <td>{{this.$store.state.user.username}}</td>
              </tr>
              <tr>
                  <td>Email: </td>
                  <td>{{this.$store.state.user.email}}</td>
              </tr>
              <tr>
                  <td>User Goals: </td>
                  <td>{{this.$store.state.user.workoutGoals}}</td>
              </tr>
              <tr>
                  <td>Workout Profile: </td>
                  <td>{{this.$store.state.user.workoutProfile}}</td>
              </tr>
          </tbody>
      </table>
      <button class = 'btn btn-primary'>Update Profile</button>
      <form action="submit" v-on:submit="updateProfile()">
          <label for="email">Email: </label>
          <input type="email" id="email" name="email" v-model="user.email"><br>
          <label for="workoutProfile">Profile: </label>
          <textarea name="workoutProfile" id="workoutProfile" cols="30" rows="10"  v-model="user.workoutProfile"></textarea><br>
          <label for="userGoals">Goal: </label>
          <textarea name="userGoals" id="userGoals" cols="30" rows="10"  v-model="user.workoutGoals"></textarea><br>
          <label for="photo">Photo: </label>
          <input type="text" id="photo" name="photo" v-model="user.photo"><br>
          <button type='submit'>Submit</button>
      </form>
  </div>
</template>

<script>
import UserService from '@/services/UserService'
export default {
data() {
    return {
        user: this.$store.state.user,
        
    }
},
methods: {
    updateProfile() {
        UserService.putUpdateProfile(this.user).then()
    }
}
}
</script>

<style>
img{
width: 200px;

}
</style>