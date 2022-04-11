<template>
    <div>
        <table v-for="details in workoutDetails" v-bind:key="details.workoutId">
            <tbody>
                <tr>
                    <td>No. of Reps: {{details.reps}}</td>
                </tr>
                <tr>
                    <td>Weight: {{details.weight}} pounds</td>
                </tr>
                <tr>
                    <td>{{(Date.parse(details.useStop) - Date.parse(details.useStart)) / 60000}} Minutes</td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
export default {
    name: "UseTracking",
    props: {workoutDetails : Array},
    methods: {
        
    },
//     computed: {
//         difference: {
//             end: new Date.parse(this.details.useStop),
//             start: new Date.parse(this.details.useStart),
//             difference: (this.end - this.start) / 60000,
//         }
//     },
 }
</script>

<style>

</style>