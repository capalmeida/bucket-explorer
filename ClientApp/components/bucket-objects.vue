<template>
  <div>
    <div v-if="!bucketObjects" class="text-center">
            <p><em>{{ loadingStatus }}</em></p>
            <h1><icon icon="spinner" pulse/></h1>            
        </div>
        <div class="text-left">
            <hr />
            <bucketInfo />
        </div>
        <template v-if="bucketObjects">
            <table class="table">
                <thead  class="bg-dark text-white">
                    <tr>
                        <th>Folder</th>
                        <th>Name</th>
                        <th>ContentType</th>
                        <th>Size</th>
                    </tr>
                </thead>
                <tbody>
                    <tr :class="index % 2 == 0 ? 'bg-white' : 'bg-light'" v-for="(obj, index) in bucketObjects" :key="index">
                        <td>{{ obj.folder }}</td>
                        <td>{{ obj.name }}</td>
                        <td>{{ obj.contentType }}</td>
                        <td>{{ obj.size }}</td>
                    </tr>
                </tbody>
            </table>
        </template>
        <div v-if="bucketObjects" class="text-right">
            <hr />
            <total />
        </div>
  </div>
  
</template>


<script>
import BucketInfo from './bucket-info'
import Total from './total'
import { mapActions, mapMutations, mapState } from 'vuex'

export default {
components: {
    BucketInfo,
    Total
},

computed: {
    ...mapState([
        'loadingStatus',
        'bucketObjects'
    ])
},

mounted(){
    this.$store.dispatch('fetchBucketObjects')
}   
}
</script>

<style>
</style>
