<template>
  <div class="display card">
    <form v-show="!equipmentSelected">
      <select class="form-control" v-model="equipmentName" v-on:change="sendToInstructions">
        <option selected >{{equipmentName}} </option>
          <option v-for="equipment in equipmentDetails" v-bind:key="equipment.equipmentId">{{equipment.name}}</option>
      </select>
      <div class="buttons">
      <button id="start-set" type="button" class="btn btn-success btn-lg" v-on:click="startWorkout"> Start Set </button>
      <a class="btn btn-lg btn-info" v-bind:href="instructionsLink" target="_blank" >Instructions</a>


      <button id="end-workout" type="button" class="btn btn-danger btn-lg" v-on:click="endWorkout">End Workout</button>
      </div>
    </form>
    <form v-show="equipmentSelected">
      <label for="reps"><span style="font-weight:bold">Reps:</span></label> &nbsp;
      <input type="number" id="reps" name="reps" min="0" v-model.number="useTracking.reps">
      <br>
      <label for="weight"><span style="font-weight:bold">Weight:</span></label>&nbsp;
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

    equipmentName: "Select Equipment",
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
      
      if(this.equipmentName != "Select Equipment")      
        {
          this.toggleEquipmentSelected();
          workoutDetailsService.postUseTracking(this.useTracking).then((response) => {
            if(response.status === 200) {
              this.useTracking.trackingId = response.data;
            }
        })
    }},

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
        this.$store.commit("CHANGE_CHECKIN_FALSE")
        this.$store.commit("SAVE_WORKOUT_ID", 0)
        this.$router.push({name: "home"});
      }
    })
  }

  
},

  props: { equipmentDetails: Array,
  workoutId: Number },

};

</script>

<style scoped>


.buttons {
  display: flex;
  justify-content: space-evenly;
  padding-bottom: 10px;
}

.card{
  opacity: 95%;
  background-color: rgb(24,26,27);
  color: #d1cdc7;
}

.form-control {
    color: rgb(181, 175, 166);
    background-color: rgb(24, 26, 27);
    border-color: rgb(60, 65, 68); 
    grid-area: form;
}

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

input {
    background-color: rgb(59,59,59);
    color: #d1cdc7;
} 

label {
  color: #d1cdc7
}
</style>