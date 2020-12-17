<template>
  <div style="overflow-y:auto; height:100%;">
      
        <ul class="collectionList" >  
            <li class="collectionBubble" v-for="Collection in Collections" :key="Collection.collectionId"> 
                <router-link :to="{name: 'Comics', params: {collectionId:Collection.collectionId}}">{{Collection.collectionName}}</router-link>
            </li>
        </ul>
      
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

    collectionService.viewAllPublicCollections().then( (response) =>{
        this.Collections = response.data;
    });
}, 
}


</script>

<style>
.collection{
    height: 100%;
}

</style>