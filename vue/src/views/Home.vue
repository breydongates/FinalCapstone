<template>
  <div class="home">
    
    <h1> Comic Book Database </h1> <!-- CHANGE ME -->
    <router-link :to="{name: 'CreateCollection'}"> Create Collection </router-link>
    <router-link :to="{name: 'Collection'}" > View Your Collections </router-link>
    <router-link :to="{name: 'AddComic'}"> Add Comic </router-link>
    <router-link :to="{name: 'Comic'}"> View Comics </router-link> 
    
  </div>
</template>

<script>
import collectionService from '@/services/CollectionService.js';

export default {
  name: "home",
  methods: {
    viewAllCollectionsByUser(){
      collectionService.viewAllCollectionsByUser();
    },
  }
};
</script>
