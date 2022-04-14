<template>
  <div id="app">
    <div id="nav">
      <br>
      <router-link class="home" v-bind:to="{ name: 'home' }"> Home </router-link>
      <router-link class="workouts"  v-bind:to="{ name: 'workouts', params: {userId: this.$store.state.user.userId}}" v-if="$store.state.token != ''"> Past Workouts </router-link>
      <router-link class="logout" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''"> Logout </router-link>
      <router-link class="userlist" v-bind:to="{name: 'user-list'}" v-if="this.$store.state.user.role === 'admin' || this.$store.state.user.role==='employee'"> View Members </router-link>
      <router-link class="userlist" v-bind:to="{name: 'update-user-role'}" v-if="this.$store.state.user.role === 'admin' "> View Roles </router-link>
    </div>
    <router-view />
  </div>
</template>

<style scoped>
#app {
  margin: auto;
  text-align: center;
  font-family: "Verdana", sans-serif;
}
#nav {
  padding-bottom: 10px;
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
</style>