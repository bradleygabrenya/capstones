<template>
  <div>
      <h1>Equipment Use Over the Past 30 Days</h1>
      <table class="card">
          <tbody>
              <tr>
              <td >Equipment Name</td>
              <td class="td_two_three">Total Reps</td>
              <td class="td_two_three">Total Time Use</td>
              </tr>
              <tr v-for="equipment in equipmentMetrics" v-bind:key="equipment.equipmentName" >
                  <td>
                      {{equipment.equipmentName}}
                  </td>
                  <td class="td_two_three">
                      {{equipment.totalEquipmentReps}}                      
                  </td>
                  <td class="td_two_three">
                      {{Math.round(equipment.totalUseSeconds / 60)}} min
                  </td>
              </tr>
          </tbody>

      </table>
  </div>
</template>

<script>
import EquipmentService from '../services/EquipmentService'
export default {
    data(){
        return {
            equipmentMetrics: []
        }
    },

    created(){
        EquipmentService.getEquipmentMetrics().then((response) => {
            this.equipmentMetrics = response.data;
        } )
    }
}
</script>

<style scoped>
table{
    margin-top: 20px;
}

.td_two_three{
    padding-left: 15px;
}

.card{
    padding-top: 10px;
    padding-bottom: 10px;;
    padding-left: 10px;
    background-color: rgb(24,26,27);
    color: #d1cdc7;
}

h1{
  color: #d1cdc7;
}
</style>