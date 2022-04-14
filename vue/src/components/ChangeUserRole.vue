<template>
  <div>
    <table>
      <thead>
        Gym Members:
      </thead>
      <tbody>
        <tr v-for="user in userList" v-bind:key="user.username">
          <td>
            {{ user.username }}
            <select class="form-control" v-model="user.role">
              <option selected>{{ user.role }}</option>
              <option value="user">User</option>
              <option value="employee">Employee</option>
              <option value="admin">Admin</option>
            </select>
            <button value="Change Role" v-on:click="changeUserRole(user)">
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

<style>
</style>