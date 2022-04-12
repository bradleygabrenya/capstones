<template>
  <div>
      <table>
          <thead>Gym Members: </thead>
          <tbody>
              <tr v-for="user in userList" v-bind:key="user.username">
                  <td>{{user.username}}</td>
              </tr>
          </tbody>
      </table>
  </div>
</template>

<script>

export default {
    name: "UserDisplay",
    props: {userList: Array}

    
}
</script>

<style>
</style>