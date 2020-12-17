<template>
<div class="collectionBubble">
  <form v-on:submit.prevent="saveComic()">
    <h1>Add Comic</h1>
    <div class="saveComicInput">
      <label for="title" > Title 
      <input type="text" id="title" name="Title" v-model="comic.title" />
      </label>
      <br />
      <label for="description"> Description 
      <input
        type="text"
        id="description"
        name="Description"
        v-model="comic.description"
      />
      </label>
      <br />
      <label for="publisher"> Publisher 
      <input
        type="text"
        id="publisher"
        name="Publisher"
        v-model="comic.publisher"
      />
      </label>
      <br />
      <label for="edition"> Edition Number
      <input type="number" id="edition" name="Edition" v-model="comic.edition" /> </label>
      <!--Add input for characters, require at least 1 character entry-->
  <br />
      <label for="mainCharacter"> Main Character 
      <input
        type="text"
        id="mainCharacter"
        name="mainCharacter"
        v-model="comic.mainCharacter"
      />
      </label>
      <br />
      <div class="actions">
        <button type="submit">Save Comic</button>
      </div>
    </div>
  </form>
</div>
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
        edition: "",
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
        edition: this.comic.edition,
        mainCharacter: this.comic.mainCharacter,
        collectionId: this.comic.collectionId,
      };
      collectionSerice.getNumOfComicsInCollection(this.collectionId)
      .then((response) => {
        if(response.status === 200) {
          this.numberOfComicsInCollection = response.data;
        }
      if ((this.$store.state.user.role === 'Standard' && this.numberOfComicsInCollection < 5) || this.$store.state.user.role === 'Premium'){
        comicService.addComic(newComic, this.user)
        .then((response) => {
          if (response.status === 201) {
            this.comic.title = "";
            this.comic.description = "";
            this.comic.publisher = "";
            this.comic.edition = "";
            this.comic.mainCharacter = "";
            this.$router.push({name: "CollectionStats", params: {collectionId: this.comic.collectionId}});
          }
        });
      }else 
        {
          alert ("Limit of comics reached. Please upgrade to a premium account");
        }
      });
    }
  },
  
  props: {
    collectionId: Number,
  }    
}
</script>

<style>
.saveComicInput > label{
 width:500px;
 clear: both;
}
.saveComicInput > label > input{
  width: 100%;
  clear:both;
}

</style>