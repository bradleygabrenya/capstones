<template>
  <div>
      <h1>Your Profile</h1>
      <table class="card" v-show="!showForm">
          <thead></thead>
          <tbody class="container">
              <div class="pic">
                <img :src="this.$store.state.user.photo" alt="">
              </div>
              <div id="user-display">
                <tr>
                    <td><span style="font-weight:bold">Username: </span></td>
                    <td>{{this.$store.state.user.username}}</td>
                </tr>
                <tr>
                    <td><span style="font-weight:bold">Email: </span></td>
                    <td>{{this.$store.state.user.email}}</td>
                </tr>
                <tr>
                    <td><span style="font-weight:bold">Goals: </span></td>
                    <td>{{this.$store.state.user.workoutGoals}}</td>
                </tr>
                <tr>
                    <td><span style="font-weight:bold">Profile: </span></td>
                    <td>{{this.$store.state.user.workoutProfile}}</td>
                </tr>
              </div>
              <button class = 'btn btn-primary' v-on:click="toggleShowForm()">Update Profile</button>
          </tbody>
          
      </table>
      
      <form id="user-display-form" action="submit" v-show="showForm" v-on:submit.prevent="updateProfile()" class="card">
          <label for="photo">Photo: </label>
          <input type="text" id="photo" name="photo" v-model="user.photo"><br>
          <label for="email">Email: </label>
          <input type="email" id="email" name="email" v-model="user.email"><br>
          <label for="userGoals">Goals: </label>
          <textarea name="userGoals" id="userGoals" cols="30" rows="5"  v-model="user.workoutGoals"></textarea><br>
          <label for="workoutProfile">Profile: </label>
          <textarea name="workoutProfile" id="workoutProfile" cols="30" rows="5"  v-model="user.workoutProfile"></textarea><br>
          
          <div class="btn-container">
          <button type='submit' class="btn btn-success" v-on:click="toggleShowForm()">Submit</button>
          <button class="btn btn-danger" v-on:click="toggleShowForm()">Cancel</button>
          </div>
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
td {
    padding-right: 10px;
}
.btn-container {
    display: flex;
    justify-content: space-evenly;
}
.container{
    display: grid;
    grid-template-columns: 2fr 1fr;
    grid-template-areas: 
    "profile pic"
    "profile pic"
    "btn btn";
    grid-area: main-container;
}

#user-display{
    grid-area: profile;
}

.card{
    opacity: 95%;
    padding-left: 10%;
    padding-right: 10%;
    padding-top: 3%;
    padding-bottom: 3%;
    background-color: rgb(24,26,27);
    color: #d1cdc7;
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
    width: 100%;
    height: 100%;
    object-fit: contain;
}

.pic{
    height: 100%;
    width: 100%;
    grid-area: pic;
}

input {
    background-color: rgb(59,59,59);
    color: #d1cdc7;
} 

textarea {
    vertical-align: top;
    width: 100%;
    background-color: rgb(59,59,59);
    color: #d1cdc7;
} 
h1{
    color: #d1cdc7;
    font-weight: bold;
    text-align: center;
    text-shadow: 1px 0 0 rgb(46, 46, 46), 0 -1px 0 rgb(46, 46, 46), 0 1px 0 rgb(46, 46, 46), -1px 0 0 rgb(46, 46, 46); 
}

@media screen and (max-width: 820px) {
    .container {
        grid-template-areas: "pic"
        "profile"
        "btn";
        grid-template-columns: "1fr";
    }
    .btn-primary {
        align-self: center;
    }
}
</style>