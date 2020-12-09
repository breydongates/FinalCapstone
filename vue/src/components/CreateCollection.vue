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
        value="false"
        v-model="collection.IsPrivate"
      />
      <label for="public"> Public </label>
      <input
        type="radio"
        id="private"
        name="isPrivate"
        value="true"
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
        IsPrivate: false,
        //Username: "",
      },
    };
  },
  methods: {
    saveCollection() {
      const newCollection = {
        CollectionName: this.collection.CollectionName,
        IsPrivate: this.collection.IsPrivate,
        //Username: this.$store.state.user.username,
      };
      collectionService.createCollection(newCollection).then((response) => {
        if (response.status === 201) {
          this.$store.commit("CREATE_COLLECTION", response.data);
          if (this.$router.currentRoute !== "CreateCollection") {
            this.$router.push({ name: "CreateCollection" });

            // Want to navigate to view collections and clear form 
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