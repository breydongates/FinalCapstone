<template>
  <div class="yourCollections">
      <h1>Public Collections</h1>
      <div class="collection">
          <view-public-collections></view-public-collections>
          <all-comic-stats>
              
          </all-comic-stats>
      </div>
  </div>
</template>

<script>
import ViewPublicCollections from "@/components/ViewPublicCollections.vue"
import AllComicStats from "@/components/AllPublicComicStats.vue"

export default {
    components : {
        ViewPublicCollections,
        AllComicStats,
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