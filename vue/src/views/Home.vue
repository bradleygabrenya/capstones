<template>
  <div class="home card">
    <h1>Home</h1>
    <h5>Click "Workout History" to view a preview of your past trips to the gym, or click "Logout" to log out!</h5>
    <h5>
      Click "Start Workout" to check-in to the gym and begin tracking your workout.
    </h5>
    <todays-workout class="btn"/>
  </div>
</template>

<script>
import TodaysWorkout from '@/components/TodaysWorkout'


export default {
  components: { TodaysWorkout },
  name: "home",
  
};
</script>

<style scoped>
.home{
  text-align: center;
  width: 100%;
}

h1{
    text-align: center;
}

h5{
  margin-top: 25px;
}

.btn{
display: inline-block;
align-self: center;
margin: auto;
margin-top: 10px;
}

.card{
  opacity: 95%;
  padding-right: 5%;
  padding-left: 5%;
  background-color: rgb(24,26,27);
  color: #d1cdc7;
}

</style>