<template>
  <div>
    <p>There are currently {{ countObjects }} objects in the bucket</p>
  </div>
</template>


<script>
import { mapGetters } from 'vuex'

export default {
name: 'Total',   
computed: {
    ...mapGetters([
        'countObjects'
    ])
}  
}
</script>
