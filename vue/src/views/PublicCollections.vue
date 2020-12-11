<template>
  <div>
      <h1 class="yourCollections">Public Collections</h1>
      <div class="collection">
      <h2> 
        <ul>  
            <li v-for="Collection in Collections" :key="Collection.collectionId"> 
                <router-link :to="{name: 'Comics', params: {collectionId:Collection.collectionId}}">{{Collection.collectionId}} {{Collection.collectionName}}</router-link> 
            </li>
        </ul>
      </h2>
  </div>
  </div>
</template>

<script>
import collectionService from "@/services/CollectionService.js"

export default {
    components : {
    },

    data() {
    return {
        Collections:[], 
    };        
},
created() {

    collectionService.viewAllPublicCollections().then( (response) =>{
        this.Collections = response.data;
    });
}
};
</script>

<style>


</style>