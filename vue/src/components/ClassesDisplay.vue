<template>
  <div>
    <h1>Weekly Class Schedule</h1>
    <table class="card">
      <thead class="title">
        Monday's Classes
      </thead>
      <tbody >
        <tr v-for="classes in mondayList" v-bind:key="classes.classId" class="monday-grid">
          <td class="name">{{ classes.className }}</td>
          <td class="description">{{ classes.classDescription }}</td>
          <td class="time">{{ classes.time }}</td>
        </tr>
      </tbody>
    </table>
    <table class="card">
      <thead class="title">
        Tuesday's Classes
      </thead>
      <tbody>
        <tr v-for="classes in tuesdayList" v-bind:key="classes.classId" class="tuesday-grid">
          <td class="name">{{ classes.className }}</td>
          <td class="description">{{ classes.classDescription }}</td>
          <td class="time">{{ classes.time }}</td>
        </tr>
      </tbody>
    </table>
    <table class="card">
      <thead class="title">
        Wednesday's Classes
      </thead>
      <tbody>
        <tr v-for="classes in wednesdayList" v-bind:key="classes.classId" class="wednesday-grid">
          <td class="name">{{ classes.className }}</td>
          <td class="description">{{ classes.classDescription }}</td>
          <td class="time">{{ classes.time }}</td>
        </tr>
      </tbody>
    </table>
    <table class="card">
      <thead class="title">
        Thursday's Classes
      </thead>
      <tbody>
        <tr v-for="classes in thursdayList" v-bind:key="classes.classId" class="thursday-grid">
          <td class="name">{{ classes.className }}</td>
          <td class="description">{{ classes.classDescription }}</td>
          <td class="time">{{ classes.time }}</td>
        </tr>
      </tbody>
    </table>
    <table class="card">
      <thead class="title">
        Friday's Classes
      </thead>
      <tbody>
        <tr v-for="classes in fridayList" v-bind:key="classes.classId" class="friday-grid">
          <td class="name">{{ classes.className }}</td>
          <td class="description">{{ classes.classDescription }}</td>
          <td class="time">{{ classes.time }}</td>
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

<style scoped>

.card{
  opacity: 95%;
  background-color: rgb(24,26,27);
  color: #d1cdc7;
  margin-bottom: 10px;
  
}


h1{
  color: #d1cdc7;
  font-weight: bold;
  text-shadow: 1px 0 0 rgb(46, 46, 46), 0 -1px 0 rgb(46, 46, 46), 0 1px 0 rgb(46, 46, 46), -1px 0 0 rgb(46, 46, 46); 
}
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