<template>
  <div class="collection">
      <h2> 
        
        <ul>  
            <li v-for="Collection in Collections" :key="Collection.collectionId"> 
                {{Collection.collectionName}}
            </li>


        </ul>

      </h2>
  </div>
</template>

<script>
import collectionService from "@/services/CollectionService.js";

export default {
name: "CollectionList",
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
/*created() {

    this.Collections = collectionService.viewAllCollectionsByUser().response.data;
}, */
}


</script>

<style>


</style>