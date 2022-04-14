<template>
  <div>
    <daily-workout-details v-bind:workouts="workouts" />
    
    
  </div>
</template>

<script>
import workoutService from "@/services/WorkoutService";
import DailyWorkoutDetails from "../components/DailyWorkoutDetails.vue";

export default {
  data() {
    return {
      workouts: [],
      userId: this.$route.params.userId,
    };
  },

  
  components: {
    DailyWorkoutDetails,
  },

  created() {
    console.log("Reached DailyWorkouts.vue", this.userId)
    workoutService.getWorkouts(this.userId).then((response) => {
      this.workouts = response.data;
      console.log("WorkoutService works", this.workouts)
    });
  },
};
</script>

<style>
</style>