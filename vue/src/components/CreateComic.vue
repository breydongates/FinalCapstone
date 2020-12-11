<template>
  <form v-on:submit.prevent="saveComic()">
    <h1>Add Comic</h1>
    <div>
      <label for="title"> Title </label>
      <input 
      type="text" 
      id="title" 
      name="Title" 
      v-model="comic.title"
       />
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
      <div class="actions">
        <button type="submit">Save Comic</button>
      </div>
    </div>
  </form>
</template>

<script>
import comicService from "../services/ComicService";
export default {
  name: "CreateComic",
  data() {
    return {
      comic: {
        title: "",
        description: "",
        publisher: "",
        creator: "",
        collectionId: this.$props.collectionId,
      },
    };
  },
  methods: {
    saveComic() {
      const newComic = {
        title: this.comic.title,
        description: this.comic.description,
        publisher: this.comic.publisher,
        creator: this.comic.creator,
        collectionId: this.comic.collectionId,
      };
      comicService.addComic(newComic).then((response) => {
        if (response.status === 201) {
          this.comic.title = "";
          this.comic.description = "";
          this.comic.publisher = "";
          this.comic.creator = "";
        }
      });
    },
  },
  props: {
    collectionId: Number,
  },
};
</script>

<style>
</style>