<template>
  <div>
    <create-use-tracking v-bind:equipmentDetails="equipmentDetails"/>
  </div>
</template>



<script>
import CreateUseTracking from "../components/CreateUseTracking.vue";
import EquipmentService from "../services/EquipmentService";

export default {
  components: {
    CreateUseTracking,
  },

  data() {
    return {
      equipmentDetails: [],
      workoutId: 0,
    };
  },

  created() {
    this.workoutId = this.$route.params.workoutId
    console.log("In use-tracking-form", this.workoutId)

    EquipmentService.getEquipmentList().then((response) => {
      this.equipmentDetails = response.data;
    });
  },
};
</script>

<style>
</style>