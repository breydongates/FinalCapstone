<template>

  <div class="yourCollections"> 
    <h1>Add Comics to Collection</h1>
      
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
.collectionBubble{
  margin-top:-18px;
}
</style>