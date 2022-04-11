<template>
  <div>
    <use-tracking v-bind:workoutDetails="workoutDetails" />
    
    <h1>asdfasdfsadf</h1>
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

  //params: ["workoutId"],

  components: {
    UseTracking,
  },

  created() {
    workoutDetailsService.getWorkoutDetails(this.$route.params.workoutId).then((response) => {
        this.workoutDetails = response.data;

        console.log("Reached getWorkoutDetails", this.workoutDetails)
    });
  },
};
</script>

<style>
</style>