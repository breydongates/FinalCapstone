<template>
  <div class="collection">
      <h2> 
          <router-link v-bind:to="{name: 'collection'}"> {{collection.name}}
          </router-link>
      </h2>
  </div>
</template>

<script>
//import collectionService from "../services/CollectionService";
export default {
name: "CollectionList",
methods: {
 
    }
}


</script>

<style>

</style>