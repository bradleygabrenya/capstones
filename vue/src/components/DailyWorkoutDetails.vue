<template>
    <div class="display">
        <h1>Workout History</h1>
        <table v-for="workout in workouts" v-bind:key="workout.workoutId" class="card">
            <tbody>
                <tr>
                    <td class="labels">Date: </td>
                    <td class="empty"></td>
                    <td align="right" class="values">{{workout.checkIn.substring(0,10)}}</td>
                </tr>
                <tr>
                    <td class="labels">Check-in: </td>
                    <td class="empty"></td>
                    <td align="right" class="values">{{workout.checkIn.substring(11,19)}}</td>
                </tr>
                <tr>
                    <td class="labels">Check-out: </td>
                    <td class="empty"></td>
                    <td align="right" class="values">{{workout.checkOut.substring(11,19)}}</td>
                </tr>
                <tr>
                    <td class="labels">Total Workout Duration: </td>
                    <td class="empty"></td>
                    <td align="right" class="values">{{Math.round((Date.parse(workout.checkOut) - Date.parse(workout.checkIn)) / 60000)}} Minutes</td>
                </tr>
            </tbody>
            <router-link :to="{ name: 'workout-details', params: { workoutId: workout.workoutId} }" class="btn btn-primary">View Details </router-link>
        </table>
    </div>
</template>

<script>
export default {
    name: "DailyWorkoutDetails",
    props: {workouts: Array},
}
</script>

<style scoped>
h1{
    text-align: center;
    font-weight: bold;
}
.btn {
    width: 50%;
    display: inline-block;
    align-self: center;
    margin-bottom: 5px;
}

table{
    width: 100%
}

.empty{
    width: 0%
}
.values{
    width:100%
}

.labels{
    width:50%
}

.card {
    margin-bottom: 10px;
    padding-left: 20%;
    padding-right: 20%;
    padding-top: 2%;
}



</style>