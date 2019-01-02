<template>
  <div>
    <h4>Bucket: {{ bucketName }}</h4>
  </div>
  
</template>


<script>
import { mapState } from 'vuex'

export default {
name: 'BucketInfo',   
computed: {
    ...mapState([
        'bucketName'
    ])
  },
}
</script>
