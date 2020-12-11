<template>
  <div> 
     <create-comic v-bind:collectionId="collectionId"/>
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