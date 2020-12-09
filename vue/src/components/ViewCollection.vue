<template>
  <div class="collection">
      <h2> 
          <p v-on:click="viewAllCollectionsByUser">Click Here For Collections 
              
          </p>
        <ul>  
            <li v-for="Collection in Collections" :key="Collection.CollectionId"> 
                {{Collection.CollectionName}}
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