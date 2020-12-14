<template>

  <div id="comicView"> 
    <h1> Your Comics </h1>
    <section id="viewComic">
    <view-comic v-bind:collectionId="collectionId">
    </view-comic>
      </section>
    <section id="addComicButton">
     <create-comic v-bind:collectionId="collectionId"/>
     </section>
  </div>
</template>

<script>
import CreateComic from "@/components/CreateComic.vue";
import ViewComic from  "@/components/ViewComic.vue";

export default {
    name: "add-comic",
    components: {
       CreateComic,
       ViewComic,
    },
    created () {
      this.collectionId = this.$route.params.collectionId;
      console.debug(this.collectionId);
    },
    data () {
      return {
        collectionId: 0,
      }
    } 
}
</script>

<style>

</style>