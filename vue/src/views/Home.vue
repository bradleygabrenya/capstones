<template>
  <div class="home">
    <h1>Home</h1>
    <p>Welcome to your new home.</p>
    <p>
      In the initial configuration, this page can only be seen when logged in.
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
