<template>

  <div class="yourCollections" style="overflow:hidden"> 
    <h1> Your Comics </h1>
  <ul style="overflow-y:scroll; margin:0; height:100%; padding-bottom:300px;">
        <view-comic v-bind:collectionId="collectionId">
    </view-comic>
   </ul> 
    <section id="addComicButton">
        <collection-statistics v-bind:collectionId="collectionId"/>
    </section>
  </div>
</template>

<script>
import ViewComic from  "@/components/ViewComic.vue";
import CollectionStatistics from '../components/CollectionStatistics.vue';

export default {
    name: "add-comic",
    components: {
        ViewComic,
        CollectionStatistics,
    },
    created () {
      this.collectionId = Number.parseInt(this.$route.params.collectionId);
    },
    data () {
      return {
        collectionId: 0,
      }
    } 
}
</script>

<style scoped>
ul{
    text-overflow: ellipsis;
}

</style>