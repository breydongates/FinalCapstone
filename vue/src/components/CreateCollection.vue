<template>
  <form v-on:submit.prevent="saveCollection()">
    <div>
      <label for="collectionName"> Collection Name </label>
      <input
        type="text"
        id="collectionName"
        name="CollectionName"
        v-model="collection.CollectionName"
      />
      <br />
      <input
        type="radio"
        id="public"
        name="isPrivate"
        value= 0
        v-model="collection.IsPrivate"
      />
      <label for="public"> Public </label>
      <input
        type="radio"
        id="private"
        name="isPrivate"
        value= 1
        v-model="collection.IsPrivate"
      />
      <label for="private"> Private </label> <br />

      <div class="actions">
        <button type="submit">Save Collection</button>
      </div>
    </div>
  </form>
</template>

<script>
import collectionService from "../services/CollectionService";

export default {
  name: "create-collection",
  data() {
    return {
      collection: {
        CollectionName: "",
        IsPrivate: 0,
      },
    };
  },
  methods: {
    saveCollection() {
      const newCollection = {
        CollectionName: this.collection.CollectionName,
        IsPrivate: this.collection.IsPrivate,
      };

      if (newCollection.IsPrivate == 0) {
        newCollection.IsPrivate = false;
      }
      else {
        newCollection.IsPrivate = true;
      }
      
      collectionService.createCollection(newCollection).then((response) => {
        if (response.status === 201) {
          this.$store.commit("CREATE_COLLECTION", response.data);
          if (this.$router.currentRoute !== "home") {
            this.$router.push({ name: "home" });


             
          }
        }
      });
    },
  },
};
</script>

<style>
#public {
  padding: 1rem;
}
#private {
  padding: 1rem;
}

</style>