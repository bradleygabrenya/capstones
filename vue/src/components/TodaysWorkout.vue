<template>
  <div>
      <button type="button" class="btn btn-primary btn-lg" v-on:click="startWorkout">Start Workout</button>
  </div>
</template>

<script>
import workoutService from '@/services/WorkoutService'
export default {



methods: {
    startWorkout() {
        workoutService.addDailyWorkout(this.$store.state.user.userId).then((response) => {
            if(response.status === 200) {
                this.$router.push({name: 'use-tracking-form', params:{workoutId: "response.data"}})
            }
        })
    }
}
}
</script>

<style>

</style>