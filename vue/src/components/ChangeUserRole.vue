<template>
  <div>
    <h1>Gym Members:</h1>
    <table class="card">
      <tbody>
        <tr v-for="user in userList" v-bind:key="user.username" >
          <td class="name data">
            {{ user.username }}
          </td>
          <td class="data">
            <select class="form-control" v-model="user.role">
              <option selected>{{ user.role }}</option>
              <option value="user">User</option>
              <option value="employee">Employee</option>
              <option value="admin">Admin</option>
            </select>
          </td>
          <td  class="data">
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
      this.$toast("Role successfully changed!", {
  position: "top-right",
  timeout: 4000,
  closeOnClick: true,
  pauseOnFocusLoss: true,
  pauseOnHover: true,
  draggable: true,
  draggablePercent: 0.6,
  showCloseButtonOnHover: false,
  hideProgressBar: false,
  closeButton: "button",
  icon: true,
  rtl: false
});
    },
  },
};
</script>

<style scoped>
tr{
  width: 100%
}
.card{
  opacity: 95%;
    padding-top: 5px;
    padding-bottom: 5px;
    padding-left: 5%;
    padding-right: 5%;
    margin-top: 10px;
    margin-bottom: 2px;
    width: 50%;
    background-color: rgb(24,26,27);
    color: #d1cdc7;
    display: grid;
    grid-template-columns: 
    "1fr 3fr 2fr";
    grid-template-areas: 
    "name form btn";
}

.form-control {
    color: rgb(181, 175, 166);
    background-color: rgb(24, 26, 27);
    border-color: rgb(60, 65, 68); 
    grid-area: form;
}
.name{
  grid-area: name;
}

button{
  margin-top: 5px;
  grid-area: btn;
}


h1{
  font-weight: bold;
  color: #d1cdc7;
  text-shadow: 1px 0 0 rgb(46, 46, 46), 0 -1px 0 rgb(46, 46, 46),
    0 1px 0 rgb(46, 46, 46), -1px 0 0 rgb(46, 46, 46);
}

@media screen and (max-width: 820px) {
    .card {
  width: 375px;
  font-family: "Verdana", sans-serif;
  }
}
</style>