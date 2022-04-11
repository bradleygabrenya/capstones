<template>
    <div>
        <table v-for="workout in workouts" v-bind:key="workout.workoutId">
            <tbody>
                <tr>
                    <td>Check-in</td>
                    <td>{{workout.checkIn}}</td>
                </tr>
                <tr>
                    <td>Check-out</td>
                    <td>{{workout.checkOut}}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
export default {
    name: "DailyWorkoutDetails",
    props: {workouts: Array},
}
</script>

<style>

</style>