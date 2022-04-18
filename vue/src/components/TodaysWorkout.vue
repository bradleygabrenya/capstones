<template>
  <div>
      <button type="button" class="btn btn-primary btn-lg" v-show="this.$store.state.user.checkedIn == 'FALSE' " v-on:click="startWorkout">Start Workout</button>
      <button type="button" class="btn btn-primary btn-lg" v-show="this.$store.state.user.checkedIn == 'TRUE'" v-on:click="continueWorkout">Continue Workout</button>
  </div>
</template>

<script>
import workoutService from '@/services/WorkoutService'
export default {


methods: {
    startWorkout() {
        workoutService.addDailyWorkout(this.$store.state.user.userId).then((response) => {
            if(response.status === 200) {
                this.$store.commit("CHANGE_CHECKIN_TRUE")
                this.$store.commit("SAVE_WORKOUT_ID", response.data)
                this.$router.push({name: 'use-tracking-form', params:{workoutId: response.data}})
            }
        })
    },
    continueWorkout() {
        workoutService.getWorkouts(this.$store.state.user.userId).then((response) => {
            if (response.status === 200) {
                response.data.forEach((e) => {
                    if (e.checkOut == "9999-12-31T00:00:00") {
                        this.$store.commit("SAVE_WORKOUT_ID", e.workoutId)
                    }
                })
                this.$router.push({name: 'use-tracking-form', params:{workoutId: this.$store.state.workoutId}})
            }
        })
    },


}
}
</script>

<style>

</style>