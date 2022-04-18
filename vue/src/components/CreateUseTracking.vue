<template>
  <div class="display">
    <form v-show="!equipmentSelected">
      <select class="form-control" v-model="equipmentName" v-on:change="sendToInstructions">
          <option selected>Select Equipment</option>
          <option v-for="equipment in equipmentDetails" v-bind:key="equipment.equipmentId">{{equipment.name}}</option>
      </select>
      <div class="buttons">
      <button id="start-set" type="button" class="btn btn-success btn-lg" v-on:click="startWorkout">Start Set</button>
      <a class="btn btn-lg btn-info" v-bind:href="instructionsLink" target="_blank" >Instructions</a>


      <button id="end-workout" type="button" class="btn btn-danger btn-lg" v-on:click="endWorkout">End Workout</button>
      </div>
    </form>
    <form v-show="equipmentSelected">
      <label for="reps">Reps:</label> &nbsp;
      <input type="number" id="reps" name="reps" min="0" v-model.number="useTracking.reps">
      <br>
      <label for="weight">Weight:</label>&nbsp;
      <input type="number" id="weight" name="weight" min="0" step=".5" v-model.number="useTracking.weight">
      <br>
      <button type="button" class="btn btn-danger btn-lg buttons" v-on:click="endTheSet">End Set</button>

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

    equipmentName: "",
    instructionsLink:""
  }
},

methods:{
  sendToInstructions(){
    this.equipmentDetails.forEach((e) => {
      if(e.name == this.equipmentName){
        this.instructionsLink = e.instructionsLink
      }
    })
    
  },

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

  endWorkout() {
    workoutDetailsService.putDailyWorkout(this.workoutId).then((response) => {
      if (response.status === 200) {
        this.$router.push({name: "home"});
      }
    })
  }

  
},

  props: { equipmentDetails: Array,
  workoutId: Number },

};

</script>

<style>
#reps{
  display: inline-block;
  align-self: right;
  margin-bottom: 15px;
}

.buttons{
  margin-top: 100px;
  display: flexbox;
  margin-right: 5px;
  margin-left: 5px;
}
#end-workout{
  display: flex;
  margin: auto;
  float: right;
}

#start-set{
  display: flex;
  margin: auto;
  float: left;
}

.display{
  margin-top: 50px;
}
</style>