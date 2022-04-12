<template>
  <div>
    <form>
      <select class="form-control">
          <option selected>Select Equipment</option>
          <option v-for="equipment in equipmentDetails" v-bind:key="equipment.equipmentId">{{equipment.name}}</option>
      </select>
    </form>
  </div>
</template>

<script>
export default {
  props: { equipmentDetails: Array },
};
</script>

<style>
</style>