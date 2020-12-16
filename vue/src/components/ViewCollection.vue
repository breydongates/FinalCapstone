<template>
  <div class="collection" >
      <div >
        <ul>  
            <li class="collectionBubble collectionBubble-bottom-left"
            v-for="Collection in Collections" :key="Collection.collectionId">
            {{Collection.collectionName}} 
            <br>
            <router-link :to="{name: 'AddComic', params: {collectionId:Collection.collectionId}}" tag="button">Add Comics</router-link>
            <br>
            <router-link :to="{name: 'CollectionStats', params: {collectionId:Collection.collectionId}}" tag="button">See Collection Details</router-link>
            </li>
        </ul>
        </div>
      </div>
</template>

<script>
import collectionService from "@/services/CollectionService.js";


export default {
name: "CollectionList",
components: {

},

data() {
    return {
        Collections:[], 
    };     
},

methods: {
 
},
created() {

    collectionService.viewAllCollectionsByUser().then( (response) =>{
        this.Collections = response.data;
    });
}, 
}


</script>

<style>


</style>