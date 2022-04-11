<template>
  <div>
    <daily-workout-details v-bind:workouts="workouts" />
    
    <h1>asdfasdfsadf</h1>
  </div>
</template>

<script>
import workoutService from "@/services/WorkoutService";
import DailyWorkoutDetails from "../components/DailyWorkoutDetails.vue";

export default {
  data() {
    return {
      workouts: [],
    };
  },

  components: {
    DailyWorkoutDetails,
  },

  created() {
    workoutService.getWorkouts(this.$store.state.user.userId).then((response) => {
        this.workouts = response.data;
    });
  },
};
</script>

<style>
</style>