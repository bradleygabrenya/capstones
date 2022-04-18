<template>
  <div>
    <table class="card">
      <thead>
        Monday's Classes
      </thead>
      <tbody>
        <tr v-for="classes in mondayList" v-bind:key="classes.classId">
          <td>{{ classes.className }}</td>
          <td>{{ classes.classDescription }}</td>
          <td>{{ classes.time }}</td>
        </tr>
      </tbody>
    </table>
    <table class="card">
      <thead>
        Tuesday's Classes
      </thead>
      <tbody>
        <tr v-for="classes in tuesdayList" v-bind:key="classes.classId">
          <td>{{ classes.className }}</td>
          <td>{{ classes.classDescription }}</td>
          <td>{{ classes.time }}</td>
        </tr>
      </tbody>
    </table>
    <table class="card">
      <thead>
        Wednesday's Classes
      </thead>
      <tbody>
        <tr v-for="classes in wednesdayList" v-bind:key="classes.classId">
          <td>{{ classes.className }}</td>
          <td>{{ classes.classDescription }}</td>
          <td>{{ classes.time }}</td>
        </tr>
      </tbody>
    </table>
    <table class="card">
      <thead>
        Thursday's Classes
      </thead>
      <tbody>
        <tr v-for="classes in thursdayList" v-bind:key="classes.classId">
          <td>{{ classes.className }}</td>
          <td>{{ classes.classDescription }}</td>
          <td>{{ classes.time }}</td>
        </tr>
      </tbody>
    </table>
    <table class="card">
      <thead>
        Friday's Classes
      </thead>
      <tbody>
        <tr v-for="classes in fridayList" v-bind:key="classes.classId">
          <td>{{ classes.className }}</td>
          <td>{{ classes.classDescription }}</td>
          <td>{{ classes.time }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import ClassesService from "@/services/ClassesService";
export default {
  data() {
    return {
      classesList: [],
      mondayList: [],
      tuesdayList: [],
      wednesdayList: [],
      thursdayList: [],
      fridayList: [],
    };
  },

  created() {
    ClassesService.getClasses().then((response) => {
      if (response.status === 200) {
        this.classesList = response.data;
        this.mondayList = this.classesList.filter((e) => e.day == "Monday");
        this.tuesdayList = this.classesList.filter((e) => e.day == "Tuesday");
        this.wednesdayList = this.classesList.filter((e) => e.day == "Wednesday");
        this.thursdayList = this.classesList.filter((e) => e.day == "Thursday");
        this.fridayList = this.classesList.filter((e) => e.day == "Friday");
      }
    });
    
  },

  
};
</script>

<style>
td {
    padding-right: 15px;
    padding-left: 20px;
    padding-top: 10px;
}
thead {
    padding-left: 10px;
    font-weight: bold;
}
table {
    padding-bottom: 15px;
    padding-top: 15px;
    margin-left: 10px;
    margin-right: 10px;
}
</style>