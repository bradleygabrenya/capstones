<template>
  <div>
    <form v-show="!equipmentSelected">
      <select class="form-control" v-model="equipmentName">
          <option selected>Select Equipment</option>
          <option v-for="equipment in equipmentDetails" v-bind:key="equipment.equipmentId">{{equipment.name}}</option>
      </select>
      <button type="button" class="btn btn-primary btn-lg" v-on:click="startWorkout">Start Set</button>
    </form>
    <form v-show="equipmentSelected">
      <label for="reps">Reps</label>
      <input type="number" id="reps" name="reps" min="0" v-model.number="useTracking.reps">
      <br>
      <label for="weight">Weight</label>
      <input type="number" id="weight" name="weight" min="0" step=".5" v-model.number="useTracking.weight">
      <br>
      <button type="button" class="btn btn-primary btn-lg" v-on:click="endTheSet">End Set</button>
      <br>
      <button type="button" class="btn btn-primary btn-lg" v-on:click="toggleEquipmentSelected">End Workout</button>

    </form>

  </div>
</template>

<script>
import workoutDetailsService from '@/services/WorkoutDetailsService' 

export default {
data(){
  return{
    equipmentSelected: false,
    
    useTracking: {
      userId: this.$store.state.user.userId,
      reps: 0,
      weight: 0,
      trackingId: 0,
      equipmentId: 0,
      workoutId: parseInt(this.workoutId)
    },

    equipmentName: ""
  }
},

methods:{
  toggleEquipmentSelected(){
    this.equipmentSelected = true;
    this.equipmentDetails.forEach((e) => {
      if (e.name == this.equipmentName) {
        this.useTracking.equipmentId = e.equipmentId
      }
    })
  },

    startWorkout() {
      this.toggleEquipmentSelected();
        workoutDetailsService.postUseTracking(this.useTracking).then((response) => {
            if(response.status === 200) {
              this.useTracking.trackingId = response.data;
            }
        })
    },

  endTheSet(){
    workoutDetailsService.putUseTracking(this.useTracking).then((response) => {
            if(response.status === 200) {
              this.equipmentSelected = false;
            }
        })
        this.useTracking.reps = 0;
        this.useTracking.weight = 0;
  },

  
},

  props: { equipmentDetails: Array,
  workoutId: Number },

};

</script>

<style>
</style>