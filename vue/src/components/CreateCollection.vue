<template>
  <form >
      <div>
          <label for="collectionName"> Collection Name </label>
          <input type="text" id="collectionName" name="CollectionName" v-model="collection.name">
          <input type="radio" id="public" name="publicOrPrivate" value="public" v-model="collection.publicOrPrivate">
          <label for="public"> Public </label> <br>
          <input type="radio" id="private" name="publicOrPrivate" value="private" v-model="collection.publicOrPrivate">
          <label for="private"> Private </label> <br>
        <div class="actions">
        <button type="submit" v-on:click="saveCollection()">Save Collection </button>
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
            publicOrPrivate: "",
        },
    }
},
methods: {
    saveCollection(){
        collectionService.createCollection(this.collection)
        .then(response => {
            if(response.status === 201){
                this.$store.commit('CREATE_COLLECTION');
                
            }
        })
    }
}
}
</script>

<style>

</style>