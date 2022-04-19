<template>
    <div>
        <h1>Workout Details</h1>
        <table v-for="details in workoutDetails" v-bind:key="details.workoutId" class="card">
            <tbody>
                <tr>
                    <td class="labels">Equipment Name: </td>
                    <td class="empty"></td>
                    <td align="right" class="values">{{details.equipmentName}}</td>
                </tr>
                <tr>
                    <td class="labels">No. of Reps: </td>
                    <td class="empty"></td>
                    <td align="right" class="values">{{details.reps}}</td>
                </tr>
                <tr>
                    <td class="labels">Weight: </td>
                    <td class="empty"></td>
                    <td align="right" class="values">{{details.weight}} pounds</td>
                </tr>
                <tr>
                    <td class="labels">Set Duration: </td>
                    <td class="empty"></td>
                    <td align="right" class="values">{{Math.round((Date.parse(details.useStop) - Date.parse(details.useStart)) / 60000)}} Minutes</td>
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

<style scoped>
h1{
    text-align: center;
    font-weight: bold;
    color: #d1cdc7;
}

.card {
    margin-bottom: 10px;
    padding-left: 20%;
    padding-right: 20%;
    padding-top: 2%;
    padding-bottom: 2%;
    background-color: rgb(24,26,27);
    color: #d1cdc7;
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
</style>