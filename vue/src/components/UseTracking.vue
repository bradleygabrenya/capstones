<template>
    <div>
        <table v-for="details in workoutDetails" v-bind:key="details.workoutId">
            <tbody>
                <tr>
                    <td></td>
                    <td>{{details.trackingId}}</td>
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
}
</script>

<style>

</style>