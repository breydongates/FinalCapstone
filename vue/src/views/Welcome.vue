<template>
  <div id="app app-bottom-left">
      WELCOME,
      <span>to the Comic Book Database!</span>
      <button class="publicCollectionsLink"><router-link :to="{name: 'PublicCollections'}">View All Public Collections</router-link></button>
      <button class="publicComicsLink"><router-link :to="{name: 'Comics'}">View All Public Comics</router-link></button>
  </div>
</template>

<script>
export default {

}
</script>

<style>

</style>