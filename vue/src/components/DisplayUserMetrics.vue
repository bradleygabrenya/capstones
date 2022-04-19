<template>
  <div>
    <table>
      <h3>Your Metrics</h3>

      <tbody class="container card">
        <div class="box1">
          <tr>
            <td class="labels">Visits during past 7 days:</td>
            <td class="values">{{ userMetrics.sumSevenDayVisits }}</td>
          </tr>
        </div>
        <div class="box2">
          <tr>
            <td class="labels">Average workout duration past 7 days:</td>
            <td class="values">
              {{ Math.round((this.userMetrics.sevenDaySum / this.userMetrics.sumSevenDayVisits) / 60) }} minutes
            </td>
          </tr>
        </div>
        <div class="box3">
          <tr>
            <td class="labels">Visits during past 30 days:</td>
            <td class="values">{{ userMetrics.sumThirtyDayVisits }}</td>
          </tr>
        </div>
        <div class="box4">
          <tr>
            <td class="labels">Average workout duration past 30 days:</td>
            <td class="values">
              {{ Math.round((this.userMetrics.thirtyDaySum / this.userMetrics.sumThirtyDayVisits) / 60) }} minutes
            </td>
          </tr>
        </div>
      </tbody>
    </table>
    <table>
      <h3>Average Metrics</h3>

      <tbody class="container card">
        <div class="box1">
          <tr>
            <td class="labels">Visits during past 7 days:</td>
            <td class="values"> {{Math.round((this.averageMetrics.totalAverageSevenDayVisits / this.averageMetrics.totalUserCount),2)
            }} </td>
          </tr>
        </div>
        <div class="box2">
          <tr>
            <td class="labels">Average workout duration past 7 days:</td>
            <td class="values">
              {{ Math.round((this.averageMetrics.totalAverageSevenDaySum / this.averageMetrics.totalAverageSevenDayVisits) / 60) }} minutes
            </td>
          </tr>
        </div>
        <div class="box3">
          <tr>
            <td class="labels">Visits during past 30 days:</td>
            <td class="values">{{ Math.round((this.averageMetrics.totalAverageThirtyDayVisits / this.averageMetrics.totalUserCount),2)}}</td>
          </tr>
        </div>
        <div class="box4">
          <tr>
            <td class="labels">Average workout duration past 30 days:</td>
            <td class="values">
              {{ Math.round((this.averageMetrics.totalAverageThirtyDaySum / this.averageMetrics.totalAverageThirtyDayVisits) / 60) }} minutes
            </td>
          </tr>
        </div>
      </tbody>
    </table>
  </div>
</template>

<script>
import MetricsService from "@/services/MetricsService.js";
export default {
  data() {
    return {
      userMetrics: {
        sevenDaySum: 0,
        thirtyDaySum: 0,
        sumSevenDayVisits: 0,
        sumThirtyDayVisits: 0,
      },
      averageMetrics: {
      }
    };
  },
  
  created() {
    MetricsService.getUserMetrics(this.$store.state.user.userId).then(
      (response) => {
        if (response.status === 200) {
          this.userMetrics = response.data;
        }
      }
    );
  
  MetricsService.getTotalUserMetrics().then(
      (response) => {
        if (response.status === 200) {
          this.averageMetrics = response.data;
        }
      }
    );
},
}
</script>

<style scoped>
.container {
  display: grid;
  grid-column-gap: 15px;
  grid-template-areas:
  "fr1 fr2" 
  "fr3 fr4";
  margin-bottom: 30px;
  padding-left: 10%;
  padding-right: 10%;
  /* padding-left: 10%;
  width: 100%;
  padding-right: 10%; */
}

.box1 {
  grid-area: "fr1";
  padding-bottom: 15px;
  text-align: center;
  justify-content: auto;
}

.box2 {
  grid-area: "fr2";
  text-align: center;
}

.box3 {
  grid-area: "fr3";
  text-align: center;
}

.box4 {
  grid-area: "fr4";
  text-align: center;
}

table {
  width: 100%;
}

h3{
  color: #d1cdc7;
}

.card{
  opacity: 95%;
  background-color: rgb(24,26,27);
    color: #d1cdc7;
}

/* .values {
  display: inline-block;
  width: 100%;
  align-content: end;
  text-align: end;
} */

/* tr{
    margin-top: 100px;
    margin-bottom: 5px;
} */
/* 
.labels {
  width: 50%;
} */
</style>