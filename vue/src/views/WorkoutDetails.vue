<template>
  <div>
    <use-tracking v-bind:workoutDetails="workoutDetails" />
    
    
  </div>
</template>

<script>
import workoutDetailsService from "@/services/WorkoutDetailsService";
import UseTracking from "../components/UseTracking.vue";

export default {
  data() {
    return {
      workoutDetails: [],
    };
  },

  components: {
    UseTracking,
  },

  created() {
    workoutDetailsService.getWorkoutDetails(this.$route.params.workoutId).then((response) => {
        this.workoutDetails = response.data;

    });
  },
};
</script>

<style>
</style>