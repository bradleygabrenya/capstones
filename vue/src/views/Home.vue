<template>
  <div class="home card">
    <h1>Fitness Elevator</h1>
    <h3>Take your workout to the next level!</h3> <br>
    <p>Tech Elevator’s coding and career prep gymnasium is designed to provide the most efficient & highest 
      quality path to elevate your gains. Our Industry-aligned full-stack weight-room is taught by seasoned 
      fitness enthusiasts, Johnathan and Daniel, and combined with our top-rated Pathway™ Program to help people 
      from a wide variety of backgrounds and experiences gain the skills and confidence to rock a sleeveless shirt 
      on Casual Friday.</p>

      <p>Founded in 2015 with a focus on quality and care in everything we do, we’re proud of our outcomes which 
      have earned us a leading national bootcamp position based on shirt size increases following the program. 
      Our results are audited by third-parties and transparently reported the Council on Integrity Results in 
      Reporting (CIRR). </p>
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