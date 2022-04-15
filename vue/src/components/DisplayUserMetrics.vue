<template>
  <div>
    <table>
      <h3>Your Metrics</h3>
      <tbody class="card">
        <tr>
          <td class="labels">Visits during past 7 days:</td>
          <td class="empty"></td>
          <td class="values">{{ userMetrics.sumSevenDayVisits }}</td>
        </tr>
        <tr>
          <td class="labels">Average workout duration past 7 days:</td>
          <td class="empty"></td>
          <td class="values">{{ Math.round(userMetrics.sevenDaySum / 60) }} minutes</td>
        </tr>
        <tr>
          <td class="labels">Visits during past 30 days:</td>
          <td class="empty"></td>
          <td class="values">{{ userMetrics.sumThirtyDayVisits }}</td>
        </tr>
        <tr>
          <td class="labels">Average workout duration past 30 days:</td>
          <td class="empty"></td>
          <td class="values">{{ Math.round(userMetrics.thirtyDaySum / 60) }} minutes</td>
        </tr>
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
  },
};
</script>

<style scoped>
.card {
  display: inline-block;
  padding-left: 10%;
  width: 100%;
  padding-right: 10%;
}

table {
  width: 100%;
}

.empty {
  width: 25%;
}
.values {
    display: inline-block;
  width: 100%;
  align-content: end;
  text-align: end;
}

tr{
    margin-top: 100px;
    margin-bottom: 5px;
}

.labels {
  width: 50%;
}
</style>