<template>
  <form v-on:submit.prevent="saveCollection()">
      <div>
          <label for="collectionName"> Collection Name </label>
          <input type="text" id="collectionName" name="CollectionName" v-model="collection.name"> <br>
          <input type="radio" id="public" name="isPrivate" value="false" v-model="collection.isPrivate">
          <label for="public"> Public   </label> 
          <input type="radio" id="private" name="isPrivate" value="true" v-model="collection.isPrivate">
          <label for="private"> Private </label> <br>
          
        <div class="actions">
        <button type="submit">Save Collection </button>
        </div>
      </div>

  </form>
</template>

<script>
import collectionService from "../services/CollectionService"; 

export default {
name: "create-collection",
data(){
    return {
        collection: {
            name: "",
            isPrivate: false,
        },
    }
},
methods: {
    
    saveCollection(){
        const newCollection = {
            name: this.collection.name,
            isPrivate: this.collection.isPrivate,
        };
        collectionService.createCollection(newCollection)
        .then(response => {
            if(response.status === 201){
                this.$store.commit('CREATE_COLLECTION', response.data);
            if(this.$router.currentRoute !== "CreateCollection"){
                this.$router.push({ name: "CreateCollection"});
            }
            }
        });
    }
},
}
</script>

<style>
#public{
    padding: 1rem;
}
#private{
    padding: 1rem;
}
</style>