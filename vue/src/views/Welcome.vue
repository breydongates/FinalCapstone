<template>
  <div class="yourCollections">
    <div class="collectionBubble">
     <p style="font-size:50px;"> WELCOME, to the Comic Book Database! </p>
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
  padding-top:9em;
}
</style>