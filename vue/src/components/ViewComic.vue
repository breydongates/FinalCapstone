<template>
<div class="comic">
    <h2>
        <ul>
            
               <comic-card 
               v-for="c in Comics"
               v-bind:key="c.ComicId"
               v-bind:Comic="c"> 

               </comic-card>
               
            
        </ul>
        


        
    </h2>
</div>

</template>

<script>
import comicService from "@/services/ComicService.js";
import comicCard from "@/components/ComicCard.vue";
export default {
    components: {
        comicCard,
    },
    name: "comic-list",
    methods: {
        viewAllComics(){
            comicService.view().then(response => {
                this.$store.commit("SET_COMICS", response.data);
            });
        }
        
    },
     created () {
      this.collectionId = this.$route.params.collectionId;
      console.debug(this.collectionId);

      comicService.viewComicsByCollection(this.Id)
      .then((response) => {
          if(response.status == 200) {
              this.Comics = response.data;
          }
          
      })

    },
    data () {
      return {
            Id: this.$props.collectionId,
            Comics: [],
      }
    }, 
    props: {
        collectionId: Number,
    },
}
</script>

<style>

</style>