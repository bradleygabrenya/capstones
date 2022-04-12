<template>
  <div>
      <user-display v-bind:userList="userList" />
  </div> 
</template>

<script>
import authService from "@/services/AuthService";
import userDisplay from '@/components/UserDisplay';

export default {
    data() {
        return {
            userList: [],
        }
    },
    components: {
        userDisplay,
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