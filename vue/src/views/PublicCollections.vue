<template>

      <div class="yourCollections" style="overflow:hidden">
          <h1>Public Collections</h1>
            
          <view-public-collections></view-public-collections>
          <all-public-comic-stats>
              
          </all-public-comic-stats>
      </div>

</template>

<script>
import ViewPublicCollections from "@/components/ViewPublicCollections.vue"
import AllPublicComicStats from "@/components/AllPublicComicStats.vue"

export default {
    components : {
        ViewPublicCollections,
        AllPublicComicStats,
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