<template>
  <div class="yourCollections" style="overflow:hidden"> 
      <h1>  
          Comics In This Collection
      </h1>
      <view-comic />
  </div>
</template>

<script>
import ViewComic from "@/components/ViewComic"; 

export default {
    components : {
        ViewComic
    },

};
</script>

<style>

</style>