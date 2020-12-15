<template>
  <div class="yourCollections">
      <h1>Public Collections</h1>
      <div class="collection">
          <view-public-collections></view-public-collections>
      </div>
  </div>
</template>

<script>
import ViewPublicCollections from "@/components/ViewPublicCollections.vue"

export default {
    components : {
        ViewPublicCollections,
    },

    data() {
    return {
        Collections:[], 
    };        
},
}
</script>

<style>


</style>