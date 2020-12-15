<template>

  <div id="comicView"> 
    <h1>Add Comics to Collection</h1>
      <section id="addComicButton">
        <create-comic v-bind:collectionId="collectionId"/>
      </section>
  </div>
</template>

<script>
import CreateComic from "@/components/CreateComic.vue";

export default {
    name: "add-comic",
    components: {
       CreateComic,
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

</style>