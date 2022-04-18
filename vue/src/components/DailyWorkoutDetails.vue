<template>
  <div class="display">
    <h1>Workout History</h1>
    <h3> <router-link v-bind:to="{ name: 'user-metrics' }"> View Workout Metrics </router-link></h3>
    <h3 class="card">
      Lifetime Average Workout Duration: {{ Math.round(averageWorkoutDuration) }} Minutes
    </h3>
    <table
      v-for="workout in workouts"
      v-bind:key="workout.workoutId"
      class="card"
    >
      <tbody>
        <tr>
          <td class="labels">Date:</td>
          <td class="empty"></td>
          <td align="right" class="values">
            {{ workout.checkIn.substring(0, 10) }}
          </td>
        </tr>
        <tr>
          <td class="labels">Check-in:</td>
          <td class="empty"></td>
          <td align="right" class="values">
            {{ workout.checkIn.substring(11, 19) }}
          </td>
        </tr>
        <tr>
          <td class="labels">Check-out:</td>
          <td class="empty"></td>
          <td align="right" class="values">
            {{ workout.checkOut.substring(11, 19) }}
          </td>
        </tr>
        <tr>
          <td class="labels">Total Workout Duration:</td>
          <td class="empty"></td>
          <td align="right" class="values">
            {{
              Math.round(
                (Date.parse(workout.checkOut) - Date.parse(workout.checkIn)) /
                  60000
              )
            }}
            Minutes
          </td>
        </tr>
      </tbody>
      <router-link
        :to="{
          name: 'workout-details',
          params: { workoutId: workout.workoutId },
        }"
        class="btn btn-primary"
        >View Details
      </router-link>
    </table>
  </div>
</template>

<script>
export default {
  name: "DailyWorkoutDetails",
  props: { workouts: Array },
  computed: {
    averageWorkoutDuration() {
      let sum = this.workouts.reduce((currentSum, workout) => {
        return (
          currentSum +
          Math.round(
            (Date.parse(workout.checkOut) - Date.parse(workout.checkIn)) / 60000
          )
        );
      }, 0);

      return sum / this.workouts.length;
    },
  },
};
</script>

<style scoped>
h1 {
  text-align: center;
  font-weight: bold;
}
h3{
    text-align: center;
}

.btn {
  width: 50%;
  display: inline-block;
  align-self: center;
  margin-bottom: 5px;
}

table {
  width: 100%;
}

.empty {
  width: 0%;
}
.values {
  width: 100%;
}

.labels {
  width: 50%;
}

.card {
  margin-bottom: 10px;
  padding-left: 20%;
  padding-right: 20%;
  padding-top: 2%;
}
</style>