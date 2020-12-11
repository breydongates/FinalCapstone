<template>
  <div class="collection">
      <h2> 
        <ul>  
            <li v-for="Collection in Collections" :key="Collection.collectionId"> 
                <router-link :to="{name: 'AddComic', params: {collectionId:Collection.collectionId}}">{{Collection.collectionId}} {{Collection.collectionName}}</router-link> 
            </li>
        </ul>
      </h2>
  </div>
</template>

<script>
import CollectionCard from "@/components/CollectionCard.vue";
import collectionService from "@/services/CollectionService.js";

export default {
name: "CollectionList",
components: {
    CollectionCard,
},

data() {
    return {
        Collections:[], 
    };     
},

methods: {
 
viewAllCollectionsByUser() {
    collectionService.viewAllCollectionsByUser()
    .then((response) => {
        if(response.status == 200) {
            this.Collections = response.data;

        }
    
    })
}


},

addComicToCollection(collectionId) {

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