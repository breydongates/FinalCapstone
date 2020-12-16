<template>
  <div id="app">
     <p> WELCOME, to the Comic Book Database! </p>
     <p> <button class="publicCollectionsLink"><router-link :to="{name: 'PublicCollections'}">View All Public Collections</router-link></button>
      <button class="publicComicsLink"><router-link :to="{name: 'Comics'}">View All Public Comics</router-link></button> </p>
  </div>
</template>

<script>
export default {

}
</script>

<style>

</style>