<template>
  <div id="app">
    <div id="nav">
      <br>

      <div class="dropdown">
        <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">Menu
        <span class="caret"></span></button>
          <ul class="dropdown-menu">
            <li> <router-link class="home" v-bind:to="{ name: 'home' }"> Home </router-link></li>
            <li><router-link class="workouts"  v-bind:to="{ name: 'workouts', params: {userId: this.$store.state.user.userId}}" v-if="$store.state.token != ''"> Workout History </router-link></li>
            <li><router-link class="userlist" v-bind:to="{name: 'user-list'}" v-if="this.$store.state.user.role === 'admin' || this.$store.state.user.role==='employee'"> View Members </router-link></li>
            <li><router-link class="userlist" v-bind:to="{name: 'update-user-role'}" v-if="this.$store.state.user.role === 'admin' "> View Roles </router-link></li>
            <li><router-link class = "userlist" v-bind:to="{ name: 'user-profile'}" v-if="$store.state.token != ''"> Profile </router-link></li>
            <li><router-link class = "userlist" v-bind:to="{ name: 'equipment-metrics'}" v-if="this.$store.state.user.role === 'admin' || this.$store.state.user.role==='employee'"> Equipment Metrics </router-link></li>
            <li><router-link class = "userlist" v-bind:to="{ name: 'classes'}"> Classes </router-link></li>
            <li><router-link class="logout" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''"> Logout </router-link></li>
          </ul>
      </div>

    </div>
    <router-view />
  </div>
</template>

<style scoped>
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
  padding: 10px;
  border-right-width: 0px;
  border-bottom-width: 0px;
  border-top-width: 0px;
  display: inline-block;
}

.logout {
  padding: 10px;
  border-left-width: 2px;
  border-right-width: 0px;
  border-bottom-width: 0px;
  border-top-width: 0px;
  display: inline-block;
}

.userlist {

  padding: 10px;
  border-left-width: 2px;
  border-right-width: 0px;
  border-bottom-width: 0px;
  border-top-width: 0px;
  display: inline-block;
}

.dropdown-toggle{
  width: 200px;
}

.dropdown-menu {
    color: rgb(209, 205, 199);
    list-style-image: initial;
    background-color: rgb(24, 26, 27);
    border-color: rgba(140, 130, 115, 0.15);
} 

@media screen and (max-width: 768px) {
    #app {
  margin: auto;
  font-family: "Verdana", sans-serif;
  }
}

</style>