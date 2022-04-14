<template>
  <div class="home">
    <h1>Home</h1>
    <p>Click "Past Workouts" to view a preview of your past trips to the gym, or click "Logout" to log out!</p>
    <p>
      Click "Start Workout" to check-in to the gym and begin tracking your workout.
    </p>
    <todays-workout />
  </div>
</template>

<script>
import TodaysWorkout from '@/components/TodaysWorkout'


export default {
  components: { TodaysWorkout },
  name: "home",
  
};
</script>
