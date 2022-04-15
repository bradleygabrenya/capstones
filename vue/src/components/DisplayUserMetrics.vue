<template>
  <div>
      <table>
          <thead>Your Metrics</thead>
          <tbody>
              <tr>
                  <td>Average workout duration past 7 days: </td>
                  <td>{{userMetrics.sevenDaySum}} minutes</td>
              </tr>
          </tbody>
      </table>
  </div>
</template>

<script>
import MetricsService from '@/services/MetricsService.js'
export default {
    data() {
        return {
            userMetrics: {
                sevenDaySum: 0,
                thirtyDaySum: 0,
                sumSevenDayVisits: 0,
                sumThirtyDayVisits: 0,
            },
            
        }
    },

    created() {
        MetricsService.getUserMetrics(this.$store.state.user.userId).then((response) => {
            if(response.status === 200) {
                this.userMetrics = response.data;
            }
        })
    }
}
</script>

<style>

</style>