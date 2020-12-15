<template>
  <form v-on:submit.prevent="saveComic()">
    <h1>Add Comic</h1>
    <div>
      <label for="title"> Title </label>
      <input type="text" id="title" name="Title" v-model="comic.title" />
      <br />
      <label for="description"> Description </label>
      <input
        type="text"
        id="description"
        name="Description"
        v-model="comic.description"
      />
      <label for="publisher"> Publisher </label>
      <input
        type="text"
        id="publisher"
        name="Publisher"
        v-model="comic.publisher"
      />
      <label for="creator"> Creator </label>
      <input type="text" id="creator" name="Creator" v-model="comic.creator" />
      <!--Add input for characters, require at least 1 character entry-->

      <label for="mainCharacter"> Main Character </label>
      <input
        type="text"
        id="mainCharacter"
        name="mainCharacter"
        v-model="comic.mainCharacter"
      />
      <div class="actions">
        <button type="submit">Save Comic</button>
      </div>
    </div>
  </form>
</template>

<script>
import comicService from "../services/ComicService.js";
import collectionSerice from "../services/CollectionService.js"

export default {
  name: "CreateComic",
  data() {
    return {
      comic: {
        title: "",
        description: "",
        publisher: "",
        creator: "",
        mainCharacter: "",
        collectionId: this.$props.collectionId,
      },
      numberOfComicsInCollection: 0,
    };
  },
  methods: {
    saveComic() {
      const newComic = {
        title: this.comic.title,
        description: this.comic.description,
        publisher: this.comic.publisher,
        creator: this.comic.creator,
        mainCharacter: this.comic.mainCharacter,
        collectionId: this.comic.collectionId,
      };
      collectionSerice.getNumOfComicsInCollection(this.collectionId)
      .then((response) => {
        if(response.status === 200) {
          this.numberOfComicsInCollection = response.data;
        }
      });
      if ((this.$store.state.user.role === 'Standard' && this.numberOfComicsInCollection <= 5) || this.$store.state.user.role === "Premium"){
        comicService.addComic(newComic, this.user)
        .then((response) => {
          if (response.status === 201) {
            this.comic.title = "";
            this.comic.description = "";
            this.comic.publisher = "";
            this.comic.creator = "";
            this.comic.mainCharacter = "";
          }
        });
      }else 
        {
          alert ("Limit of comics reached. Please upgrade to a premium account");
        }
    }
  },
  
  props: {
    collectionId: Number,
  }    
}
</script>

<style>
</style>