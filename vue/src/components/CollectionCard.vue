<template>
  <div class="collectioncard"
  {{collections.name}}> 
      <button class="add-comic" v-on:click="addComic"></button>
  </div>
</template>

<script>
export default {
  name: "collection-card",
  props: {
    collection: Object,
  },
 
  }


</script>

<style>

</style>