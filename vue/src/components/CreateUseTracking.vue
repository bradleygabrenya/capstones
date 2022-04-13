<template>
  <div>
    <form v-show="!equipmentSelected">
      <select class="form-control">
          <option selected>Select Equipment</option>
          <option v-for="equipment in equipmentDetails" v-bind:key="equipment.equipmentId">{{equipment.name}}</option>
      </select>
      <button type="button" class="btn btn-primary btn-lg" v-on:click="startWorkout">Start Workout</button>
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
      equipmentId: 2000,
      workoutId: parseInt(this.workoutId)
    }
  }
},
methods:{
  toggleEquipmentSelected(){
    this.equipmentSelected = true;
  },

    startWorkout() {
      this.toggleEquipmentSelected();
        workoutDetailsService.postUseTracking(this.useTracking).then((response) => {
            console.log("Reached", response.data)
            if(response.status === 200) {
              this.useTracking.trackingId = response.data;
              console.log(response.data)
            }
        })
    },

  

  endTheSet(){
    workoutDetailsService.putUseTracking(this.useTracking).then((response) => {
            if(response.status === 200) {
              this.equipmentSelected = false;
              this.$router.push()
            }
        })
        this.equipmentSelected = false;
  },

},
  props: { equipmentDetails: Array,
  workoutId: Number },
};

</script>

<style>
</style>