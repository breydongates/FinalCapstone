<template>

  <div id="comicView" > 
    <h1> Your Comics </h1>
    <section id="viewComic" style="overflow-y:auto">
        <view-comic v-bind:collectionId="collectionId">
    </view-comic>
    </section>
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

<style>
.comicView{
  height: 100%;
}
#viewComic{
  height: 75%;
}
</style>