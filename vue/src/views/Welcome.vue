<template>
  <div class="yourCollections">
    <div class="collectionBubble">
     <p> WELCOME, to the Comic Book Database! </p>
     <p> <button class="publicCollectionsLink"><router-link :to="{name: 'PublicCollections'}">View All Public Collections</router-link></button>
     </p>
    </div>
  </div>
</template>

<script>
export default {

}
</script>

<style scoped>
.yourCollections{
  padding-top:20em;
}
</style>