<template>
  <div class="collectioncard" v-bind:class="{collection: collections.name}"> 
      <button class="add-comic" v-on:click="addComic"></button>
  </div>
</template>

<script>
export default {
  name: "collection-card",
  props: {
    collection: Object,
  },
  methods: {
    addComic(){
      this.$store.commit('ADD_COMIC', this.collection)
    }
  }

}
</script>

<style>

</style>