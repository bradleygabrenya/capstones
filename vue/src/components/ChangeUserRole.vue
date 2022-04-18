<template>
  <div>
    <table>
      <thead>
        Gym Members:
      </thead>
      <tbody>
        <tr v-for="user in userList" v-bind:key="user.username" class="card">
          <td>
            {{ user.username }}
            <select class="form-control" v-model="user.role">
              <option selected>{{ user.role }}</option>
              <option value="user">User</option>
              <option value="employee">Employee</option>
              <option value="admin">Admin</option>
            </select>
            <button class="btn btn-primary" value="Change Role" v-on:click="changeUserRole(user)">
              Change Role
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import EmployeeService from "../services/EmployeeService.js";

export default {
  name: "ChangeUserRole",
  props: { userList: Array },

  methods: {
    changeUserRole(user) {
      EmployeeService.updateUserRole(user);
    },
  },
};
</script>

<style scoped>
.card{
    padding-top: 5px;
    padding-bottom: 5px;
    padding-left: 25%;
    padding-right: 25%;
    margin-top: 10px;
    margin-bottom: 2px;
    width: 375px;
}

button{
  margin-top: 5px;
}
</style>