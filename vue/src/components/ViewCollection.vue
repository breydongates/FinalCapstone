<template>
  <div >
      <div class="yourCollections"  style="overflow:hidden;">
            <h1> Your Collections </h1>
        <ul style="overflow-y:scroll; margin:0; height:100%;">  
            <li class="collectionBubble" style="font-size:20px;"
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

<style scoped>
.collectionBubble{
    padding-left:15em;
    padding-right:15em;
}
.yourCollections{
    padding-bottom: 3em;
    padding-top:1em;
}

</style>