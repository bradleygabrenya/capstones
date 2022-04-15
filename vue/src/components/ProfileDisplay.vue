<template>
  <div>
      <table class="card">
          <thead></thead>
          <tbody>
              <img :src="this.$store.state.user.photo" alt="">
              <tr>
                  
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
          <button class = 'btn btn-primary' v-on:click="toggleShowForm()">Update Profile</button>
      </table>
      
      <form action="submit" v-show="showForm" v-on:submit="updateProfile()" class="card">
          <label for="email">Email: </label>
          <input type="email" id="email" name="email" v-model="user.email"><br>
          <label for="workoutProfile">Profile: </label>
          <textarea name="workoutProfile" id="workoutProfile" cols="30" rows="5"  v-model="user.workoutProfile"></textarea><br>
          <label for="userGoals">Goal: </label>
          <textarea name="userGoals" id="userGoals" cols="30" rows="5"  v-model="user.workoutGoals"></textarea><br>
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
        showForm: false
    }
},
methods: {
    updateProfile() {
        UserService.putUpdateProfile(this.user).then()
    },
    toggleShowForm() {
        this.showForm = true
    }
}
}
</script>

<style scoped>
.card{
    padding-left: 10%;
    padding-right: 10%;
    padding-top: 3%;
    padding-bottom: 3%;
}

.btn{  
    margin-bottom: 5px;
    margin-top: 5px;
    display: inline-block;
    align-self: end;
    width:35%;
}

img{
display: block;
margin:0 auto;
width: 200px;
border-radius: 5%;
}


textarea{
    vertical-align: top;
    width: 100%
}
</style>