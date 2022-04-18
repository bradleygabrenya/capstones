<template>
  <div>
      <table class="card" v-show="!showForm">
          <thead></thead>
          <tbody class="container">
              <div class="pic">
                <img :src="this.$store.state.user.photo" alt="">
              </div>
              <div id="user-display">
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
              </div>
              <button class = 'btn btn-primary' v-on:click="toggleShowForm()">Update Profile</button>
          </tbody>
          
      </table>
      
      <form id="user-display-form" action="submit" v-show="showForm" v-on:submit.prevent="updateProfile()" class="card">
          <label for="email">Email: </label>
          <input type="email" id="email" name="email" v-model="user.email"><br>
          <label for="workoutProfile">Profile: </label>
          <textarea name="workoutProfile" id="workoutProfile" cols="30" rows="5"  v-model="user.workoutProfile"></textarea><br>
          <label for="userGoals">Goal: </label>
          <textarea name="userGoals" id="userGoals" cols="30" rows="5"  v-model="user.workoutGoals"></textarea><br>
          <label for="photo">Photo: </label>
          <input type="text" id="photo" name="photo" v-model="user.photo"><br>
          <button type='submit' v-on:click="toggleShowForm()">Submit</button>
          <button class="btn btn-danger" v-on:click="toggleShowForm()">Cancel</button>
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
        this.showForm = !this.showForm
    }
}
}
</script>

<style scoped>
.container{
    display: grid;
    grid-template-columns: 2fr 1fr;
    grid-template-areas: 
    "profile pic"
    "profile pic"
    "btn pic";
    grid-area: main-container;
}

#user-display{
    grid-area: profile;
}

.card{
    padding-left: 10%;
    padding-right: 10%;
    padding-top: 3%;
    padding-bottom: 3%;
}

.btn-primary{
    grid-area: btn;
}

.btn{ 
    margin-bottom: 5px;
    margin-top: 5px;
    width:35%;
    text-align: center;
}

img{
    width:100%;
    height: 100%;
}

.pic{
    height: 100%;
    width: 100%;
    grid-area: pic;
}

textarea{
    vertical-align: top;
    width: 100%
}
</style>