<template>
<div class="viewComic">
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
            comicService.viewAllPublicComics()
            foreach(comic in )
            .then(response => {
                this.$store.commit("SET_COMICS", response.data);
            });
        }
        
    },
     created () {
      this.collectionId = Number.parseInt(this.$route.params.collectionId);
      console.debug(this.collectionId);

      comicService.viewComicsByCollection(this.Id)
      .then((response) => {
          if(response.status == 200) {
              this.$store.commit("SET_COMICS", response.data);
          }
          
      })

    },
    data () {
      return {
            Id: this.$props.collectionId,
      }
    }, 
    props: {
        collectionId: Number,
    },
    computed: {
        Comics() {
            return this.$store.state.Comics;
        }
    },
}
</script>

<style>

</style>