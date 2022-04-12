<template>
  <div>
      <button type="button" class="btn btn-primary btn-lg" v-on:click="startWorkout">Start Workout</button>

      <!--<a href="" class="btn btn-primary btn-lg">Start Workout</a> -->
  </div>
</template>

<script>
import workoutService from '@/services/WorkoutService'
export default {



methods: {
    startWorkout() {
        workoutService.addDailyWorkout(this.$store.state.user.userId).then((response) => {
            if(response.status === 201) {
                this.$router.push()
            }
        })
    }
}
}
</script>

<style>

</style>