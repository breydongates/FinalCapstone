<template>
  <div>
      <h1 class="publicComics"> Public Comics</h1>
      <div class="collection">
          <h2>
              <ul>
                  <li v-for="Comic in Comics" :key="Comic.comicId">
                      <router-link :to="{name: 'Comics', params: {comicId:Comic.comicId}}"> {{Comic.comicId}} {{Comic.comicTitle}}</router-link>
                  </li>
              </ul>
          </h2>  

      </div>
  </div>
</template>

<script>
import comicService from "@/services/ComicService.js";

export default {
    name: "public-comics",
    data() {
    return {
        Comics: [],
    };
    },
    created() {
        comicService.viewAllPublicComics().then((response) => {
            this.Comics = response.data;
        });
    }

}
</script>

<style>

</style>