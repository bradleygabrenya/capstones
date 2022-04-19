<template>
  <div>
      <table >
          <th>
              Equipment use over the past 30 days
          </th>
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
    padding-left: 10px;
}
</style>