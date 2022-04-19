<template>
  <div id="app">
    <div id="nav">
      <br>

<div id="main">
  <button class="openbtn" v-on:click="openNav()">☰ Menu</button>  
 
</div>
      <div id="mySidebar" class="sidebar">
  <a href="javascript:void(0)" class="closebtn" v-on:click="closeNav()">×</a>
      <router-link class="home" v-bind:to="{ name: 'home' }"> Home </router-link>
      <router-link class="workouts"  v-bind:to="{ name: 'workouts', params: {userId: this.$store.state.user.userId}}" v-if="$store.state.token != ''"> Workout History </router-link>
      <router-link class="userlist" v-bind:to="{name: 'user-list'}" v-if="this.$store.state.user.role === 'admin' || this.$store.state.user.role==='employee'"> View Members </router-link>
      <router-link class="userlist" v-bind:to="{name: 'update-user-role'}" v-if="this.$store.state.user.role === 'admin' "> View Roles </router-link>
      <router-link class = "userlist" v-bind:to="{ name: 'user-profile'}"> Profile </router-link>
      <router-link class = "userlist" v-bind:to="{ name: 'equipment-metrics'}" v-if="this.$store.state.user.role === 'admin' || this.$store.state.user.role==='employee'"> Equipment Metrics </router-link>
      <router-link class = "userlist" v-bind:to="{ name: 'classes'}"> Classes </router-link>
      <router-link class="logout" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''"> Logout </router-link>

</div>

    </div>
    <router-view />
  </div>
</template>

<script>
export default {
methods: {

  openNav() {
    document.getElementById("mySidebar").style.width = "300px";
    document.getElementById("main").style.marginLeft = "300px";
  },
  
  closeNav() {
    document.getElementById("mySidebar").style.width = "0";
    document.getElementById("main").style.marginLeft= "0";
  }
}
}
</script>

<style scoped>


.sidebar {
  height: 100%;
  width: 0;
  position: fixed;
  z-index: 1;
  top: 0;
  left: 0;
  background-color: #111;
  overflow-x: hidden;
  transition: 0.5s;
  padding-top: 60px;
}

.sidebar a {
  padding: 8px 8px 8px 32px;
  text-decoration: none;
  font-size: 25px;
  color: #818181;
  display: block;
  transition: 0.3s;
}

.sidebar a:hover {
  color: #f1f1f1;
}

.sidebar .closebtn {
  position: absolute;
  top: 0;
  right: 25px;
  font-size: 36px;
  margin-left: 50px;
}

.openbtn {
  font-size: 20px;
  cursor: pointer;
  background-color: #111;
  color: white;
  padding: 10px 15px;
  border: none;
}

.openbtn:hover {
  background-color: #444;
}

#main {
  transition: margin-left .5s;
  padding: 16px;
}
#app {
  margin: auto;
  font-family: "Verdana", sans-serif;
  margin-left: 20%;
  margin-right: 20%;
}
#nav {
  padding-bottom: 10px;
  text-align: center;
}

.home {
  padding: 10px;
  display: inline-block;
}

.workouts {
  border: solid;
  padding: 10px;
  border-left-width: 2px;
  border-right-width: 0px;
  border-bottom-width: 0px;
  border-top-width: 0px;
  display: inline-block;
}

.logout {
  border: solid;
  padding: 10px;
  border-left-width: 2px;
  border-right-width: 0px;
  border-bottom-width: 0px;
  border-top-width: 0px;
  display: inline-block;
}

.userlist {
  border: solid;
  padding: 10px;
  border-left-width: 2px;
  border-right-width: 0px;
  border-bottom-width: 0px;
  border-top-width: 0px;
  display: inline-block;
}



@media screen and (max-width: 768px) {
    #app {
  margin: auto;
  font-family: "Verdana", sans-serif;
  }
}

</style>