<template>
<div class="comic">
    <h2>
        <router-link v-bind:to="{name: 'comic'}"> {{comic.title}}

        </router-link>
    </h2>
</div>

</template>

<script>
import comicService from "@/services/ComicService.js";
export default {
    name: "comic-list",
    methods: {
        viewAllComics(){
            comicService.view().then(response => {
                this.$store.commit("SET_COMICS", response.data);
            });
        }
    }
}
</script>

<style>

</style>