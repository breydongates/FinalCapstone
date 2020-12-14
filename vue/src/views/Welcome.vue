<template>
  <div id="app">
      WELCOME,
      <span>to the Comic Book Database!</span>
      <br />
      <p class="publicCollectionsLink"><router-link :to="{name: 'PublicCollections'}">View All Public Collections</router-link></p>
      <p class="publicComicsLink"><router-link :to="{name: 'Comics'}">View All Public Comics</router-link></p>
  </div>
</template>

<script>
export default {

}
</script>

<style>

</style>