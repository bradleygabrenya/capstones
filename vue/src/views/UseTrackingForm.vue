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
    };
  },

  created() {
    EquipmentService.getEquipmentList().then((response) => {
      this.equipmentDetails = response.data;
    });
  },
};
</script>

<style>
</style>