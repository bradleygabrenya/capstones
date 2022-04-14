<template>
  <div>
      <change-user-role v-bind:userList="userList" />
  </div>
</template>

<script>
import ChangeUserRole from "../components/ChangeUserRole.vue"
import authService from "@/services/AuthService";

export default {
    data() {
        return {
            userList: [],
        }
    },
  components: { ChangeUserRole,
  },
  created() {
        authService.getUserList().then((response) => {
            this.userList = response.data;
        })
    }

}
</script>

<style>

</style>