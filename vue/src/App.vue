<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home </router-link>
      
      <router-link v-bind:to="{ name: 'workouts', params: {userId: this.$store.state.user.userId}}" v-if="$store.state.token != ''">Past Workouts </router-link>
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout </router-link>
      <router-link v-bind:to="{name: 'user-list'}" v-if="this.$store.state.user.role === 'admin' || this.$store.state.user.role==='employee'">View Members </router-link>
    </div>
    <router-view />
  </div>
</template>
