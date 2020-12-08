<template>
  <form>
      <h1>Add Comic </h1>
      <div>
          <label for="title"> Title </label>
        <input type="text" id="title" name="Title" v-model="comic.title">
        <label for="description"> Description </label>
        <input type="text" id="description" name="Description" v-model="comic.description">
        <label for="publisher"> Publisher </label>
        <input type="text" id="publisher" name="Publisher" v-model="comic.publisher">
        <div class="actions">
            <button type="submit" v-on:click="saveComic()">Save Comic</button>
        </div>
      </div>


  </form>
</template>

<script>
export default {

}
</script>

<style>

</style>