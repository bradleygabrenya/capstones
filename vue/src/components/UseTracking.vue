<template>
    <div>
        <h1>Workout Details</h1>
        <table v-for="details in workoutDetails" v-bind:key="details.workoutId" class="card">
            <tbody>
                <tr>
                    <td class="labels"><span style= "font-weight: bold"> Name: </span> </td>
                    <td class="empty"></td>
                    <td align="right" class="values">{{details.equipmentName}}</td>
                </tr>
                <tr>
                    <td class="labels"><span style= "font-weight: bold">No. of Reps: </span></td>
                    <td class="empty"></td>
                    <td align="right" class="values">{{details.reps}}</td>
                </tr>
                <tr>
                    <td class="labels"><span style= "font-weight: bold">Weight: </span></td>
                    <td class="empty"></td>
                    <td align="right" class="values">{{details.weight}} pounds</td>
                </tr>
                <tr>
                    <td class="labels"><span style= "font-weight: bold">Set Duration: </span></td>
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
 }
</script>

<style scoped>
h1{
    text-align: center;
    font-weight: bold;
    color: #d1cdc7;
    text-shadow: 1px 0 0 rgb(46, 46, 46), 0 -1px 0 rgb(46, 46, 46), 0 1px 0 rgb(46, 46, 46), -1px 0 0 rgb(46, 46, 46); 
}

.card {
    opacity: 95%;
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